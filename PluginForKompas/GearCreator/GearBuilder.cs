using System;
using System.Windows;
using PluginForKompas;

namespace PluginForKompas
{
    /// <summary>
    /// Класс для построения детали
    /// </summary>
    public class GearBuilder
    {
        // параметры детали
        private Parameter[] _parameters = new Parameter[0];
        // данные для расчета по ссылке
        // http://edu.ascon.ru/source/files/methods/method_osnovy_autoconstruct.pdf
        private double _projectionCircle;
        private double _baseCircle;
        private double _mainCircle;
        private double _troughsCircle;
        private double _internalArcOfDipDiam;
        private double _externalArcOfDipDiam;
        private double _gearDepth;
        private KompasApp _app; 
        private double _chamferWidth = 10;
        // обьявляем угол 54 в градусах, который будет необходим 
        // для расчетов координат точек ребра жесткости 
        private double _angle54 = 54 * Math.PI / 180;

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="parameters">Список параметров детали</param>
        public GearBuilder(KompasApp app, params Parameter[] parameters)
        {            
            for (int i = 0; i < parameters.Length; i++)
            {
                Array.Resize<Parameter>(ref _parameters, i + 1);
                this._parameters[i] = parameters[i];
            }
            this._projectionCircle = _parameters[6].Value * (_parameters[7].Value + 2);
            this._baseCircle = _parameters[6].Value * _parameters[7].Value;
            this._mainCircle = _baseCircle * Math.Cos(20 * Math.PI / 180);
            this._troughsCircle = _parameters[6].Value * (_parameters[7].Value - 2.5);
            // диаметр внутренней дуги углубления задаем как 1/4 от окружности выступов
            this._internalArcOfDipDiam = 0.25 * _parameters[6].Value * (_parameters[7].Value + 2);
            // диаметр внешней дуги углубления задаем как 9/10 от окружности впадин
            this._externalArcOfDipDiam = 0.9 * _parameters[6].Value * (_parameters[7].Value - 2.5);
            this._gearDepth = _parameters[6].Value * _parameters[7].Value * 0.15;
            this._app = app;
        }

