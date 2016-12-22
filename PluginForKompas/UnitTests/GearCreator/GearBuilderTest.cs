using NUnit.Framework;
using PluginForKompas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.GearCreator
{
    [TestFixture]
    class GearBuilderTest
    {
        [TestCase(true, 18, 15, 17, 23, 19, 15, 17, 18, TestName = "Тестирование при корректных значениях параметров")]
        [TestCase(false, 18, 10, 17, 23, 19, 15, 17, 18, TestName = "Тестирование при некорректных значениях параметров")]
        [TestCase(false, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity,
            double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity,
            double.PositiveInfinity, TestName = "Тестирование при значениях параметров PositiveInfinity")]
        [TestCase(false, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity,
            double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity,
            double.NegativeInfinity, TestName = "Тестирование при корректных значениях параметров NegativeInfinity")]
        [TestCase(false, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, 
            double.NaN, double.NaN, double.NaN, TestName = "Тестирование значениях параметров NaN")]
        [TestCase(false, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, 
            double.MaxValue, double.MaxValue, double.MaxValue, TestName = "Тестирование при значениях параметров MaxValue")]
        [TestCase(false, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue,
            double.MinValue, double.MinValue, double.MinValue, TestName = "Тестирование при значениях параметров MinValue")]
        
        public void Create(bool res, params double[] list)
        {
            KompasApp.GetActiveApp();
            Parameter[] param = new Parameter[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                param[i].value = list[i];
            }
            param[0].descrpiption = "depth_of_the_hexagon_dip";
            param[1].descrpiption = "stiffeners_width";
            param[2].descrpiption = "stiffener_depth";
            param[3].descrpiption = "diameter_of_the_heaxagon_circumscribed_circle";
            param[4].descrpiption = "diameter_of_the_center_hole";
            param[5].descrpiption = "diameter_of_the_circumential_holes";
            param[6].descrpiption = "rigidity_of_geat_unit";
            param[0].descrpiption = "count_of_gear_teeth";

            GearBuilder Gear = new GearBuilder(param);
            Assert.AreEqual(Gear.New(), res);
        }
    }
}
