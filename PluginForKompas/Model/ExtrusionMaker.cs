using Kompas6API5;
using Kompas6Constants3D;
using System.Windows.Forms;

namespace PluginForKompas
{
    /// <summary>
    /// Класс операции выдавливания
    /// </summary>
    static public class ExtrusionMaker
    {
        /// <summary>
        /// Метод выполняет операцию выдавливания 
        /// для последнего созданного эскиза
        /// </summary>
        /// <param name="depth">Глубина выдавливания</param>
        static public void DoOperationExtrusion(double depth)
        {
            try
            {
                ksEntityCollection coll = (ksEntityCollection)KompasApp.part.EntityCollection((short)Obj3dType.o3d_sketch);
                int i = coll.GetCount();
                ksEntity sketch = coll.GetByIndex(i - 1);
                ksEntity entityExtr = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
                if (entityExtr != null)
                {
                    ksBaseExtrusionDefinition extrusionDef = (ksBaseExtrusionDefinition)entityExtr.GetDefinition();
                    if (extrusionDef != null)
                    {
                        extrusionDef.directionType = (short)Direction_Type.dtMiddlePlane;
                    }
                    extrusionDef.SetSideParam(true, (short)End_Type.etBlind, depth);

                    extrusionDef.SetSketch(sketch);
                    entityExtr.Create();
                    entityExtr.Update();
                }
            }
            catch
            {
                MessageBox.Show("Operation extrusion wasn't builded.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
