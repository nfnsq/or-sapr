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
        [TestCase(true, 18, 17, 15, 23, 15, 19, 10, 20, TestName = "Тестирование при корректных значениях параметров")]
        public void Create(bool res, params double[] list)
        {
            KompasApp.GetActiveApp();
            GearBuilder Gear = new GearBuilder(list);
            Assert.AreEqual(Gear.New(), res);
        }
    }
}