        /// <summary>
        /// Создание нового документа для построения детали
        /// </summary>
        public bool CreateGear()
        {
            try
            {
                DataController cntrl = new DataController();
                if (cntrl.Validating(_internalArcOfDipDiam, 
                    _externalArcOfDipDiam, _chamferWidth, _gearDepth, _parameters))
                {
                    _app.CreateNewDoc();
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
            // построить цилиндр
            Point center = new Point(0, 0);
            CircleSketch circleSketch = new CircleSketch(_app);
            circleSketch.DrawCircle(center, _projectionCircle / 2, 1);
            ExtrusionMaker extrusionMaker = new ExtrusionMaker(_app);
            extrusionMaker.DoOperationExtrusion(_gearDepth);
            Point3d chamfer1 = new Point3d(0, _gearDepth / 2, _projectionCircle / 2);
            ChamferMaker chamferMaker = new ChamferMaker(_app);
            chamferMaker.Create(4, chamfer1);
            Point3d chamfer2 = new Point3d(0, -_gearDepth / 2, _projectionCircle / 2);
            chamferMaker.Create(4, chamfer2);

            // вырезать зубъя
            GearTeethSketch gearSketch = new GearTeethSketch(_app);
            gearSketch.DrawGearTeeth(_parameters[6].Value,
                _baseCircle, _mainCircle, _projectionCircle, _troughsCircle);
            HoleMaker holeMaker = new HoleMaker(_app);
            holeMaker.CutExtrusion(_gearDepth);
            CircularCopyMaker circularCopyMaker = new CircularCopyMaker(_app);
            circularCopyMaker.CreateOperationCircPartArray((int)_parameters[7].Value);

            // отверстие 1
            circleSketch.DrawCircle(center, _parameters[5].Value / 2, 1);
            holeMaker.CutExtrusion(_gearDepth);

            // отверстя 2-6
            Point holeCoor = new Point(0, (_externalArcOfDipDiam + _internalArcOfDipDiam) / 4);
            circleSketch.DrawCircle(holeCoor, _parameters[4].Value / 2, 1);
            holeMaker.CutExtrusion(_gearDepth);
            circularCopyMaker.CreateOperationCircPartArray((int)5);

            // смещение
            AxisChanger changer = new AxisChanger(_app);
            changer.MovingBasePlaneByYAxis(_gearDepth / 2, true);

            // углубление под гайку
            HexagonSketch hexagonSketch = new HexagonSketch(_app);
            hexagonSketch.DrawHexagon(_parameters[3].Value / 2);
            holeMaker.CutExtrusion(_parameters[0].Value * 2);

            // ребра жесткости
            DipSketch dipSketch = new DipSketch(_app);
            dipSketch.DrawDipSketch(_internalArcOfDipDiam / 2, _externalArcOfDipDiam / 2, 
                _parameters[6].Value, _parameters[7].Value, _parameters[2].Value, _angle54);
            holeMaker.CutExtrusion(_parameters[1].Value * 2);
            double R = 0.9 * _troughsCircle / 2;
            // точка на ребре жесткости
            Point3d chamfer3 = new Point3d(0, _gearDepth / 2, -_projectionCircle / 8);
            chamferMaker.Create(4, chamfer3);
            // точка на ребре жесткости
            Point3d chamfer4 = new Point3d(0, _gearDepth / 2, -R);
            chamferMaker.Create(4, chamfer4);
            // точка на ребре жесткости
            Point3d chamfer5 = new Point3d(Math.Cos(_angle54) * R
                - _parameters[1].Value / 2 / Math.Sin(_angle54),
                _gearDepth / 2, -Math.Sin(_angle54) * R);
            chamferMaker.Create(4, chamfer5);
            // точка на ребре жесткости
            Point3d chamfer6 = new Point3d(-Math.Cos(_angle54) * R
                + _parameters[1].Value / 2 / Math.Sin(_angle54),
                _gearDepth / 2, -Math.Sin(_angle54) * R);
            chamferMaker.Create(4, chamfer6);
            circularCopyMaker.CreateChamferCircPartArray((int)5);

            // смещение оси
            changer = new AxisChanger(_app);
            changer.MovingBasePlaneByYAxis(_gearDepth, false);

            // углубление под гайку
            hexagonSketch.DrawHexagon(_parameters[3].Value / 2);
            holeMaker.CutExtrusion(_parameters[0].Value * 2);

            // ребра жесткости с другой стороны
            dipSketch.DrawDipSketch(_internalArcOfDipDiam / 2, _externalArcOfDipDiam / 2, 
                _parameters[6].Value, _parameters[7].Value, _parameters[2].Value, _angle54);
            holeMaker.CutExtrusion(_parameters[1].Value * 2);
            // точка на ребре жесткости
            Point3d chamfer7 = new Point3d(0, -_gearDepth / 2, -_projectionCircle / 8);
            chamferMaker.Create(4, chamfer7);
            // точка на ребре жесткости
            Point3d chamfer8 = new Point3d(0, -_gearDepth / 2, -R);
            chamferMaker.Create(4, chamfer8);
            // точка на ребре жесткости
            Point3d chamfer9 = new Point3d(Math.Cos(_angle54) * R
                - _parameters[1].Value / 2 / Math.Sin(_angle54),
                -_gearDepth / 2, -Math.Sin(_angle54) * R);
            chamferMaker.Create(4, chamfer9);
            // точка на ребре жесткости
            Point3d chamfer10 = new Point3d(-Math.Cos(_angle54) * R
                + _parameters[1].Value / 2 / Math.Sin(_angle54),
                -_gearDepth / 2, -Math.Sin(_angle54) * R);
            chamferMaker.Create(4, chamfer10);
            circularCopyMaker.CreateChamferCircPartArray((int)5);

        }
    }
}
