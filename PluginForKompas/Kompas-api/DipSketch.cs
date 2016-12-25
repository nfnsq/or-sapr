using System;
using Kompas6API5;
using Kompas6Constants;
using System.Windows;

namespace PluginForKompas
{
    /// <summary>
    /// Класс для нарисования эскиза выреза
    /// </summary>
    public static class DipSketch
    {
        /// <summary>
        /// Метод рисует эскиз в виде части сектора
        /// </summary>
        /// <param name="m">Модуль жесткости шестерни</param>
        /// <param name="z">Количество зубьев</param>
        /// <param name="k">Тольщина ребер жесткости</param>
        public static bool DrawDipSketch(double m, double z, double k, double angle54)
        {
            double a0 = KompasApp.Mat.ksAngle(0, 0, 1, 0);
            double a180 = KompasApp.Mat.ksAngle(0, 0, -1, 0);
            double x;
            double y;
            double l = k / 2;
            // диаметр большей дуги углубления
            double D1 = 0.9 * m * (z - 2.5) / 2;
            // диаметр меньшей дуги углубления
            double D2 = m * (z + 2) / 8;
            try
            {
                ksSketchDefinition def = SketchCreator.MakeSketch();
                ksDocument2D doc = (ksDocument2D)def.BeginEdit();
                short mathPoint = (short)StructType2DEnum.ko_MathPointParam;

                ksMathPointParam p1 = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                // задается проекция толщины ребра жесткости на ось Х
                p1.x = -l / Math.Sin(angle54);
                p1.y = 0;

                ///координаты точки на ребре жесткости
                ksMathPointParam p2 = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                p2.x = (Math.Cos(angle54) * m * z)
                    - (l / Math.Sin(angle54));
                p2.y = Math.Sin(angle54) * m * z;
                Point point1 = new Point(p1.x, p1.y);
                Point point2 = new Point(p2.x, p2.y);

                ///координаты точки пересечения большей дуги углубления 
                ///и прямой проходящей вдоль ребра жесткости 
                ksMathPointParam pA = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                PointIntersect.LinArc(point1, point2, D1, a0, a180, pA);

                ///координаты точки пересечения меньшей дуги углубления 
                ///и прямой проходящей вдоль ребра жесткости 
                ksMathPointParam pB = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                PointIntersect.LinArc(point1, point2, D2, a0, a180, pB);

                doc.ksPoint(pB.x, pB.y, 1);
                ksMathPointParam pC = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                KompasApp.Mat.ksSymmetry(pA.x, pA.y, 0, 0, 0, m * (z + 3), out x, out y);
                pC.x = x;
                pC.y = y;

                ksMathPointParam pD = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                KompasApp.Mat.ksSymmetry(pB.x, pB.y, 0, 0, 0, m * (z + 3), out x, out y);
                pD.x = x;
                pD.y = y;

                doc.ksArcByPoint(0, 0, D1, pA.x, pA.y, pC.x, pC.y, 1, 1);
                doc.ksArcByPoint(0, 0, D2, pB.x, pB.y, pD.x, pD.y, 1, 1);
                doc.ksLineSeg(pA.x, pA.y, pB.x, pB.y, 1);
                doc.ksLineSeg(pC.x, pC.y, pD.x, pD.y, 1);

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
