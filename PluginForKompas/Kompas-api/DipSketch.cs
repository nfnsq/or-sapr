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
        public static bool DrawDipSketch(double internalArcOfDipRadius, double externalArcOfDipRadius,
            double m, double z, double k, double angle54)
        {
            double a0 = KompasApp.Mat.ksAngle(0, 0, 1, 0);
            double a180 = KompasApp.Mat.ksAngle(0, 0, -1, 0);
            double x;
            double y;
            double l = k / 2;
            // диаметр большей дуги углубления
            // диаметр меньшей дуги углубления
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
                    + p1.x;
                p2.y = Math.Sin(angle54) * m * z;
                Point point1 = new Point(p1.x, p1.y);
                Point point2 = new Point(p2.x, p2.y);

                ///координаты точки пересечения большей дуги углубления 
                ///и прямой проходящей вдоль ребра жесткости 
                ksMathPointParam pA = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                PointIntersect.LinArc(point1, point2, internalArcOfDipRadius, a0, a180, pA);

                ///координаты точки пересечения меньшей дуги углубления 
                ///и прямой проходящей вдоль ребра жесткости 
                ksMathPointParam pB = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                PointIntersect.LinArc(point1, point2, externalArcOfDipRadius, a0, a180, pB);

                double lineSegY = m * (z + 3);
                doc.ksPoint(pB.x, pB.y, 1);
                ksMathPointParam pC = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                KompasApp.Mat.ksSymmetry(pA.x, pA.y, 0, 0, 0, lineSegY, out x, out y);
                pC.x = x;
                pC.y = y;

                ksMathPointParam pD = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                KompasApp.Mat.ksSymmetry(pB.x, pB.y, 0, 0, 0, lineSegY, out x, out y);
                pD.x = x;
                pD.y = y;

                doc.ksArcByPoint(0, 0, internalArcOfDipRadius, pA.x, pA.y, pC.x, pC.y, 1, 1);
                doc.ksArcByPoint(0, 0, externalArcOfDipRadius, pB.x, pB.y, pD.x, pD.y, 1, 1);
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
