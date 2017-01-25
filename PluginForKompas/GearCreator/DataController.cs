using System;
using System.Windows.Forms;
using PluginForKompas;
using System.Collections.Generic;

namespace PluginForKompas
{
    /// <summary>
    /// Сущность для проверки входных данных
    /// </summary>
    public class DataController
    {
        private double _teethCount;
        private double _centerHoleDiam;
        
        /// <summary>
        /// Метод проверяет список параметров
        /// </summary>
        /// <param name="internalArcOfDipDiam"></param>
        /// <param name="externalArcOfDipDiam"></param>
        /// <param name="chamferWidth"></param>
        /// <param name="gearDepth"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Validating(double internalArcOfDipDiam, double externalArcOfDipDiam,
            double chamferWidth, double gearDepth, params Parameter[] data)
        {
            _teethCount = data[7].Value;
            _centerHoleDiam = data[5].Value;
            var tuple = new Dictionary<string, Tuple<double, double>>();
            tuple.Add(PluginForKompas.Properties.Resources.Count, new Tuple<double,double> (17, 40));
            tuple.Add(PluginForKompas.Properties.Resources.Rigidity, new Tuple<double, double>(4, 50));
            double max = (internalArcOfDipDiam - chamferWidth) * Math.Cos(30 * Math.PI / 180);
            tuple.Add(PluginForKompas.Properties.Resources.CenterHole, new Tuple<double, double>(5, max));
            max = (externalArcOfDipDiam + internalArcOfDipDiam) / 4;
            tuple.Add(PluginForKompas.Properties.Resources.CircumentalHoles, new Tuple<double, double>(5, max));

            double min = _centerHoleDiam / Math.Cos(30 * Math.PI / 180);
            max = internalArcOfDipDiam - 2 * chamferWidth;
            tuple.Add(PluginForKompas.Properties.Resources.HexagonDiameter, new Tuple<double, double>(min, max));

            max = gearDepth / 2;
            tuple.Add(PluginForKompas.Properties.Resources.HexagonDepth, new Tuple<double, double>(0, max));

            tuple.Add(PluginForKompas.Properties.Resources.StiffenerWidth, new Tuple<double, double>(12, 22));
            tuple.Add(PluginForKompas.Properties.Resources.StiffenerDepth, new Tuple<double, double>(0, max));

            for (int i = 0; i < tuple.Count; i++)
            {
                var tmp = tuple[data[i].Descrpiption];
                if (!CheckData(data[i], tmp.Item1, tmp.Item2))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Метод проверяет попадает ли значение параметра в допустимый интервал
        /// </summary>
        /// <param name="data">Проверяемый параметр</param>
        /// <param name="min">Минимальное значение параметра</param>
        /// <param name="max">Максимальное значение параметра</param>
        /// <returns></returns>
        private bool CheckData(Parameter data, double min, double max)
        {
            if ((data.Value < min)||(data.Value > max))
            {
                #if !DEBUG
                MessageBox.Show("Invalid data "+ data.Descrpiption +". Please, try again. " +
                "Enter number between " + Math.Round(min) + " and " + Math.Round(max) + ".", 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                #endif
                return false;
            }
            else if (double.IsNaN(data.Value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
