using System;
using Kompas6Constants;
using Kompas6API5;
using System.Windows;

namespace PluginForKompas
{
    /// <summary>
    /// Класс эскиза зубья
    /// </summary>
    public static class GearTeethSketch
    {
        /// <summary>
        /// Метод рисует эскиз для выреза зубьев согласно расчетам в работе 1 по ссылке 
        /// http://edu.ascon.ru/source/files/methods/method_osnovy_autoconstruct.pdf
        /// </summary>
        public static bool DrawGearTeeth(double m, double baseCircle,
            double mainCircle, double projectionCircle, double troughsCircle)
        {
            try
            {
                ksSketchDefinition def = SketchCreator.MakeSketch();
                ksDocument2D doc = (ksDocument2D)def.BeginEdit();
                ///углы
                double angle0 = 0;
                double angle90 = 90;
                double angle180 = 180;
                double angle270 = 270;
                double x;
                double y;
                short mathPoint = (short)StructType2DEnum.ko_MathPointParam;



                ksMathPointParam p1 = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);


                ///точка 1                
                Point point1 = new Point(0, 0);
                Point point2 = new Point(0, projectionCircle);
                PointIntersect.LinArc(point1, point2, baseCircle / 2, angle0, angle180, p1);

                ///точка 2
                point1 = new Point(0, 0);
                point2 = new Point(p1.x, p1.y);
                ksMathPointParam p2 = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                PointIntersect.ArcArc(point1, baseCircle / 2, angle0, angle180,
                                        point2, 0.5 * Math.PI * m, angle90, angle270, p2);

                ///точка 3
                point2 = new Point(p2.x, p2.y);
                ksMathPointParam p3 = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                PointIntersect.ArcArc(point1, mainCircle / 2,
                                        angle0, angle180, point2, baseCircle / 6, angle270, angle90, p3);

                ///точка C
                point2 = new Point(p3.x, p3.y);
                ksMathPointParam pC = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                PointIntersect.ArcArc(point1, projectionCircle / 2, angle0, angle180,
                                        point2, baseCircle / 6, angle90, angle270, pC);

                ///точка 4
                ksMathPointParam p4 = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                PointIntersect.ArcArc(point1, mainCircle / 2, angle0, angle180,
                                        point2, baseCircle / 6, angle90, angle270, p4);


                ///точка F
                point2 = new Point(p4.x, p4.y);
                ksMathPointParam pF = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                PointIntersect.LinArc(point1, point2,
                                        troughsCircle / 2, angle0, angle180, pF);

                ///точка 5
                point2 = new Point(p1.x, p1.y);
                ksMathPointParam p5 = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                PointIntersect.ArcArc(point1, baseCircle / 2, angle0, angle180,
                                        point2, 0.75 * Math.PI * m, angle90, angle270, p5);

                ///точка А
                ksMathPointParam pA = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                KompasApp.Mat.ksSymmetry(pC.x, pC.y, 0, 0, p5.x, p5.y, out x, out y);
                pA.x = x;
                pA.y = y;

                ///точка D
                ksMathPointParam pD = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                KompasApp.Mat.ksSymmetry(pF.x, pF.y, 0, 0, p5.x, p5.y, out x, out y);
                pD.x = x;
                pD.y = y;

                ///точка 3'
                ksMathPointParam p3s = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                KompasApp.Mat.ksSymmetry(p3.x, p3.y, 0, 0, p5.x, p5.y, out x, out y);
                p3s.x = x;
                p3s.y = y;

                ///точка 4'
                ksMathPointParam p4s = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                KompasApp.Mat.ksSymmetry(p4.x, p4.y, 0, 0, p5.x, p5.y, out x, out y);
                p4s.x = x;
                p4s.y = y;

                ksMathPointParam p0 = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                p0.x = 0;
                p0.y = 0;

                doc.ksArcByPoint(p3.x, p3.y, baseCircle / 6, pC.x, pC.y, p4.x, p4.y, 1, 1);
                doc.ksArcByPoint(p3s.x, p3s.y, baseCircle / 6, p4s.x, p4s.y, pA.x, pA.y, 1, 1);
                doc.ksArcByPoint(p0.x, p0.y, troughsCircle / 2, pF.x, pF.y, pD.x, pD.y, 1, 1);
                doc.ksArcByPoint(p0.x, p0.y, projectionCircle / 2, pC.x, pC.y, pA.x, pA.y, 1, 1);
                doc.ksLineSeg(p4.x, p4.y, pF.x, pF.y, 1);
                doc.ksLineSeg(p4s.x, p4s.y, pD.x, pD.y, 1);

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