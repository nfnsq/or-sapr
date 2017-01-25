using Kompas6API5;
using Kompas6Constants3D;

namespace PluginForKompas
{
    /// <summary>
    /// Класс операции вырезать выдавливанием
    /// </summary>
    public class HoleMaker
    {
        private KompasApp _app;

        /// <summary>
        /// Коструктор с параметром
        /// </summary>
        /// <param name="app">Приложение компас</param>
        public HoleMaker(KompasApp app)
        {
            this._app = app;
        }

        /// <summary>
        /// Метод выполняет операцию вырезать выдавливанием для 
        /// последнего созданного эскиза
        /// </summary>
        /// <param name="depth">Глубина выдавливания</param>
        public bool CutExtrusion(double depth)
        {
            try
            {
                ksEntityCollection coll = (ksEntityCollection)_app.Part.EntityCollection((short)Obj3dType.o3d_sketch);
                int i = coll.GetCount();
                ksEntity sketch = coll.GetByIndex(i - 1);
                ksEntity entityCutExtr = (ksEntity)_app.Part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
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
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
