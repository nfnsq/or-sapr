using System;

namespace PluginForKompas
{
    public class GearBuilder
    {
        private double[] _list = new double[0];

        public GearBuilder(params double[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Array.Resize<double>(ref _list, i + 1);
                this._list[i] = list[i];
            }
        }

        public void New()
        {
            KompasApp.CreateNewDoc();
            DoDetail();
        }

        public void Update()
        {
            KompasApp.GetActiveDoc();
            DoDetail();
        }

        private void DoDetail()
        {
            ///окружность выступов
            double Da = _list[6] * (_list[7] + 2);
            ///делительная окружность
            double D = _list[6] * _list[7];
            ///основная окружность
            double Db = D * Math.Cos(20 * Math.PI / 180);
            ///окружность впадин
            double Df = _list[6] * (_list[7] - 2.5);
            ///толщина шестерни
            double gearDepth = _list[6] * _list[7] * 0.15;
            
            ///построить цилиндр
            CircleSketch.DrawCircle(0, 0, Da / 2, 1);
            ExtrusionMaker.DoOperationExtrusion(gearDepth);
            ChamferMaker.Create(4, 0, gearDepth / 2, Da / 2);
            ChamferMaker.Create(4, 0, -gearDepth / 2, -Da / 2);

            ///вырезать зубъя
            GearTeethSketch.DrawGearTeeth(_list[7], _list[6]);
            HoleMaker.CutExtrusion(gearDepth);
            CircularCopyMaker.CreateOperationCircPartArray((int)_list[7]);

            ///отверстие 1
            CircleSketch.DrawCircle(0, 0, _list[5] / 2, 1);
            HoleMaker.CutExtrusion(gearDepth);

            ///отверстя 2-6
            CircleSketch.DrawCircle(0, Da / 4, _list[4] / 2, 1);
            HoleMaker.CutExtrusion(gearDepth);
            CircularCopyMaker.CreateOperationCircPartArray((int)5);

            ///смещение
            KompasApp.MovingBasePlaneByYAxis(gearDepth / 2);

            ///углубление под гайку
            HexagonSketch.DrawHexagon(_list[3] / 2);
            HoleMaker.CutExtrusion(_list[0] * 2);

            ///ребра жесткости
            DipSketch.DrawDipSketch(_list[6], _list[7], _list[1]);
            HoleMaker.CutExtrusion(_list[2] * 2);
            double R = 0.9 * Df / 2;
            ChamferMaker.Create(4, 0, gearDepth / 2, -Da / 8);
            ChamferMaker.Create(4, 0, gearDepth / 2, -R);

            ChamferMaker.Create(4,
                Math.Cos(54 * Math.PI / 180) * R - _list[1] / 2 / Math.Sin(54 * Math.PI / 180),
                gearDepth / 2, -Math.Sin(54 * Math.PI / 180) * R);
            ChamferMaker.Create(4,
                -Math.Cos(54 * Math.PI / 180) * R + _list[1] / 2 / Math.Sin(54 * Math.PI / 180),
                gearDepth / 2, -Math.Sin(54 * Math.PI / 180) * R); 
            
            CircularCopyMaker.CreateChamferCircPartArray((int)5);

        }
    }
}
