using Kompas6API5;
using Kompas6Constants3D;

namespace PluginForKompas
{
    /// <summary>
    /// Класс операции выдавливания
    /// </summary>
    public static class ExtrusionMaker
    {
        /// <summary>
        /// Метод выполняет операцию выдавливания 
        /// для последнего созданного эскиза
        /// </summary>
        /// <param name="depth">Глубина выдавливания</param>
        public static bool DoOperationExtrusion(double depth)
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
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
