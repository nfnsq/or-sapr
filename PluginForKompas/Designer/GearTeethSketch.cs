using System;
using Kompas6Constants;
using Kompas6API5;
using KAPITypes;

namespace PluginForKompas
{
    public static class GearTeethSketch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="z"></param>
        /// <param name="m"></param>
        public static void DrawGearTeeth(double z, double m)
        {
            ksSketchDefinition def = SketchCreator.MakeSketch();
            ksDocument2D doc = (ksDocument2D)def.BeginEdit();
            ///углы
            double a0 = KompasApp.mat.ksAngle(0, 0, 1, 0);
            double a90 = KompasApp.mat.ksAngle(0, 0, 0, 1);
            double a180 = KompasApp.mat.ksAngle(0, 0, -1, 0);
            double a270 = KompasApp.mat.ksAngle(0, 0, 0, -1);
            double x;
            double y;
            short mathPoint = (short)StructType2DEnum.ko_MathPointParam;



            ksMathPointParam p1 = (ksMathPointParam)KompasApp.kompas.GetParamStruct(mathPoint);

            ///точка 1
            GetPointIntersect.LinArc(0, 0, 0, m * (z + 3), (m * z) / 2, a0, a180, p1);

            ///точка 2
            ksMathPointParam p2 = (ksMathPointParam)KompasApp.kompas.GetParamStruct(mathPoint);
            GetPointIntersect.ArcArc(0, 0, m * z / 2, a0, a180,
                                    p1.x, p1.y, 0.5 * Math.PI * m, a90, a270, p2);

            ///точка 3
            ksMathPointParam p3 = (ksMathPointParam)KompasApp.kompas.GetParamStruct(mathPoint);
            GetPointIntersect.ArcArc(0, 0, m * z * Math.Cos(20 * Math.PI / 180) / 2,
                                    a0, a180, p2.x, p2.y, m * z / 6, a270, a90, p3);

            ///точка C
            ksMathPointParam pC = (ksMathPointParam)KompasApp.kompas.GetParamStruct(mathPoint);
            GetPointIntersect.ArcArc(0, 0, m * (z + 2) / 2, a0, a180,
                                    p3.x, p3.y, m * z / 6, a90, a270, pC);

            ///точка 4
            ksMathPointParam p4 = (ksMathPointParam)KompasApp.kompas.GetParamStruct(mathPoint);
            GetPointIntersect.ArcArc(0, 0, m * z * Math.Cos(20 * Math.PI / 180) / 2, a0, a180,
                                    p3.x, p3.y, m * z / 6, a90, a270, p4);

                        
            ///точка F
            ksMathPointParam pF = (ksMathPointParam)KompasApp.kompas.GetParamStruct(mathPoint);
            GetPointIntersect.LinArc(0, 0, p4.x, p4.y,
                                    m * (z - 2.5) / 2, a0, a180, pF);

            ///точка 5
            ksMathPointParam p5 = (ksMathPointParam)KompasApp.kompas.GetParamStruct(mathPoint);
            GetPointIntersect.ArcArc(0, 0, m * z / 2, a0, a180,
                                    p1.x, p1.y, 0.75 * Math.PI * m, a90, a270, p5);

            ///точка А
            ksMathPointParam pA = (ksMathPointParam)KompasApp.kompas.GetParamStruct(mathPoint);
            KompasApp.mat.ksSymmetry(pC.x, pC.y, 0, 0, p5.x, p5.y, out x, out y);
            pA.x = x;
            pA.y = y;

            ///точка D
            ksMathPointParam pD = (ksMathPointParam)KompasApp.kompas.GetParamStruct(mathPoint);
            KompasApp.mat.ksSymmetry(pF.x, pF.y, 0, 0, p5.x, p5.y, out x, out y);
            pD.x = x;
            pD.y = y;

            ///точка 3'
            ksMathPointParam p3s = (ksMathPointParam)KompasApp.kompas.GetParamStruct(mathPoint);
            KompasApp.mat.ksSymmetry(p3.x, p3.y, 0, 0, p5.x, p5.y, out x, out y);
            p3s.x = x;
            p3s.y = y;

            ///точка 4'
            ksMathPointParam p4s = (ksMathPointParam)KompasApp.kompas.GetParamStruct(mathPoint);
            KompasApp.mat.ksSymmetry(p4.x, p4.y, 0, 0, p5.x, p5.y, out x, out y);
            p4s.x = x;
            p4s.y = y;

            ksMathPointParam p0 = (ksMathPointParam)KompasApp.kompas.GetParamStruct(mathPoint);
            p0.x = 0;
            p0.y = 0;

            doc.ksArcByPoint(p3.x, p3.y, m * z / 6, pC.x, pC.y, p4.x, p4.y, 1, 1);
            doc.ksArcByPoint(p3s.x, p3s.y, m * z / 6, p4s.x, p4s.y, pA.x, pA.y, 1, 1);
            doc.ksArcByPoint(p0.x, p0.y, m * (z - 2.5) / 2, pF.x, pF.y, pD.x, pD.y, 1, 1);
            doc.ksArcByPoint(p0.x, p0.y, m * (z + 2) / 2, pC.x, pC.y, pA.x, pA.y, 1, 1);
            doc.ksLineSeg(p4.x, p4.y, pF.x, pF.y, 1);
            doc.ksLineSeg(p4s.x, p4s.y, pD.x, pD.y, 1);

            def.EndEdit();
        }
    }
}