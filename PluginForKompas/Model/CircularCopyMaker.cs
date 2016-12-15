using Kompas6Constants3D;
using Kompas6API5;
using System.Windows.Forms;

namespace PluginForKompas
{
    /// <summary>
    /// Класс для операции "массив по концентрической сетке"
    /// </summary>
    public static class CircularCopyMaker
    {
        /// <summary>
        /// Метод копирует последнюю операцию 
        /// по концентрической окружности относительно оси OY
        /// </summary>
        /// <param name="count">Количество копий</param>
        public static void CreateOperationCircPartArray(int count)
        {
            try
            {
                ksEntityCollection elemCol = (ksEntityCollection)KompasApp.part.EntityCollection((short)Obj3dType.o3d_cutExtrusion);
                if ((elemCol != null) && (elemCol.GetCount() != 0))
                {
                    ksEntity axis = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_axisOY);
                    ksEntity circCopy = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_circularCopy);
                    ksCircularCopyDefinition CopyDef = (ksCircularCopyDefinition)circCopy.GetDefinition();

                    if (CopyDef != null)
                    {
                        CopyDef.count1 = 1;
                        CopyDef.count2 = count;
                        CopyDef.step2 = 360;
                        CopyDef.factor2 = true;
                        CopyDef.SetAxis(axis);
                        ksEntityCollection copiedElemCol = (ksEntityCollection)CopyDef.GetOperationArray();
                        copiedElemCol.Clear();
                        int i = elemCol.GetCount();
                        copiedElemCol.Add(elemCol.GetByIndex(i - 1));
                        circCopy.Create();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Copies weren't builded.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// МЕтод копирует последние 5 операции 
        /// по концентрической окружности относительно оси OY
        /// </summary>
        /// <param name="count"></param>
        public static void CreateChamferCircPartArray(int count)
        {
            try
            {
                ksEntityCollection elemCol = (ksEntityCollection)KompasApp.part.EntityCollection((short)Obj3dType.o3d_cutExtrusion);
                ksEntityCollection chamCol = (ksEntityCollection)KompasApp.part.EntityCollection((short)Obj3dType.o3d_chamfer);

                if ((elemCol != null) && (elemCol.GetCount() != 0)
                    && (chamCol != null) && (chamCol.GetCount() != 0))
                {
                    ksEntity axis = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_axisOY);
                    ksEntity circCopy = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_circularCopy);
                    ksCircularCopyDefinition CopyDef = (ksCircularCopyDefinition)circCopy.GetDefinition();

                    if (CopyDef != null)
                    {
                        CopyDef.count2 = count;
                        CopyDef.step2 = 360;
                        CopyDef.factor2 = true;
                        CopyDef.SetAxis(axis);
                        ksEntityCollection copiedElemCol = (ksEntityCollection)CopyDef.GetOperationArray();
                        copiedElemCol.Clear();
                        int i = elemCol.GetCount();
                        copiedElemCol.Add(elemCol.GetByIndex(i - 1));
                        for (int j = chamCol.GetCount() - 4; j < chamCol.GetCount(); j++)
                        {
                            copiedElemCol.Add(chamCol.GetByIndex(j));
                        }
                        circCopy.Create();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Copies weren't builded.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
