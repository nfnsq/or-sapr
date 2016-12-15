using Kompas6API5;
using System.Windows.Forms;
using Kompas6Constants3D;

namespace PluginForKompas
{
    /// <summary>
    /// Класс рисования окружности
    /// </summary>
    public static class CircleSketch
    {
        /// <summary>
        /// Метод создает эскиз окружности
        /// </summary>
        /// <param name="centerCoordinateX">Координата х центра окружности</param>
        /// <param name="centerCoordinateY">Координата у центра окружности</param>
        /// <param name="radius">Радиус окружности</param>
        /// <param name="lineType">Стиль линии</param>
        public static void DrawCircle(double centerCoordinateX,
                                          double centerCoordinateY, 
                                          double radius, int lineType)
        {
            try
            {
                ksSketchDefinition def = SketchCreator.MakeSketch();
                ksDocument2D doc = (ksDocument2D)def.BeginEdit();
                doc.ksCircle(centerCoordinateX, centerCoordinateY, radius, lineType);
                def.EndEdit();
            }
            catch
            {
                MessageBox.Show("Circle sketch wasn't draw.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
