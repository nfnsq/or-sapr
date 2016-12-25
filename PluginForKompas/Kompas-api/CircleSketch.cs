﻿using Kompas6API5;
using System.Windows;

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
        public static bool DrawCircle(Point coor, double radius, int lineType)
        {
            try
            {
                ksSketchDefinition def = SketchCreator.MakeSketch();
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