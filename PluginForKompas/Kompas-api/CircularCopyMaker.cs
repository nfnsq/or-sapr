using Kompas6Constants3D;
using Kompas6API5;

namespace PluginForKompas
{
    /// <summary>
    /// Класс для операции "массив по концентрической сетке"
    /// </summary>
    public class CircularCopyMaker
    {
        private KompasApp _app;

        /// <summary>
        /// Коструктор с параметром
        /// </summary>
        /// <param name="app">Приложение компас</param>
        public CircularCopyMaker(KompasApp app)
        {
            this._app = app;
        }

        /// <summary>
        /// Метод копирует последнюю операцию 
        /// по концентрической окружности относительно оси OY
        /// </summary>
        /// <param name="count">Количество копий</param>
        public bool CreateOperationCircPartArray(int count)
        {
            try
            {
                ksEntityCollection elemCol = (ksEntityCollection)_app.Part.EntityCollection((short)Obj3dType.o3d_cutExtrusion);
                if ((elemCol != null) && (elemCol.GetCount() != 0))
                {
                    ksEntity axis = (ksEntity)_app.Part.NewEntity((short)Obj3dType.o3d_axisOY);
                    ksEntity circCopy = (ksEntity)_app.Part.NewEntity((short)Obj3dType.o3d_circularCopy);
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод для копирования фаски
        /// по концентрической окружности относительно оси OY
        /// </summary>
        /// <param name="count"></param>
        public bool CreateChamferCircPartArray(int count)
        {
            try
            {
                ksEntityCollection elemCol = (ksEntityCollection)_app.Part.EntityCollection((short)Obj3dType.o3d_cutExtrusion);
                ksEntityCollection chamCol = (ksEntityCollection)_app.Part.EntityCollection((short)Obj3dType.o3d_chamfer);

                if ((elemCol != null) && (elemCol.GetCount() != 0)
                    && (chamCol != null) && (chamCol.GetCount() != 0))
                {
                    ksEntity axis = (ksEntity)_app.Part.NewEntity((short)Obj3dType.o3d_axisOY);
                    ksEntity circCopy = (ksEntity)_app.Part.NewEntity((short)Obj3dType.o3d_circularCopy);
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
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
