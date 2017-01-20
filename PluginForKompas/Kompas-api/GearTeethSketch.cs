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
        private static Point[] _pointArray = new Point[0];
        private static ksMathPointParam[] _mathPointArray = new ksMathPointParam[0];
        private static int _pointArraySize = 0;
        private static int _mathPointArraySize = 0;
        private static short _linArc = 1;
        private static short _arcArc = 2;

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
                // углы
                double[] angle = new double[4] { 0, 90, 180, 270};
                
                _pointArraySize = 1;
                Array.Resize<Point>(ref _pointArray, _pointArraySize);
                _pointArray[0] = new Point(0, 0);

                // точка 1
                double[] parameters = new double[] {0, projectionCircle, baseCircle / 2, angle[0], angle[2]};
                GetPointIntersect(_linArc, parameters);

                // точка 2
                parameters = new double[] { _mathPointArray[0].x, _mathPointArray[0].y,
                    baseCircle / 2, angle[0], angle[2], 
                    0.5 * Math.PI * m, angle[1], angle[3]};
                GetPointIntersect(_arcArc, parameters);
                

                // точка 3
                parameters = new double[] {
                    _mathPointArray[_mathPointArraySize - 1].x, _mathPointArray[_mathPointArraySize - 1].y, 
                    mainCircle / 2, angle[0], angle[2], baseCircle / 6, angle[3], angle[1]};
                GetPointIntersect(_arcArc, parameters);
                
                // точка С
                parameters = new double[] {
                    _mathPointArray[_mathPointArraySize - 1].x, _mathPointArray[_mathPointArraySize - 1].y, 
                    projectionCircle / 2, angle[0], angle[2], baseCircle / 6, angle[1], angle[3]};
                GetPointIntersect(_arcArc, parameters);

                // точка 4
                parameters = new double[] {
                    _mathPointArray[_mathPointArraySize - 2].x, _mathPointArray[_mathPointArraySize - 2].y, 
                    mainCircle / 2, angle[0], angle[2], baseCircle / 6, angle[1], angle[3]};
                GetPointIntersect(_arcArc, parameters);
                 
                // точка F
                parameters = new double[] { 
                    _mathPointArray[_mathPointArraySize - 1].x, _mathPointArray[_mathPointArraySize - 1].y,
                    troughsCircle / 2, angle[0], angle[2]};
                GetPointIntersect(_linArc, parameters);


                // точка 5
                parameters = new double[] {
                    _mathPointArray[0].x, _mathPointArray[0].y,
                    baseCircle / 2, angle[0], angle[2], 0.75 * Math.PI * m, angle[1], angle[3]};
                GetPointIntersect(_arcArc, parameters);
                

                // точка А
                GetSymmetry(3);

                // точка D
                GetSymmetry(5);

                // точка 3'
                GetSymmetry(2);

                // точка 4'
                GetSymmetry(4);

                _mathPointArraySize++;
                Array.Resize<ksMathPointParam>(ref _mathPointArray, _mathPointArraySize);
                short mathPoint = (short)StructType2DEnum.ko_MathPointParam;
                _mathPointArray[_mathPointArraySize - 1] = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
                _mathPointArray[_mathPointArraySize - 1].x = 0;
                _mathPointArray[_mathPointArraySize - 1].y = 0;

                doc.ksArcByPoint(_mathPointArray[2].x, _mathPointArray[2].y, baseCircle / 6, 
                    _mathPointArray[3].x, _mathPointArray[3].y, _mathPointArray[4].x, _mathPointArray[4].y, 1, 1);
                doc.ksArcByPoint(_mathPointArray[9].x, _mathPointArray[9].y, baseCircle / 6, 
                    _mathPointArray[10].x, _mathPointArray[10].y, _mathPointArray[7].x, _mathPointArray[7].y, 1, 1);
                doc.ksArcByPoint(_mathPointArray[11].x, _mathPointArray[11].y, troughsCircle / 2, 
                    _mathPointArray[5].x, _mathPointArray[5].y, _mathPointArray[8].x, _mathPointArray[8].y, 1, 1);
                doc.ksArcByPoint(_mathPointArray[11].x, _mathPointArray[11].y, projectionCircle / 2, 
                    _mathPointArray[3].x, _mathPointArray[3].y, _mathPointArray[7].x, _mathPointArray[7].y, 1, 1);
                doc.ksLineSeg(_mathPointArray[4].x, _mathPointArray[4].y, _mathPointArray[5].x, _mathPointArray[5].y, 1);
                doc.ksLineSeg(_mathPointArray[10].x, _mathPointArray[10].y, _mathPointArray[8].x, _mathPointArray[8].y, 1);

                def.EndEdit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод для нахождения точки пересечения
        /// </summary>
        private static void GetPointIntersect(short type, double[] parameters)
        {
            short mathPoint = (short)StructType2DEnum.ko_MathPointParam;

            _mathPointArraySize++;
            Array.Resize<ksMathPointParam>(ref _mathPointArray, _mathPointArraySize);
            _mathPointArray[_mathPointArraySize - 1] = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);

            _pointArraySize++;
            Array.Resize<Point>(ref _pointArray, _pointArraySize);
            _pointArray[_pointArraySize - 1] = new Point(parameters[0], parameters[1]);
            if (type == _linArc)
                PointIntersect.LinArc(_pointArray[0], 
                    _pointArray[_pointArraySize - 1], parameters[2], parameters[3], parameters[4], 
                    _mathPointArray[_mathPointArraySize - 1]);
            if (type == _arcArc)
                PointIntersect.ArcArc(_pointArray[0], parameters[2], parameters[3], parameters[4],
                    _pointArray[_pointArraySize - 1], parameters[5], parameters[6], parameters[7],
                    _mathPointArray[_mathPointArraySize - 1]);
        }
        
        /// <summary>
        /// Метод для нахождения симметричной точки
        /// </summary>
        private static void GetSymmetry(int index)
        {
            short mathPoint = (short)StructType2DEnum.ko_MathPointParam;

            _mathPointArraySize++;
            Array.Resize<ksMathPointParam>(ref _mathPointArray, _mathPointArraySize);
            _mathPointArray[_mathPointArraySize - 1] = (ksMathPointParam)KompasApp.Kompas.GetParamStruct(mathPoint);
            
            double x;
            double y;
            KompasApp.Mat.ksSymmetry(_mathPointArray[index].x, _mathPointArray[index].y, 0, 0,
                _mathPointArray[6].x, _mathPointArray[6].y, out x, out y);
            _mathPointArray[_mathPointArraySize - 1].x = x;
            _mathPointArray[_mathPointArraySize - 1].y = y;
        }
    }
}