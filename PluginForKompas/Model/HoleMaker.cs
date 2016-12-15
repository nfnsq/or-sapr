using Kompas6API5;
using Kompas6Constants3D;
using System.Windows.Forms;

namespace PluginForKompas
{
    /// <summary>
    /// Класс операции вырезать выдавливанием
    /// </summary>
    public static class HoleMaker
    {
        /// <summary>
        /// Метод выполняет операцию вырезать выдавливанием для 
        /// последнего созданного эскиза
        /// </summary>
        /// <param name="depth">Глубина выдавливания</param>
        static public void CutExtrusion(double depth)
        {
            try
            {
                ksEntityCollection coll = (ksEntityCollection)KompasApp.part.EntityCollection((short)Obj3dType.o3d_sketch);
                int i = coll.GetCount();
                ksEntity sketch = coll.GetByIndex(i - 1);
                ksEntity entityCutExtr = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
                if (entityCutExtr != null)
                {
                    ksCutExtrusionDefinition extrusionDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();
                    if (extrusionDef != null)
                    {
                        extrusionDef.directionType = (short)Direction_Type.dtMiddlePlane;
                    }
                    extrusionDef.SetSideParam(true, (short)End_Type.etBlind, depth, 0, false);

                    extrusionDef.SetSketch(sketch);
                    entityCutExtr.Create();
                    entityCutExtr.Update();
                }
            }
            catch
            {
                MessageBox.Show("Operation cut extrusion wasn't builded.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
