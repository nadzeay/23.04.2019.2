using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace PseudoEnumerable.Tests
{
    [TestFixture]
    public class EnumerableTests
    {
        #region Filter

        private static IEnumerable<TestCaseData> Data_For_Filter
        {
            get
            {
                #region NumberContain

                yield return new TestCaseData(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, new Func<int, bool>(x => x.ToString().Contains(7.ToString())), new int[] { 7, 7, 70, 17 });
                yield return new TestCaseData(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, new Func<int, bool>(x => !x.ToString().Contains(7.ToString())), new int[] { 1, 2, 3, 4, 5, 6, 68, 69, 15 });
                yield return new TestCaseData(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, new Func<int, bool>(x => (x & 1) == 0), new int[] { 2, 4, 6, 68, 70 });
                yield return new TestCaseData(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, new Func<int, bool>(x => (x & 1) == 1), new int[] { 7, 1, 3, 5, 7, 69, 15, 17 });

                #endregion
            }
        }

        [TestCaseSource(nameof(Data_For_Filter))]
        public void Filter_TSourceIsInt32_DataIsValid(int[] source, Func<int, bool> func, int[] expectedArray)
            => Assert.AreEqual(expectedArray, Enumerable.Filter(source, func));

        [Test]
        public void Filter_SourceIsNull_PredicateIsValid_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Enumerable.Filter((int[])null, new Func<int, bool>(x => (x & 1) == 0)));

        [Test]
        public void Filter_SourceIsValid_PredicateIsNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Enumerable.Filter(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, null));

        [Test]
        public void Filter_SourceIsNull_PredicateIsNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Enumerable.Filter((int[])null, null));

        #endregion

        #region ForAll

        private static IEnumerable<TestCaseData> Data_For_ForAll
        {
            get
            {
                yield return new TestCaseData(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, new Func<int, bool>(x => x.ToString().Contains(7.ToString())), false);
                yield return new TestCaseData(new int[] { 0, 101, 110, 10 }, new Func<int, bool>(x => x.ToString().Contains(0.ToString())), true);
                yield return new TestCaseData(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, new Func<int, bool>(x => (x & 1) == 0), false);
                yield return new TestCaseData(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, new Func<int, bool>(x => (x & 1) == 1), false);
                yield return new TestCaseData(new int[] { 2, 4, 6, 68, 70 }, new Func<int, bool>(x => (x & 1) == 0), true);
                yield return new TestCaseData(new int[] { 7, 1, 3, 5, 7, 69, 15, 17 }, new Func<int, bool>(x => (x & 1) == 1), true);
            }
        }

        [TestCaseSource(nameof(Data_For_ForAll))]
        public void ForAll_TSourceIsInt32_DataIsValid(int[] source, Func<int, bool> func, bool expected)
            => Assert.AreEqual(expected, Enumerable.ForAll(source, func));

        [Test]
        public void ForAll_SourceIsNull_PredicateIsValid_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Enumerable.ForAll((int[])null, new Func<int, bool>(x => (x & 1) == 0)));

        [Test]
        public void ForAll_SourceIsValid_PredicateIsNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Enumerable.ForAll(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, null));

        [Test]
        public void ForAll_SourceIsNull_PredicateIsNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Enumerable.ForAll((int[])null, null));

        #endregion

        #region CastTo

        private static IEnumerable<TestCaseData> Data_For_CastTo_TSourceIsInt32_DataIsValid
        {
            get
            {
                yield return new TestCaseData(new object[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 });
                //yield return new TestCaseData(new object[] { "one", "two", "three" }, new string[] { "one", "two", "three" });
            }
        }

        [TestCaseSource(nameof(Data_For_CastTo_TSourceIsInt32_DataIsValid))]
        public void CastTo_TSourceIsInt32_DataIsValid(object[] source, int[] expectedArray)
            => Assert.AreEqual(expectedArray, Enumerable.CastTo<int>(source));

        //[TestCase(new object[] { 7, 1, "one" })]
        //public void CastTo_TSourceIsInt32_DataIsInvalid_ThrowInvalidCastException(object[] source)
        //    => Assert.Throws<InvalidCastException>(() => Enumerable.CastTo<int[]>(source));
            //=> Assert.IsNull(Enumerable.CastTo<int[]>(source));

        [Test]
        public void CastTo_SourceIsNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Enumerable.CastTo<int[]>(null));

        #endregion

        #region SortBy

        private static IEnumerable<TestCaseData> Data_For_SortBy_TSourceIsInt32_TKeyIsInt32_DataIsValid
        {
            get
            {
                yield return new TestCaseData(
                    new int[] { 2, 4, 7, 9, 1, 3, 8, 5, 0, 6 }, 
                    new Func<int, int>(x => x),
                    new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                );
                yield return new TestCaseData(
                    new int[] { 2, 4, 7, 9, 1, 3, 8, 5, 0, 6 },
                    new Func<int, int>(x => 0),
                    new int[] { 2, 4, 7, 9, 1, 3, 8, 5, 0, 6 }
                );
            }
        }

        [TestCaseSource(nameof(Data_For_SortBy_TSourceIsInt32_TKeyIsInt32_DataIsValid))]
        public void SortBy_TSourceIsInt32_TKeyIsInt32_DataIsValid(int[] source, Func<int, int> key, int[] expectedArray)
            => Assert.AreEqual(expectedArray, Enumerable.SortBy(source, key));

        private static IEnumerable<TestCaseData> Data_For_SortBy_TSourceIsString_TKeyIsString_DataIsValid
        {
            get
            {
                yield return new TestCaseData(
                    new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" },
                    new Func<string, string>(x => x),
                    new string[] { "eight", "five", "four", "nine", "one", "seven", "six", "three", "two" }
                );
            }
        }

        [TestCaseSource(nameof(Data_For_SortBy_TSourceIsString_TKeyIsString_DataIsValid))]
        public void SortBy_TSourceIsString_TKeyIsString_DataIsValid(string[] source, Func<string, string> key, string[] expectedArray)
            => Assert.AreEqual(expectedArray, Enumerable.SortBy(source, key));

        private static IEnumerable<TestCaseData> Data_For_SortBy_TSourceIsString_TKeyIsInt_DataIsValid
        {
            get
            {
                yield return new TestCaseData(
                    new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" },
                    new Func<string, int>(x => x.Length),
                    new string[] { "one", "two", "six", "four", "five", "nine", "three", "seven", "eight" }
                );
                yield return new TestCaseData(
                    new string[] { "ttt", "ttttt", "ttt", "tttttt", "", "tt" },
                    new Func<string, int>(x => x.Length),
                    new string[] { "", "tt", "ttt", "ttt", "ttttt", "tttttt" }
                );
            }
        }

        [TestCaseSource(nameof(Data_For_SortBy_TSourceIsString_TKeyIsInt_DataIsValid))]
        public void SortBy_TSourceIsString_TKeyIsInt_DataIsValid(string[] source, Func<string, int> key, string[] expectedArray)
            => Assert.AreEqual(expectedArray, Enumerable.SortBy(source, key));



        #endregion

        #region SortBy

        private static IEnumerable<TestCaseData> Data_For_SortByDescending_TSourceIsInt32_TKeyIsInt32_DataIsValid
        {
            get
            {
                yield return new TestCaseData(
                    new int[] { 2, 4, 7, 9, 1, 3, 8, 5, 0, 6 },
                    new Func<int, int>(x => x),
                    new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }
                );
                yield return new TestCaseData(
                    new int[] { 2, 4, 7, 9, 1, 3, 8, 5, 0, 6 },
                    new Func<int, int>(x => 0),
                    new int[] { 2, 4, 7, 9, 1, 3, 8, 5, 0, 6 }
                );
            }
        }

        [TestCaseSource(nameof(Data_For_SortByDescending_TSourceIsInt32_TKeyIsInt32_DataIsValid))]
        public void SortByDescending_TSourceIsInt32_TKeyIsInt32_DataIsValid(int[] source, Func<int, int> key, int[] expectedArray)
            => Assert.AreEqual(expectedArray, Enumerable.SortByDescending(source, key));

        private static IEnumerable<TestCaseData> Data_For_SortByDescending_TSourceIsString_TKeyIsString_DataIsValid
        {
            get
            {
                yield return new TestCaseData(
                    new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" },
                    new Func<string, string>(x => x),
                    new string[] { "two", "three", "six", "seven", "one", "nine", "four", "five", "eight" }
                );
            }
        }

        [TestCaseSource(nameof(Data_For_SortByDescending_TSourceIsString_TKeyIsString_DataIsValid))]
        public void SortByDescending_TSourceIsString_TKeyIsString_DataIsValid(string[] source, Func<string, string> key, string[] expectedArray)
            => Assert.AreEqual(expectedArray, Enumerable.SortByDescending(source, key));

        private static IEnumerable<TestCaseData> Data_For_SortByDescending_TSourceIsString_TKeyIsInt_DataIsValid
        {
            get
            {
                yield return new TestCaseData(
                    new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" },
                    new Func<string, int>(x => x.Length),
                    new string[] { "three", "seven", "eight", "four", "five", "nine", "one", "two", "six" }
                );
                yield return new TestCaseData(
                    new string[] { "ttt", "ttttt", "ttt", "tttttt", "", "tt" },
                    new Func<string, int>(x => x.Length),
                    new string[] { "tttttt", "ttttt", "ttt", "ttt", "tt", "" }
                );
            }
        }

        [TestCaseSource(nameof(Data_For_SortByDescending_TSourceIsString_TKeyIsInt_DataIsValid))]
        public void SortByDescending_TSourceIsString_TKeyIsInt_DataIsValid(string[] source, Func<string, int> key, string[] expectedArray)
            => Assert.AreEqual(expectedArray, Enumerable.SortByDescending(source, key));

        #endregion
    }
}