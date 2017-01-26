using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnitTests.GearCreator;

namespace UnitTests.LoadTests
{
    [TestFixture]
    class GearBuilderLoadTest
    {
        [TestCase(1, TestName = "Тестирование при построении 1 документа-модели")]
        [TestCase(2, TestName = "Тестирование при построении 2 документа-модели")]
        [TestCase(3, TestName = "Тестирование при построении 3 документа-модели")]
        [TestCase(4, TestName = "Тестирование при построении 4 документа-модели")]
        [TestCase(5, TestName = "Тестирование при построении 5 документа-модели")]
        [TestCase(6, TestName = "Тестирование при построении 6 документа-модели")]
        [TestCase(7, TestName = "Тестирование при построении 7 документа-модели")]
        [TestCase(8, TestName = "Тестирование при построении 8 документа-модели")]
        [TestCase(9, TestName = "Тестирование при построении 9 документа-модели")]
        [TestCase(10, TestName = "Тестирование при построении 10 документа-модели")]
        public void LoadTest(int count)
        {
            bool res = true;
            double[] list = new double[] { 18, 15, 17, 35, 40, 30, 17, 18 };
            GearBuilderTest unitTest = new GearBuilderTest();
            for (int i = 1; i <= count; i++)
            {
                unitTest.Create(res, list);
            }
        }
    }

}
