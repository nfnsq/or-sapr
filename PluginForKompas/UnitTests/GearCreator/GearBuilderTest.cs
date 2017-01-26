using NUnit.Framework;
using PluginForKompas;
using Kompas6API5;

namespace UnitTests.GearCreator
{
    [TestFixture]
    public class GearBuilderTest
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
            KompasApp app = new KompasApp();
            app.GetActiveApp();
            if (app.Kompas == null)
                app.NewApp();
            Parameter[] param = new Parameter[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                param[i].Value = list[i];
            }
            param[0].Descrpiption = PluginForKompas.Properties.Resources.HexagonDepth;
            param[1].Descrpiption = PluginForKompas.Properties.Resources.StiffenerDepth;
            param[2].Descrpiption = PluginForKompas.Properties.Resources.StiffenerWidth;
            param[3].Descrpiption = PluginForKompas.Properties.Resources.HexagonDiameter;
            param[4].Descrpiption = PluginForKompas.Properties.Resources.CircumentalHoles;
            param[5].Descrpiption = PluginForKompas.Properties.Resources.CenterHole; 
            param[6].Descrpiption = PluginForKompas.Properties.Resources.Rigidity;
            param[7].Descrpiption = PluginForKompas.Properties.Resources.Count;

            GearBuilder Gear = new GearBuilder(app, param);
            Assert.AreEqual(res, Gear.CreateGear());
        }
    }
}
