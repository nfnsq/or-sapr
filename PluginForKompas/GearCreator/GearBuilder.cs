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
            ///окружность выступов
            double Da = _list[6].value * (_list[7].value + 2);
            ///делительная окружность
            double D = _list[6].value * _list[7].value;
            ///основная окружность
            double Db = D * Math.Cos(20 * Math.PI / 180);
            ///окружность впадин
            double Df = _list[6].value * (_list[7].value - 2.5);
            ///толщина шестерни
            double gearDepth = _list[6].value * _list[7].value * 0.15;
            
            ///построить цилиндр
            Point center = new Point(0, 0);
            CircleSketch.DrawCircle(center, Da / 2, 1);
            ExtrusionMaker.DoOperationExtrusion(gearDepth);
            Point3d chamfer1 = new Point3d(0, gearDepth / 2, Da / 2);
            ChamferMaker.Create(4, chamfer1);
            Point3d chamfer2 = new Point3d(0, -gearDepth / 2, Da / 2);
            ChamferMaker.Create(4, chamfer2);

            ///вырезать зубъя
            GearTeethSketch.DrawGearTeeth(_list[7].value, _list[6].value);
            HoleMaker.CutExtrusion(gearDepth);
            CircularCopyMaker.CreateOperationCircPartArray((int)_list[7].value);

            ///отверстие 1
            CircleSketch.DrawCircle(center, _list[5].value / 2, 1);
            HoleMaker.CutExtrusion(gearDepth);

            ///отверстя 2-6
            Point holeCoor = new Point(0, Da / 4);
            CircleSketch.DrawCircle(holeCoor, _list[4].value / 2, 1);
            HoleMaker.CutExtrusion(gearDepth);
            CircularCopyMaker.CreateOperationCircPartArray((int)5);

            ///смещение
            KompasApp.MovingBasePlaneByYAxis(gearDepth / 2);

            ///углубление под гайку
            HexagonSketch.DrawHexagon(_list[3].value / 2);
            HoleMaker.CutExtrusion(_list[0].value * 2);

            ///ребра жесткости
            DipSketch.DrawDipSketch(_list[6].value, _list[7].value, _list[1].value);
            HoleMaker.CutExtrusion(_list[2].value * 2);
            double R = 0.9 * Df / 2;
            ///точка на ребре углубления
            Point3d chamfer3 = new Point3d(0, gearDepth / 2, -Da / 8);
            ChamferMaker.Create(4, chamfer3);
            ///точка на ребре углубления
            Point3d chamfer4 = new Point3d(0, gearDepth / 2, -R);
            ChamferMaker.Create(4, chamfer4);
            ///точка на ребре углубления
            Point3d chamfer5 = new Point3d(Math.Cos(54 * Math.PI / 180) * R 
                - _list[1].value / 2 / Math.Sin(54 * Math.PI / 180),
                gearDepth / 2, -Math.Sin(54 * Math.PI / 180) * R);
           
            ChamferMaker.Create(4, chamfer5);
            ///точка на ребре углубления
            Point3d chamfer6 = new Point3d(-Math.Cos(54 * Math.PI / 180) * R 
                + _list[1].value / 2 / Math.Sin(54 * Math.PI / 180),
                gearDepth / 2, -Math.Sin(54 * Math.PI / 180) * R);
            ChamferMaker.Create(4, chamfer6); 
            
            CircularCopyMaker.CreateChamferCircPartArray((int)5);

        }
    }
}
