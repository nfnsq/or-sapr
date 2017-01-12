using System;
using System.Windows.Forms;
using PluginForKompas;

namespace PluginForKompas
{
    public class DataController
    {
        private double _teethCount;
        private double _rigidity;
        private double _centerHoleDiam;
        /// <summary>
        /// Метод выполняет проверку списка параметров
        /// </summary>
        /// <param name="data">Список параметров</param>
        /// <returns></returns>
        public bool Validating(double internalArcOfDipDiam, double externalArcOfDipDiam,
            double chamferWidth, double gearDepth, params Parameter[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Descrpiption == PluginForKompas.Properties.Resources.Count)
                {
                    // количество зубьев может быть от 17 до 40 [Википедия]
                    if (CheckData(data[i], 17, 40))
                    {
                        _teethCount = data[i].Value;
                    }
                    else return false;
                }
                if (data[i].Descrpiption == PluginForKompas.Properties.Resources.Rigidity)
                {
                    // модуль жесткости может быть от 0.5 до 50 [ГОСТ 9563-60]
                    if (CheckData(data[i], 0.5, 50))
                    {
                        _rigidity = data[i].Value;
                    }
                    else return false;
                }
            }

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Descrpiption == PluginForKompas.Properties.Resources.CenterHole)
                {
                    // диаметр отверстия в центре от 5
                    double min = 5;
                    // до диаметра вписанной окружности наибольшего шестиугольника
                    // которую можно поместить внутри окружности с диаметром меньшей дуги углубления
                    // формула расчета вписанной окружности правильного шестиугольника в зависмости от
                    // описанной окружности d = D * cos(30)
                    double max = (internalArcOfDipDiam - chamferWidth) * Math.Cos(30 * Math.PI / 180);
                    if (CheckData(data[i], min, max))
                    {
                        _centerHoleDiam = data[i].Value;
                    }
                    else return false;
                }
            }
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Descrpiption == PluginForKompas.Properties.Resources.CircumentalHoles)
                {
                    // диаметр отверстий по окружноти от 5
                    double min = 5;
                    // до ширины углубления
                    double max = (externalArcOfDipDiam - internalArcOfDipDiam - chamferWidth) / 2;
                    if (!CheckData(data[i], min, max))
                        return false;
                }
                if (data[i].Descrpiption == PluginForKompas.Properties.Resources.HexagonDiameter)
                {
                    // минимальный диаметр описанной окружности шестиугольника
                    // формула для расчета описанной окружности в зависимости от вписанной
                    double min = _centerHoleDiam / Math.Cos(30 * Math.PI / 180);
                    // максимальный диаметр высчитывается как диаметр меньшей дуги углубления 
                    // минус ширина фаски
                    double max = internalArcOfDipDiam - chamferWidth;
                    if (!CheckData(data[i], min, max))
                        return false;
                }
                if (data[i].Descrpiption == PluginForKompas.Properties.Resources.HexagonDepth)
                {
                    // глубина выдавливания выреза под шестигранник
                    // от 0 до 1/2 от толщины шестерни

                    if (!CheckData(data[i], 0, gearDepth / 2))
                        return false;
                }
                if (data[i].Descrpiption == PluginForKompas.Properties.Resources.StiffenerWidth)
                {
                    // ширина ребра жесткости от 12 до 22, просто потому что так захотелось :)
                    if (!CheckData(data[i], 12, 22))
                        return false;
                }
                if (data[i].Descrpiption == PluginForKompas.Properties.Resources.StiffenerDepth)
                {
                    // глубина выдавливания выреза под углубления
                    // от 0 до 1/2 от глубины шестерни
                    if (!CheckData(data[i], 0, gearDepth / 2))
                        return false;
                }
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
