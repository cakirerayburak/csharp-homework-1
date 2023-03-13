using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Tests
{
    [TestClass()]
    public class  ce100_hw1_algo_test : Algorithms 
    {
        [TestMethod()]


        public void SelectionSortTest()
        {
            var random = new Random();
            int[] input = Enumerable.Range(1, 10000).Select(_ => random.Next()).ToArray();

            int[] sorted = SelectionSort(input);

            for (int j = 1; j < sorted.Length; j++)
            {
                Assert.IsTrue(sorted[j] >= input[j - 1]);
            }
        }

        [TestMethod()]

        public void RecursiveMergeSortTest()
        {
            var random = new Random();
            int[] input = Enumerable.Range(1, 10000).Select(_ => random.Next()).ToArray();

            int[] sorted = RecursiveMergeSort(input, 0, input.Length - 1);

            for (int j = 1; j < sorted.Length; j++)
            {
                Assert.IsTrue(sorted[j] >= input[j - 1]);
            }
        }

        [TestMethod()]
        public void RandomizedQuickSortLomutoTest()
        {
            var random = new Random();
            int[] input = Enumerable.Range(1, 10000).Select(_ => random.Next()).ToArray();

            int[] sorted = RandomizedQuickSortLomuto(input, 0, input.Length - 1);

            for (int j = 1; j < sorted.Length; j++)
            {
                Assert.IsTrue(sorted[j] >= input[j - 1]);
            }
        }

        [TestMethod()]
        public void RandomizedQuickSortHoareTest()
        {
            var random = new Random();
            int[] input = Enumerable.Range(1, 10000).Select(_ => random.Next()).ToArray();

            int[] sorted = RandomizedQuickSortHoare(input, 0, input.Length - 1);

            for (int j = 1; j < sorted.Length; j++)
            {
                Assert.IsTrue(sorted[j] >= input[j - 1]);
            }
        }



        [TestMethod()]

        public void RecursiveBinarySearchTest()
        {
            var random = new Random();
            int[] input = Enumerable.Range(1, 10000).Select(_ => random.Next()).ToArray();

            int[] sorted = RandomizedQuickSortLomuto(input, 0, input.Length - 1);



            for (int j = 0; j < sorted.Length; j++)
            {
                Assert.IsTrue(RecursiveBinarySearch(input, 0, sorted.Length - 1, sorted[j]) == j);
            }
        }


        [TestMethod()]

        public void IterativeBinarySearchTest()
        {
            var random = new Random();
            int[] input = Enumerable.Range(1, 10000).Select(_ => random.Next()).ToArray();

            int[] sorted = RandomizedQuickSortLomuto(input, 0, (input.Length - 1));



            for (int j = 1; j < 100; j++)
            {
                Assert.IsTrue(IterativebinarySearch(sorted,0,input.Length - 1, sorted[j]) == j);
            }
        }

        [TestMethod]


        public void StrassenMatrixMultiplicationTest()
        {

            int[,] matrix1 = {

                 { 1, 2, 3, 4, 5, 6, 7, 8 },
                {11, 12, 13, 14, 15, 16, 17, 18},
                {21, 22, 23, 24, 25, 26, 27, 28},
                {31, 32, 33, 34, 35, 36, 37, 38},
                {41, 42, 43, 44, 45, 46, 47, 48},
                {51, 52, 53, 54, 55, 56, 57, 58},
                {61, 62, 63, 64, 65, 66, 67, 68},
                {71, 72, 73, 74, 75, 76, 77, 78},

            };
            int[,] matrix2 = {

                  {1, 2, 3, 4, 5, 6, 7, 8},
                {11, 12, 13, 14, 15, 16, 17, 18},
                {21, 22, 23, 24, 25, 26, 27, 28},
                {31, 32, 33, 34, 35, 36, 37, 38},
                {41, 42, 43, 44, 45, 46, 47, 48},
                {51, 52, 53, 54, 55, 56, 57, 58},
                {61, 62, 63, 64, 65, 66, 67, 68},
                {71, 72, 73, 74, 75, 76, 77, 78},


            };
            int[,] expected =
                {
            { 1716 , 1752 , 1788 , 1824 , 1860 , 1896 , 1932 , 1968 },
            { 4596 , 4712 , 4828 , 4944 , 5060 , 5176 , 5292 , 5408 },
            { 7476 , 7672 , 7868 , 8064 , 8260 , 8456 , 8652 , 8848 },
            { 10356 , 10632 , 10908 , 11184 , 11460 , 11736 , 12012 , 12288 } ,
            { 13236 , 13592 , 13948 , 14304 , 14660 , 15016 , 15372 , 15728 },
            { 16116 , 16552 , 16988 , 17424 , 17860 , 18296 , 18732 , 19168 },
            { 18996 , 19512 , 20028 , 20544 , 21060 , 21576 , 22092 , 22608 },
            { 21876 , 22472 , 23068 , 23664 , 24260 , 24856 , 25452 , 26048 }
            };

            int[,] actual = MatrixMultiplication.StrassenMatrix.StrassenMatrixMultiply(matrix1, matrix2);

            CollectionAssert.AreEqual(expected, actual);


        }



        [TestMethod]
        public void IterativeMatrixMultiplicationTest()
        {
            int[,] matrix1 = new int[,]
            {

                    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
                    { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 },
                    { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 },
                    { 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 },
                    { 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 },
                    { 61, 62, 63, 64, 65, 66, 67, 68, 69, 70 },
                    { 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 },
                    { 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 },
                    { 91, 92, 93, 94, 95, 96, 97, 98, 99, 100}

            };

            int[,] matrix2 = new int[,]
            {
                    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
                    { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 },
                    { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 },
                    { 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 },
                    { 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 },
                    { 61, 62, 63, 64, 65, 66, 67, 68, 69, 70 },
                    { 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 },
                    { 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 },
                    { 91, 92, 93, 94, 95, 96, 97, 98, 99, 100}
            };

            int[,] expected = new int[,]
            {
                 {   3355  ,  3410  ,  3465  ,  3520  ,  3575  ,  3630  ,  3685  ,  3740  ,  3795  ,  3850 } ,
                { 7955  ,  8110  ,  8265  ,  8420  ,  8575  ,  8730  ,  8885  ,  9040  ,  9195  ,  9350 } ,
                { 12555  ,  12810  ,  13065  ,  13320  ,  13575  ,  13830  ,  14085  ,  14340  ,  14595  ,  14850 },
                { 17155  ,  17510  ,  17865  ,  18220  ,  18575  ,  18930  ,  19285  ,  19640  ,  19995  ,  20350 },
                { 21755  ,  22210  ,  22665  ,  23120  ,  23575  ,  24030  ,  24485  ,  24940  ,  25395  ,  25850 } ,
                { 26355  ,  26910  ,  27465  ,  28020  ,  28575  ,  29130  ,  29685  ,  30240  ,  30795  ,  31350 } ,
                { 30955  ,  31610  ,  32265  ,  32920  ,  33575  ,  34230  ,  34885  ,  35540  ,  36195  ,  36850 } ,
                { 35555  ,  36310  ,  37065  ,  37820  ,  38575  ,  39330  ,  40085  ,  40840  ,  41595  ,  42350 } ,
                { 40155  ,  41010  ,  41865  ,  42720  ,  43575  ,  44430  ,  45285  ,  46140  ,  46995  ,  47850 },
                { 44755  ,  45710  ,  46665  ,  47620  ,  48575  ,  49530  ,  50485  ,  51440  ,  52395  ,  53350 }
            };

            int[,] actual =MatrixMultiplication.IterativeMatrixMultiplication(matrix1, matrix2);

            CollectionAssert.AreEqual(expected, actual);
        }





        [TestMethod]
        public void RecursiveMatrixMultiplicationTest()
        {
            int[,] matrix1 = new int[,]
            {
                    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
                    { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 },
                    { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 },
                    { 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 },
                    { 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 },
                    { 61, 62, 63, 64, 65, 66, 67, 68, 69, 70 },
                    { 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 },
                    { 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 },
                    { 91, 92, 93, 94, 95, 96, 97, 98, 99, 100}
            };

            int[,] matrix2 = new int[,]
            {
                    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
                    { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 },
                    { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 },
                    { 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 },
                    { 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 },
                    { 61, 62, 63, 64, 65, 66, 67, 68, 69, 70 },
                    { 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 },
                    { 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 },
                    { 91, 92, 93, 94, 95, 96, 97, 98, 99, 100}
        };

            int[,] expected = new int[,]
            {
                {   3355  ,  3410  ,  3465  ,  3520  ,  3575  ,  3630  ,  3685  ,  3740  ,  3795  ,  3850 } ,
                { 7955  ,  8110  ,  8265  ,  8420  ,  8575  ,  8730  ,  8885  ,  9040  ,  9195  ,  9350 } ,
                { 12555  ,  12810  ,  13065  ,  13320  ,  13575  ,  13830  ,  14085  ,  14340  ,  14595  ,  14850 },
                { 17155  ,  17510  ,  17865  ,  18220  ,  18575  ,  18930  ,  19285  ,  19640  ,  19995  ,  20350 },
                { 21755  ,  22210  ,  22665  ,  23120  ,  23575  ,  24030  ,  24485  ,  24940  ,  25395  ,  25850 } ,
                { 26355  ,  26910  ,  27465  ,  28020  ,  28575  ,  29130  ,  29685  ,  30240  ,  30795  ,  31350 } ,
                { 30955  ,  31610  ,  32265  ,  32920  ,  33575  ,  34230  ,  34885  ,  35540  ,  36195  ,  36850 } ,
                { 35555  ,  36310  ,  37065  ,  37820  ,  38575  ,  39330  ,  40085  ,  40840  ,  41595  ,  42350 } ,
                { 40155  ,  41010  ,  41865  ,  42720  ,  43575  ,  44430  ,  45285  ,  46140  ,  46995  ,  47850 },
                { 44755  ,  45710  ,  46665  ,  47620  ,  48575  ,  49530  ,  50485  ,  51440  ,  52395  ,  53350 }
        };

            int[,] actual = new int[10, 10];
            MatrixMultiplication.RecursivemultiplyMatrixRec(matrix1, matrix2, actual, 0, 0, 0);

            CollectionAssert.AreEqual(expected, actual);

        }


















    }
}