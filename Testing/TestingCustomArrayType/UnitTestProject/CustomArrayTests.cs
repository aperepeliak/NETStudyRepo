using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomArrayType.Lib;

namespace UnitTestProject
{
    [TestClass]
    public class CustomArrayTests
    {
        [TestMethod]
        public void Ctor_10Length5LowerBound_CustomArrWith10Length5LowerBound()
        {
            // arrange
            int length = 10;
            int lowerBound = 5;

            // act
            var array = new CustomArray<int>(length, lowerBound);

            //assert
            Assert.AreEqual(array.Length, length);
            Assert.AreEqual(array.LowerBound, lowerBound);
        }

        [TestMethod]
        public void Ctor_5LowerBound_5LowerBound()
        {
            // arrange
            int length = 5;
            int lowerBound = 5;

            // act
            var array = new CustomArray<int>(length, lowerBound);

            // assert
            Assert.AreEqual(array.LowerBound, lowerBound);
        }

        [TestMethod]
        public void Ctor_5LowerBound5Length_9UpperBound()
        {
            // arrange
            int length = 5;
            int lowerBound = 5;
            int upperBound = 9;
            int expected = 13;

            // act
            var array = new CustomArray<int>(length, lowerBound);
            array[upperBound] = expected;

            // assert
            Assert.AreEqual(array[upperBound], expected);
        }

        [TestMethod]
        public void Ctor_Minus7Length_ArgumentOutOfRangeException()
        {
            // arrange
            int length = -7;
            int lowerBound = 5;

            // act
            try
            {
                var array = new CustomArray<int>(length, lowerBound);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // assert
                Assert.AreEqual(ex.GetType(),
                    typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void Indexer_InitializeInForLoop_ContainsValuesFromLowerBoundToUpper()
        {
            // arrange
            int length = 5;
            int lowerBound = 5;

            var expected = new CustomArray<int>(length, lowerBound);
            expected[5] = 5;
            expected[6] = 6;
            expected[7] = 7;
            expected[8] = 8;
            expected[9] = 9;

            // act
            var array = new CustomArray<int>(length, lowerBound);
            for (int i = array.LowerBound; i < array.Length; i++)
            {
                array[i] = i;
            }

            // assert
            for (int i = array.LowerBound; i < array.Length; i++)
            {
                Assert.AreEqual(array[i], expected[i]);
            }
        }

        [TestMethod]
        public void Indexer_AddressOutOfRangeIndex_IndexOutOfRangeException()
        {
            // arrange
            int length = 5;
            int lowerBound = 5;
            int outOfRange = 10;

            // act
            var array = new CustomArray<int>(length, lowerBound);
            try
            {
                array[outOfRange] = 7;
            }
            catch (IndexOutOfRangeException ex)
            {
                // assert
                Assert.AreEqual(ex.GetType(), typeof(IndexOutOfRangeException));
            }
        }

        [TestMethod]
        public void Indexer_AddressOutOfRangeIndex_ErrorMessage()
        {
            // arrange
            int length = 5;
            int lowerBound = 5;
            int outOfRange = 10;

            // act
            var array = new CustomArray<int>(length, lowerBound);
            try
            {
                array[outOfRange] = 7;
            }
            catch (IndexOutOfRangeException ex)
            {
                // assert
                Assert.AreEqual(ex.Message,
                    $"\nInvalid index.\nThe array is of length {length} and lowerBound[{lowerBound}]");
            }
        }

        [TestMethod]
        public void Indexer_Reassign5thElementTo100_5thElementEquals100()
        {
            // arrange
            int length = 10;
            int lowerBound = 5;
            int expected = 100;

            // act
            var array = new CustomArray<int>(length, lowerBound);
            for (int i = array.LowerBound; i < array.Length; i++)
            {
                array[i] = i;
            }
            array[lowerBound] = expected;

            // assert
            Assert.AreEqual(array[lowerBound], expected);
        }
    }
}
