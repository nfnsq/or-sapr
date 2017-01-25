using Kompas6API5;
using System.Windows;

namespace PluginForKompas
{
    /// <summary>
    /// Класс рисования окружности
    /// </summary>
    public class CircleSketch
    {
        private KompasApp _app;

        /// <summary>
        /// Коструктор с параметром
        /// </summary>
        /// <param name="app">Приложение компас</param>
        public CircleSketch(KompasApp app)
        {
            this._app = app;
        }

        /// <summary>
        /// Метод создает эскиз окружности
        /// </summary>
        /// <param name="coor">Координаты центра окружности</param>
        /// <param name="radius">Радиус окружности</param>
        /// <param name="lineType">Тип линии</param>
        /// <returns></returns>
        public bool DrawCircle(Point coor, double radius, int lineType)
        {
            try
            {
                SketchCreator sketchCreator = new SketchCreator(_app);
                ksSketchDefinition def = sketchCreator.MakeSketch();
                ksDocument2D doc = (ksDocument2D)def.BeginEdit();
                doc.ksCircle(coor.X, coor.Y, radius, lineType);
                def.EndEdit();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
