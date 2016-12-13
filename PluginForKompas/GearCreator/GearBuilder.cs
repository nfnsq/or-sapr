using System;

namespace PluginForKompas
{
    public class GearBuilder
    {
        private double d1 = 22;
        private double d2 = 27.5;
        private double d3 = 36;
        private double a = 12;
        private double b = 20;
        private double h = 20;
        private double z = 20;
        private double m = 10;

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
            CircleSketch.DrawCircle(0, 0, m * (z + 2) / 2, 1);
            ExtrusionMaker.DoOperationExtrusion(m * z * 0.15);
            ChamferMaker.Create(4, 0, m * z * 0.15 / 2, m * (z + 2) / 2);
            ChamferMaker.Create(4, 0, - m * z * 0.15 / 2, - m * (z + 2) / 2);

            GearTeethSketch.DrawGearTeeth(z, m);
            HoleMaker.CutExtrusion(m * z * 0.15);
            CircularCopyMaker.CreateOperationCircPartArray((int)z);

            CircleSketch.DrawCircle(0, 0, d1 / 2, 1);
            HoleMaker.CutExtrusion(m * z * 0.15);

            CircleSketch.DrawCircle(0, m * (z + 2) / 4, d2 / 2, 1);
            HoleMaker.CutExtrusion(m * z * 0.15);
            CircularCopyMaker.CreateOperationCircPartArray((int)5);

            KompasApp.MovingBasePlaneByYAxis(m * z * 0.15 / 2);

            HexagonSketch.DrawHexagon(d3 / 2);
            HoleMaker.CutExtrusion(2 * h);

            DipSketch.DrawDipSketch(m, z, a / 2);
            HoleMaker.CutExtrusion(2 * b);
            ChamferMaker.Create(4, 0, m * z * 0.075, -m * (z + 2) / 8);

            double R = 0.9 * m * (z - 2.5) / 2;
            ChamferMaker.Create(4, 0, m * z * 0.075, -R);
            ChamferMaker.Create(4, 
                Math.Cos(54 * Math.PI / 180) * R - a / 2 / Math.Sin(54 * Math.PI /180),
                m * z * 0.075, -Math.Sin(54 * Math.PI / 180) * R);
            ChamferMaker.Create(4,
                - Math.Cos(54 * Math.PI / 180) * R + a / 2 / Math.Sin(54 * Math.PI / 180),
                m * z * 0.075, -Math.Sin(54 * Math.PI / 180) * R); 
            
            CircularCopyMaker.CreateChamferCircPartArray((int)5);

        }
    }
}
