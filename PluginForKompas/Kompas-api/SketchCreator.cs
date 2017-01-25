using Kompas6Constants3D;
using Kompas6API5;

namespace PluginForKompas
{
    /// <summary>
    /// Класс эскиза
    /// </summary>
    public class SketchCreator
    {
        private KompasApp _app;

        /// <summary>
        /// Коструктор с параметром
        /// </summary>
        /// <param name="app">Приложение компас</param>
        public SketchCreator(KompasApp app)
        {
            this._app = app;
        }

        /// <summary>
        /// Метод создает новый эскиз
        /// </summary>
        /// <returns>Возвращает указатель на интерфейс эскиза</returns>
        public ksSketchDefinition MakeSketch()
        {
            try
            {
                ksEntity entitySketch = (ksEntity)_app.Part.NewEntity((short)Obj3dType.o3d_sketch);
                ksSketchDefinition sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
                sketchDef.SetPlane(_app.BasePlane);
                entitySketch.Create();
                return sketchDef;
            }
            catch
            {
                return null;
            }
        }
    }
}
