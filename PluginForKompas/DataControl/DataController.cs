using System;
using System.Windows.Forms;

namespace PluginForKompas
{
    public class DataController
    {
        private double teethCount;
        private double rigidity;
        private double centerHoleDiam;
        /// <summary>
        /// Метод выполняет проверку списка параметров
        /// </summary>
        /// <param name="data">Список параметров</param>
        /// <returns></returns>
        public bool Validating(params Parameter[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].descrpiption == "count_of_gear_teeth")
                {
                    ///количество зубьев может быть от 17 до 40 [Википедия]
                    if (CheckData(data[i], 17, 40))
                    {
                        teethCount = data[i].value;
                    }
                    else return false;
                }
                if (data[i].descrpiption == "rigidity_of_geat_unit")
                {
                    ///модуль жесткости может быть от 0.5 до 50 [ГОСТ 9563-60]
                    if (CheckData(data[i], 0.5, 50))
                    {
                        rigidity = data[i].value;
                    }
                    else return false;
                }
            }
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].descrpiption == "diameter_of_the_center_hole")
                {
                    ///диаметр отверстия в центре от 5
                    double min = 5;
                    ///до диаметра вписанной окружности наибольшего шестиугольника
                    ///диаметр описанной окружноси которого не превысит
                    ///диаметр меньшей дуги углубления
                    double max = (0.25 * rigidity * (teethCount + 2) - 10) * Math.Cos(30 * Math.PI / 180);
                    if (CheckData(data[i], min, max))
                    {
                        centerHoleDiam = data[i].value;
                    }
                    else return false;
                }
            }
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].descrpiption == "diameter_of_the_circumential_holes")
                {
                    ///диаметр отверстий по окружноти от 5
                    double min = 5;
                    ///до ширины углубления
                    double max = (0.9 * rigidity * (teethCount - 2.5) - 0.24 * rigidity * (teethCount + 2) - 10) / 2;
                    if (!CheckData(data[i], min, max))
                        return false;
                }
                if (data[i].descrpiption == "diameter_of_the_heaxagon_circumscribed_circle")
                {
                    ///диаметр описанной окружности шестиугольника
                    ///минимум высчитывается как описанная окружность шестиугольника
                    ///у которого диаметр вписанноц окружности равен 
                    ///диаметру отверстия в центре
                    double min = centerHoleDiam / Math.Cos(30 * Math.PI / 180);
                    ///максимум высчитывается как диаметр меньшей дуги углубления
                    double max = 0.25 * rigidity * (teethCount + 2) - 10;
                    if (!CheckData(data[i], min, max))
                        return false;
                }
                if (data[i].descrpiption == "depth_of_the_hexagon_dip")
                {
                    ///глубина выдавливания выреза под шестигранник
                    ///от 0 до 2/3 от глубины шестерни
                    if (!CheckData(data[i], 0, rigidity * teethCount * 0.1))
                        return false;
                }
                if (data[i].descrpiption == "stiffeners_width")
                {
                    ///ширина ребра жесткости от 12 до 22, просто потому что так захотелось :)
                    if (!CheckData(data[i], 12, 22))
                        return false;
                }
                if (data[i].descrpiption == "stiffener_depth")
                {
                    ///глубина выдавливания выреза под углубления
                    ///от 0 до 2/3 от глубины шестерни
                    if (!CheckData(data[i], 0, rigidity * teethCount * 0.1))
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
            if ((data.value < min)||(data.value > max))
            {
                MessageBox.Show("Invalid data "+ data.descrpiption +". Please, try again. " +
                "Enter number between " + Math.Round(min) + " and " + Math.Round(max) + ".", 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (double.IsNaN(data.value))
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
