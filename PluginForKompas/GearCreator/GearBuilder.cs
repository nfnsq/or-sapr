using System;
using System.Windows;

namespace PluginForKompas
{
    /// <summary>
    /// Класс для построения детали
    /// </summary>
    public class GearBuilder
    {
        /// <summary>
        /// Список параметров детали
        /// </summary>
        private Parameter[] _list = new Parameter[0];

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="list">Список параметров детали</param>
        public GearBuilder(params Parameter[] list)
        {            
            for (int i = 0; i < list.Length; i++)
            {
                Array.Resize<Parameter>(ref _list, i + 1);
                this._list[i] = list[i];
            }
        }

        /// <summary>
        /// Создание нового документа для построения детали
        /// </summary>
        public bool New()
        {
            try
            {
                DataController cntrl = new DataController();
                if (cntrl.Validating(_list))
                {
                    KompasApp.CreateNewDoc();
                    DoDetail();
                    return true;
                }
                else return false;
                
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод, который пошагово строит деталь
        /// </summary>
        private void DoDetail()
        {
            // данные для расчета по ссылке
            // http://edu.ascon.ru/source/files/methods/method_osnovy_autoconstruct.pdf
            double projectionCircle = _list[6].Value * (_list[7].Value + 2);
            double baseCircle = _list[6].Value * _list[7].Value;
            double mainCircle = baseCircle * Math.Cos(20 * Math.PI / 180);
            double troughsCircle = _list[6].Value * (_list[7].Value - 2.5);

            double gearDepth = _list[6].Value * _list[7].Value * 0.15;

            //обьявляем угол 54 в градусах, который будет необходим 
            // для расчетов координат точек ребра жесткости 
            double angle54 = 54 * Math.PI / 180;

            // построить цилиндр
            Point center = new Point(0, 0);
            CircleSketch.DrawCircle(center, projectionCircle / 2, 1);
            ExtrusionMaker.DoOperationExtrusion(gearDepth);
            Point3d chamfer1 = new Point3d(0, gearDepth / 2, projectionCircle / 2);
            ChamferMaker.Create(4, chamfer1);
            Point3d chamfer2 = new Point3d(0, -gearDepth / 2, projectionCircle / 2);
            ChamferMaker.Create(4, chamfer2);

            // вырезать зубъя
            GearTeethSketch.DrawGearTeeth(_list[6].Value,
                baseCircle, mainCircle, projectionCircle, troughsCircle);
            HoleMaker.CutExtrusion(gearDepth);
            CircularCopyMaker.CreateOperationCircPartArray((int)_list[7].Value);

            // отверстие 1
            CircleSketch.DrawCircle(center, _list[5].Value / 2, 1);
            HoleMaker.CutExtrusion(gearDepth);

            // отверстя 2-6
            Point holeCoor = new Point(0, projectionCircle / 4);
            CircleSketch.DrawCircle(holeCoor, _list[4].Value / 2, 1);
            HoleMaker.CutExtrusion(gearDepth);
            CircularCopyMaker.CreateOperationCircPartArray((int)5);

            // смещение
            KompasApp.MovingBasePlaneByYAxis(gearDepth / 2, true);

            // углубление под гайку
            HexagonSketch.DrawHexagon(_list[3].Value / 2);
            HoleMaker.CutExtrusion(_list[0].Value * 2);

            // ребра жесткости
            DipSketch.DrawDipSketch(_list[6].Value, _list[7].Value, _list[1].Value, angle54);
            HoleMaker.CutExtrusion(_list[2].Value * 2);
            double R = 0.9 * troughsCircle / 2;
            // точка на ребре углубления
            Point3d chamfer3 = new Point3d(0, gearDepth / 2, -projectionCircle / 8);
            ChamferMaker.Create(4, chamfer3);
            // точка на ребре углубления
            Point3d chamfer4 = new Point3d(0, gearDepth / 2, -R);
            ChamferMaker.Create(4, chamfer4);
            // точка на ребре углубления
            Point3d chamfer5 = new Point3d(Math.Cos(angle54) * R
                - _list[1].Value / 2 / Math.Sin(angle54),
                gearDepth / 2, -Math.Sin(angle54) * R);

            ChamferMaker.Create(4, chamfer5);
            // точка на ребре углубления
            Point3d chamfer6 = new Point3d(-Math.Cos(angle54) * R
                + _list[1].Value / 2 / Math.Sin(angle54),
                gearDepth / 2, -Math.Sin(angle54) * R);
            ChamferMaker.Create(4, chamfer6);

            CircularCopyMaker.CreateChamferCircPartArray((int)5);

            // смещение
            KompasApp.MovingBasePlaneByYAxis(gearDepth, false);
            // углубление под гайку
            HexagonSketch.DrawHexagon(_list[3].Value / 2);
            HoleMaker.CutExtrusion(_list[0].Value * 2);
            // ребра жесткости
            DipSketch.DrawDipSketch(_list[6].Value, _list[7].Value, _list[1].Value, angle54);
            HoleMaker.CutExtrusion(_list[2].Value * 2);
            // точка на ребре углубления
            Point3d chamfer7 = new Point3d(0, -gearDepth / 2, -projectionCircle / 8);
            ChamferMaker.Create(4, chamfer7);
            // точка на ребре углубления
            Point3d chamfer8 = new Point3d(0, -gearDepth / 2, -R);
            ChamferMaker.Create(4, chamfer8);
            // точка на ребре углубления
            Point3d chamfer9 = new Point3d(Math.Cos(angle54) * R
                - _list[1].Value / 2 / Math.Sin(angle54),
                -gearDepth / 2, -Math.Sin(angle54) * R);

            ChamferMaker.Create(4, chamfer9);
            // точка на ребре углубления
            Point3d chamfer10 = new Point3d(-Math.Cos(angle54) * R
                + _list[1].Value / 2 / Math.Sin(angle54),
                -gearDepth / 2, -Math.Sin(angle54) * R);
            ChamferMaker.Create(4, chamfer10);

            CircularCopyMaker.CreateChamferCircPartArray((int)5);

        }
    }
}
