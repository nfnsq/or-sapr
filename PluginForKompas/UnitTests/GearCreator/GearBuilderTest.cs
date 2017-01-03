using NUnit.Framework;
using PluginForKompas;
using Global;

namespace UnitTests.GearCreator
{
    [TestFixture]
    class GearBuilderTest
    {
        [TestCase(true, 18, 15, 17, 35, 40, 30, 17, 18, TestName = "Тестирование при корректных значениях параметров")]
        [TestCase(false, 18, 15, 17, 35, 40, 30, 17, 1, TestName = "Тестирование при некорректных значениях параметров")]
        [TestCase(false, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity,
            double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity,
            double.PositiveInfinity, TestName = "Тестирование при значениях параметров PositiveInfinity")]
        [TestCase(false, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity,
            double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity,
            double.NegativeInfinity, TestName = "Тестирование при значениях параметров NegativeInfinity")]
        [TestCase(false, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, 
            double.NaN, double.NaN, double.NaN, TestName = "Тестирование при значениях параметров NaN")]
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
                param[i].Value = list[i];
            }
            param[0].Descrpiption = Global.Properties.Resources.HexagonDepth;
            param[1].Descrpiption = Global.Properties.Resources.StiffenerDepth;
            param[2].Descrpiption = Global.Properties.Resources.StiffenerWidth;
            param[3].Descrpiption = Global.Properties.Resources.HexagonDiameter;
            param[4].Descrpiption = Global.Properties.Resources.CircumentalHoles;
            param[5].Descrpiption = Global.Properties.Resources.CenterHole; 
            param[6].Descrpiption = Global.Properties.Resources.Rigidity;
            param[7].Descrpiption = Global.Properties.Resources.Count;

            GearBuilder Gear = new GearBuilder(param);
            Assert.AreEqual(res, Gear.New());
        }
    }
}
