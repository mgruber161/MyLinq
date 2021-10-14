using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLinq.Logic;
using System.Collections.Generic;

namespace MyLinq.Logic.UnitTest
{
    [TestClass]
    public class IEnumerableExtensionsUnitTest
    {
        [TestMethod]
        public void ValidateFilter_ListOfNumbersFromMinus10To10_ExpectedEvenNumbers()
        {
            var source = new int[21];
            for (int i = -10; i < 11; i++)
            {
                source[i+10] = i;
            }
            var expected = new int[] { -10, -8, -6, -4, -2, 0, 2, 4, 6, 8, 10 };
            var actual = source.Filter(x => x % 2 == 0);

            CollectionAssert.AreEqual(actual.ToArray(), expected, "Filter ist falsch.");
        }

        [TestMethod]
        public void ValidateFilter_ListOfNumbersFrom5To22_ExpectedOddNumbers()
        {
            var source = new int[18];
            for (int i = 5; i < 23; i++)
            {
                source[i -5] = i;
            }
            var expected = new int[] { 5, 7, 9, 11, 13, 15, 17, 19, 21 };
            var actual = source.Filter(x => x % 2 != 0);

            CollectionAssert.AreEqual(actual.ToArray(), expected, "Filter ist falsch.");
        }

        [TestMethod]
        public void CalculateSum_ArrayFrom5To25_Result315()
        {
            var source = new int[21];
            for (int i = 5; i < 26; i++)
            {
                source[i - 5] = i;
            }
            var expected = 315;
            var actual = source.Sum(x => x);
            Assert.AreEqual(expected, actual, "Summe nicht korrekt.");
        }

        [TestMethod]
        public void CalculateSum_ArrayFromMinus30To5_ResultMinus450()
        {
            var source = new int[36];
            for (int i = -30; i < 6; i++)
            {
                source[i + 30] = i;
            }
            var expected = -450;
            var actual = source.Sum(x => x);
            Assert.AreEqual(expected, actual, "Summe nicht korrekt.");
        }

        [TestMethod]
        public void CreateArray_DoubleList_ExpectedCorrectArray()
        {
            var source = new List<double>();
            for (double i = 0; i < 10; i++)
            {
                source.Add(i);
            }
            var expected = new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0 };
            var actual = source.ToArray();
            CollectionAssert.AreEqual(expected, actual, "Array nicht korrekt.");
        }

        [TestMethod]
        public void CreateArray_IntList_ExpectedCorrectArray()
        {
            var source = new List<int>();
            for (int i = 20; i < 31; i++)
            {
                source.Add(i);
            }
            var expected = new int[] { 20,21,22,23,24,25,26,27,28,29,30 };
            var actual = source.ToArray();
            CollectionAssert.AreEqual(expected, actual, "Array nicht korrekt.");
        }

        [TestMethod]
        public void CreateList_DoubleArray_CorrectList()
        {
            var source = new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0 };
            var expected = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                expected.Add(i);
            }
            var actual = source.ToList();
            CollectionAssert.AreEqual(expected, (System.Collections.ICollection)actual, "Liste nicht korrekt.");
        }

        [TestMethod]
        public void CreateList_IntArray_CorrectList()
        {
            var source = new int[] { 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            var expected = new List<int>();
            for (int i = 20; i < 31; i++)
            {
                expected.Add(i);
            }
            var actual = source.ToList();
            CollectionAssert.AreEqual(expected, (System.Collections.ICollection)actual, "Liste nicht korrekt.");
        }

        [TestMethod]
        public void CalculateMinimum_IntList_Result4()
        {
            var source = new List<int>();
            for (int i = 4; i < 13; i++)
            {
                source.Add(i);
            }
            var expected = 4;
            var actual = source.Min(x=>x);
            Assert.AreEqual(expected, actual, "Minimum nicht korrekt.");
        }

        [TestMethod]
        public void CalculateMinimum_DoubleList_Result13()
        {
            var source = new List<double>();
            for (double i = 13; i < 34; i++)
            {
                source.Add(i);
            }
            var expected = 13;
            var actual = source.Min(x => x);
            Assert.AreEqual(expected, actual, "Minimum nicht korrekt.");
        }

        [TestMethod]
        public void CalculateMaximum_DoubleList_Result69()
        {
            var source = new List<double>();
            for (double i = 13; i < 70; i++)
            {
                source.Add(i);
            }
            var expected = 69;
            var actual = source.Max(x => x);
            Assert.AreEqual(expected, actual, "Maximum nicht korrekt.");
        }

        [TestMethod]
        public void CalculateMaximum_IntList_Result1()
        {
            var source = new List<int>();
            for (int i = -10; i < 2; i++)
            {
                source.Add(i);
            }
            var expected = 1;
            var actual = source.Max(x => x);
            Assert.AreEqual(expected, actual, "Maximum nicht korrekt.");
        }

        [TestMethod]
        public void CalculateAverage_DoubleList_Result4Point5()
        {
            var source = new List<double>();
            for (double i = 0; i < 10; i++)
            {
                source.Add(i);
            }
            var expected = 4.5;
            var actual = source.Average(x => x);
            Assert.AreEqual(expected, actual, "Durchschnitt nicht korrekt.");
        }

        [TestMethod]
        public void CalculateAverage_IntList_Result69()
        {
            var source = new List<int>();
            for (int i = 10; i < 20; i++)
            {
                source.Add(i);
            }
            var expected = 14.5;
            var actual = source.Average(x => x);
            Assert.AreEqual(expected, actual, "Durchschnitt nicht korrekt.");
        }

        [TestMethod]
        public void PrintList_IntList_ConsoleOutput()
        {
            var source = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                source.Add(i);
            }

            source.ForEach(x => System.Console.WriteLine(x));
        }

        [TestMethod]
        public void PrintList_DoubleList_ConsoleOutput()
        {
            var source = new List<double>();
            for (double i = 10; i < 20; i++)
            {
                source.Add(i);
            }

            source.ForEach(x => System.Console.WriteLine(x));
        }

        [TestMethod]
        public void PrintListAndIndex_IntList_ConsoleOutput()
        {
            var source = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                source.Add(i);
            }

            source.ForEach((x, y) => System.Console.WriteLine($"{x} {y}"));
        }

        [TestMethod]
        public void ConvertToDouble_IntList_DoubleList()
        {
            var source = new List<int>();
            var expected = new List<double>();
            for (int i = 0; i < 20; i++)
            {
                source.Add(i);
                expected.Add((double)i);
            }
            var actual = source.Map(x => (double)x);
            CollectionAssert.AreEqual(expected, (System.Collections.ICollection)actual, "Liste nicht korrekt.");
        }

        [TestMethod]
        public void ConvertToFloat_DoubleList_IntList()
        {
            var source = new List<double>();
            var expected = new List<float>();
            for (double i = 0; i < 20; i++)
            {
                source.Add(i);
                expected.Add((float)i);
            }
            var actual = source.Map(x => (float)x);
            CollectionAssert.AreEqual(expected, (System.Collections.ICollection)actual, "Liste nicht korrekt.");
        }


    }
}
