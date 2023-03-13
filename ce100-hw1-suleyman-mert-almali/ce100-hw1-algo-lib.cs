using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

/** @Author Eray Burak Çakır and Süleyman Mert Almalı 
*/


//!  A Algorithms class. 
/*!
  A class created for writing algorithm
*/
public class Algorithms
    {


    //! An Selection Sort Algorithm.
    /*! This static varible takes int array and bool debug property. */
    public static int[] SelectionSort(int[] arr,bool enableDebug=false)
        {

            int n = arr.Length;/*!< This variable stores the arrays length. */


        for (int i = 0; i < n; i++)/*!< This loop loops when arrays length equals integer i. */
        {
                int first_num = i;/*!< This variable takes from 0 to (array's length-1). */



            //! Its a for loop .
            /*! This loop first takes the first two elements of the array and compares the two,
             * writes whichever is smaller to the left and continues sorting from smallest to largest. . */
            for (int j = i + 1; j < n; j++)


                    if (arr[j] < arr[first_num])
                        first_num = j;

                int less_number = arr[first_num];
                arr[first_num] = arr[i];

                arr[i] = less_number;


                if (enableDebug == true)/*!< This steatments works if enableDebug variables turns true and it writes every step in the console. */
                {
                    Console.WriteLine($"Iteration {i+1}:{string.Join(", ", arr)}");
                }
            }

            return arr;

        }

    /// <summary>
    /// An Recursive Merge Sort Algorithm.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="enableDebug"></param>
    /// <returns></returns>
    /// This static varible takes int array,integer arrays left index,integer arrays right index and bool debug property. */
    public static int[] RecursiveMergeSort(int[] array,int left,int right,bool enableDebug=false)
        {
        
               if (left < right)///!< This steatments works if right is bigger than left. */
            {
                int middle = left + (right - left) / 2;///*!< This variable stores middle index of array's. */
                if (enableDebug == true)///*!< This steatments works if enableDebug variables turns true and it writes every step in the console. */
                {
                    Console.WriteLine($"Iteration:{string.Join(", ", array)}");
                }
                RecursiveMergeSort(array, left, middle);///*!< This function calls itself and sorts by dividing the array into two. */
                if (enableDebug == true)///!< This steatments works if enableDebug variables turns true and it writes every step in the console. */
                {
                    Console.WriteLine($"Iteration:{string.Join(", ", array)}");
                }
                RecursiveMergeSort(array, middle + 1, right);/*!< This function calls itself and sorts by dividing the array into two. */
                if (enableDebug == true)/*!< This steatments works if enableDebug variables turns true and it writes every step in the console. */
                {
                    Console.WriteLine($"Iteration:{string.Join(", ", array)}");
                }
                MergeRecursive(array, left, middle, middle + 1, right);/*!< This function combines the sorted items in a neat order. */
                if (enableDebug == true)/*!< This steatments works if enableDebug variables turns true and it writes every step in the console. */
                {
                    Console.WriteLine($"Iteration:{string.Join(", ", array)}");
                }
            }
            
        
            return array;
        }






      /**

        This method recursively merges two sorted subarrays of an array in place.
        @param data The array to be sorted.
        @param left The leftmost index of the left subarray.
        @param middle The rightmost index of the left subarray.
        @param middle1 The leftmost index of the right subarray.
        @param right The rightmost index of the right subarray.
        */



    public static void MergeRecursive(int[] data,int left , int middle, int middle1,int right)
        {

            int oldPosition = left;
            int size = right - left + 1;
            int[] temp = new int[size];
            int i = 0;


            while (left <= middle && middle1 <= right)
            {
                if (data[left]<= data[middle1])
                    temp[i++] = data[left++];
                else
                    temp[i++] = data[middle1++];


            }
            if(left>middle)
                for(int j = middle1; j <= right;j++)
                    temp[i++] = data[middle1++];
            else
                for(int j = left;j <= middle; j++)
                    temp[i++] = data[left++];
            Array.Copy(temp,0,data,oldPosition,size);



    }




        /**

        Sorts an array using the randomized quicksort algorithm with Hoare partition scheme.
        @param arr The array to be sorted
        @param low The starting index of the array to be sorted
        @param high The ending index of the array to be sorted
        @param enableDebug (Optional) Whether to enable debugging information or not (default is false)
        @return The sorted array
        */

    public static int[] RandomizedQuickSortHoare(int[] arr, int low, int high,bool enableDebug=false)
    {
        if (low >= high)
        {
            if (enableDebug == true) { Console.WriteLine("Iteration: Start index bigger than high index"); }
            return arr;
        }

        int pivot = arr[high];
        int i = low;
        int j = high;

        while (i < j)
        {
            while (arr[i] < pivot)
            {
                i++;
            }
            while (arr[j] > pivot)
            {
                j--;
            }
            if (i < j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                if (enableDebug == true) { Console.WriteLine($"Iteration:{arr[i]} and {arr[j]} relocated"); }
            }
        }

        RandomizedQuickSortHoare(arr, low, i - 1);
        RandomizedQuickSortHoare(arr, i, high);

        return arr;
    }



    /**

            @brief This method sorts the given integer array using randomized Lomuto partition scheme of quicksort algorithm.
            @param arr Integer array to be sorted.
            @param low Starting index of the array to be sorted.
            @param high Ending index of the array to be sorted.
            @param enableDebug Optional parameter to enable debugging. Default value is false.
            @return Sorted integer array.
*/
    public static int[] RandomizedQuickSortLomuto(int[] arr, int low, int high,bool enableDebug=false)
    {
        if (low >= high)
        {
            if (enableDebug == true) { Console.WriteLine("Iteration: Start index bigger than high index"); }
            return arr;
        }

        int pivot = arr[high];
        int j = low;

        for (int i = low; i < high; i++)
        {
            if (arr[i] <= pivot)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                j++;
                if (enableDebug == true) { Console.WriteLine($"Iteration:{arr[i]} and {arr[j]} relocated"); }
                
                }
        }

        int temp2 = arr[high];
        arr[high] = arr[j];
        arr[j] = temp2;

        RandomizedQuickSortLomuto(arr, low, j - 1);
        RandomizedQuickSortLomuto(arr, j + 1, high);

        return arr;
    }


            /**

        Iteratively searches for an integer in a sorted integer array using the binary search algorithm.
        @param arr The sorted integer array to search in.
        @param l The left index of the subarray to search in.
        @param r The right index of the subarray to search in.
        @param x The integer value to search for in the array.
        @return The index of the first occurrence of the search value in the array, or -1 if it is not found.
        */


    public static int IterativebinarySearch(int[] arr, int l, int r, int x)
    {

        arr = RandomizedQuickSortLomuto(arr, 0, r);

        while (l <= r)
        {
            int m = l + (r - l) / 2;
            // Check if x is present at mid
            if (arr[m] == x)
                return m;
            // If x greater, ignore left half
            if (arr[m] < x)
                l = m + 1;
            // If x is smaller, ignore right half
            else
                r = m - 1;
        }
        // if we reach here, then element was not present
        return -1;
    }



                 /**

                Perform an iterative binary search on the given array of integers to find the target number.
                The search is performed between the lower and upper bounds of the array.
                The array is sorted using the Lomuto partition scheme of randomized quicksort algorithm before searching.
                @param nums The array of integers to search.
                @param searchNum The number to search for in the array.
                @param enableDebug A boolean flag to enable or disable debug output.
                @return The index of the target number in the array, or -1 if it is not found.
                */


                    /**

                @brief This function performs an iterative binary search on a given integer array to find a specific integer number.
                @param nums An integer array to search in.
                @param searchNum An integer number to search for in the given array.
                @param enableDebug A boolean flag to enable debug output.
                @return If the search number is found, returns the index of the number in the array. If not, returns -1.
                This function starts by sorting the given array in ascending order using the Lomuto partition scheme of randomized quicksort algorithm.
                Then, it starts the binary search by setting the low index to the beginning of the array and high index to the end of the array.
                The algorithm looks at the middle index of the array and compares it with the search number.
                If the search number is less than the middle number, it looks at the left half of the array.
                If the search number is greater than the middle number, it looks at the right half of the array.
                It repeats this process until the search number is found or there are no more elements left to search in the array.
                If the enableDebug flag is set to true, the function also outputs the current state of the array during each iteration.
                */


    public static int IterativeBinarySearch(int[] nums, int searchNum, bool enableDebug=false)
    {

        
        int lowIndx = 0;
        int highIndx = nums.Length - 1;/*!< This variables stores integer array's length. */
        if (enableDebug == true) { Console.Write($"Iteration:"); for (int i = 0; highIndx > i; i++) { Console.Write(nums[i]); if (highIndx - i != 1) { Console.Write(","); } else if (highIndx - i == 1) { Console.WriteLine(""); } }  }
        nums =RandomizedQuickSortLomuto(nums,0,highIndx);/*!< Firstly,we have to sort given array. */

        if (enableDebug == true) { Console.Write($"Iteration:Sorted"); for (int i = 0; highIndx > i; i++) { Console.Write(nums[i]); if (highIndx - i != 1) { Console.Write(","); } else if (highIndx - i == 1) { Console.WriteLine(""); } } }

        while (lowIndx <= highIndx)/*!< This steatments firstly looks mid index and if search number is bigger than mid number algorithm looks at the half on the right. */
        {
            int[] a=new int[] { };
            int midIndx = (lowIndx + highIndx) / 2;
            if (searchNum < nums[midIndx])
            {
                highIndx = midIndx - 1;
                
                for(int i=0; highIndx >= i; i++) { a.Append(nums[i]); }
                if (enableDebug == true) { Console.Write($"Iteration:"); for (int i = 0; highIndx > i; i++) { Console.Write(a[i]); if (highIndx - i != 1) { Console.Write(","); } else if (highIndx - i == 1) { Console.WriteLine(""); } } }
            }
            else if (searchNum > nums[midIndx])
            {
                lowIndx = midIndx + 1;
                for (int i=midIndx; i >highIndx; i++) { a.Append(nums[i]); }
                if (enableDebug == true) { Console.Write($"Iteration:"); for (int i = lowIndx; i < highIndx; i++) { Console.Write(nums[i]); if (highIndx - i != 1) { Console.Write(","); } else if (highIndx - i == 1) { Console.WriteLine(""); } } }
            }
            else if (searchNum == nums[midIndx])
            {
                return midIndx;
            }
        }
        return -1;
    }




        /**

        Perform a recursive binary search on the given array of integers to find the target number.
        The search is performed between the given low and high indices of the array.
        @param numbers The array of integers to search.
        @param low The lower bound of the search range in the array.
        @param high The upper bound of the search range in the array.
        @param target The number to search for in the array.
        @param enableDebug A boolean flag to enable or disable debug output.
        @return The index of the target number in the array, or -1 if it is not found.
        */


    public static int RecursiveBinarySearch(int[] numbers, int low, int high, int target,bool enableDebug=false)
    {
        
        if (low > high)
        {
            if (enableDebug == true) { Console.WriteLine("Iteration: Start index bigger than high index"); }
            return -1;
        }

        int mid = (low + high) / 2;
        if (enableDebug == true) { Console.WriteLine($"Iteration: Mid index is calculated:{mid}"); }
        if (target == numbers[mid])/*!< This steatments works if target number is mid number. */
        {
            return mid;
        }

        
        else if (target < numbers[mid])/*!< This steatments works if target number is smaller than mid number and steatments calls itself. */
        {
            int a = RecursiveBinarySearch(numbers, low, mid - 1, target);
            if (enableDebug == true) { Console.WriteLine($"Iteration:{a}"); }
            return a;
        }

        
        else/*!< This steatments works if target number is bigger than mid number and steatments calls itself. */
        {
            int a = RecursiveBinarySearch(numbers, mid + 1, high, target);
            if (enableDebug == true) { Console.WriteLine($"Iteration:{a}"); }
            return a ;
        }
    }





    public class MatrixMultiplication
    {

        /** 
        * Multiplies two matrices iteratively.
        * @param matrix1 The first matrix to multiply.
        * @param matrix2 The second matrix to multiply.
        * @return The resulting matrix.
        * @throws ArgumentException If the dimensions of the input matrices are incompatible.
        */
        public static int[,] IterativeMatrixMultiplication(int[,] matrix1, int[,] matrix2)
        {
            int row1 = matrix1.GetLength(0);
            int col1 = matrix1.GetLength(1);
            int row2 = matrix2.GetLength(0);
            int col2 = matrix2.GetLength(1);

            if (col1 != row2)
            {
                throw new ArgumentException("Matris boyutları uyumsuz.");
            }

            int[,] result = new int[row1, col2];

            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col2; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < col1; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }



        /**

        Recursively multiplies matrices A and B and stores the result in matrix C.

        @param A First matrix to be multiplied.

        @param B Second matrix to be multiplied.

        @param C Resultant matrix where the product of A and B will be stored.

        @param i Row index of A and C matrices.

        @param j Column index of B and C matrices.

        @param k Column index of A and row index of B matrices.
        */

        public static void RecursivemultiplyMatrixRec(int[,] A, int[,] B, int[,] C, int i, int j, int k)
        {
            int r1 = A.GetLength(0);
            int c1 = A.GetLength(1);

            int r2 = B.GetLength(0);
            int c2 = B.GetLength(1);

            if (i >= r1)
            {
                return;
            }

            if (j < c2)
            {
                int sum = 0;
                for (k = 0; k < c1; k++)
                {
                    sum += A[i, k] * B[k, j];
                }
                C[i, j] = sum;

                RecursivemultiplyMatrixRec(A, B, C, i, j + 1, 0);
            }
            else
            {
                RecursivemultiplyMatrixRec(A, B, C, i + 1, 0, 0);
            }
        }


        /**

        * @brief Multiply two matrices and return the result.
        This function takes two matrices A and B, and multiplies them together
        using a recursive algorithm. The result is returned as a new matrix C.
        * @param A The first matrix to multiply.
        * @param B The second matrix to multiply.
        * @param r1 The number of rows in matrix A.
        * @param c2 The number of columns in matrix B.
        * @return The result of multiplying matrices A and B.
        * @note The dimensions of the matrices A and B must be compatible for matrix
        multiplication (i.e. the number of columns in A must match the number of rows
        in B).
        * @see multiplyMatrixRec()
        */

        public static int[,] RecursivemultiplyMatrix(int[,] A, int[,] B, int r1, int c2)
        {

            int[,] C = new int[r1, c2];

            for (int i = 0; i < r1; i++)
            {
                for (int j = 0; j < c2; j++)
                {
                    C[i, j] = 0;
                }
            }



            /**

        * @brief Recursive helper function to multiply two matrices.
        This function is called by multiplyMatrix() and performs the actual matrix
        multiplication using a recursive algorithm. The result is stored in the
        matrix C.
        * @param A The first matrix to multiply.
        * @param B The second matrix to multiply.
        * @param C The matrix to store the result of the multiplication.
        * @param i The current row index.
        * @param j The current column index.
        * @param k The current index for the inner loop.
        * @note This function is intended to be called by multiplyMatrix() and should
        not be called directly.
        * @see multiplyMatrix()
        */

            RecursivemultiplyMatrixRec(A, B, C, 0, 0, 0);

            return C;
        }

        /// <summary>
        /// A class that implements the Strassen algorithm for matrix multiplication.
        /// </summary>
        /// <summary>
        /// Multiplies two matrices using the Strassen algorithm.
        /// </summary>
        /// <param name="m1">The first matrix.</param>
        /// <param name="m2">The second matrix.</param>
        /// <returns>The product of the two matrices.</returns> 

        public static class StrassenMatrix
        {

            /**

            Performs matrix multiplication using Strassen's algorithm.
            @param m1 the first matrix to be multiplied
            @param m2 the second matrix to be multiplied
            @return the result of the matrix multiplication
            */
            public static int[,] StrassenMatrixMultiply(int[,] m1, int[,] m2)
            {
                // r = row
                int r = m1.GetLength(0);

                // Sonuç matrisini oluştur
                int[,] result = new int[r, r];

                // Baz durum: n=1
                if (r == 1)
                {
                    result[0, 0] = m1[0, 0] * m2[0, 0];
                }

                else
                {
                    // Matrisleri alt matrislere ayır
                    int newSize = r / 2;

                    int[,] subm111 = new int[newSize, newSize];
                    int[,] subm112 = new int[newSize, newSize];
                    int[,] subm121 = new int[newSize, newSize];
                    int[,] subm122 = new int[newSize, newSize];

                    int[,] subm211 = new int[newSize, newSize];
                    int[,] subm212 = new int[newSize, newSize];
                    int[,] subm221 = new int[newSize, newSize];
                    int[,] subm222 = new int[newSize, newSize];

                    Divide(m1, subm111, 0, 0);
                    Divide(m1, subm112, 0, newSize);
                    Divide(m1, subm121, newSize, 0);
                    Divide(m1, subm122, newSize, newSize);

                    Divide(m2, subm211, 0, 0);
                    Divide(m2, subm212, 0, newSize);
                    Divide(m2, subm221, newSize, 0);
                    Divide(m2, subm222, newSize, newSize);

                    // P1-P7 alt matrisleri hesapla
                    int[,] p1 = StrassenMatrixMultiply(Add(subm111, subm122), Add(subm211, subm222));
                    int[,] p2 = StrassenMatrixMultiply(Add(subm121, subm122), subm211);
                    int[,] p3 = StrassenMatrixMultiply(subm111, Subtract(subm212, subm222));
                    int[,] p4 = StrassenMatrixMultiply(subm122, Subtract(subm221, subm211));
                    int[,] p5 = StrassenMatrixMultiply(Add(subm111, subm112), subm222);
                    int[,] p6 = StrassenMatrixMultiply(Subtract(subm121, subm111), Add(subm211, subm212));
                    int[,] p7 = StrassenMatrixMultiply(Subtract(subm112, subm122), Add(subm221, subm222));

                    // Alt matrislerin çarpımı
                    int[,] subresult11 = Add(Subtract(Add(p1, p4), p5), p7);
                    int[,] subresult12 = Add(p3, p5);
                    int[,] subresult21 = Add(p2, p4);
                    int[,] subresult22 = Add(Subtract(Add(p1, p3), p2), p6);

                    // Sonuç matrisini alt matrislerden birleştir
                    Merge(subresult11, result, 0, 0);
                    Merge(subresult12, result, 0, newSize);
                    Merge(subresult21, result, newSize, 0);
                    Merge(subresult22, result, newSize, newSize);
                }

                return result;
            }


            /**

            Adds two matrices element-wise.
            @param m1 The first matrix to add.
            @param m2 The second matrix to add.
            @return The sum of the two matrices.
            @pre The dimensions of the two matrices must be equal.
            @post The result matrix has the same dimensions as the input matrices.
            @note This method uses a nested loop to iterate over each element in the input matrices
            and compute the sum of the corresponding elements.
            */
            public static int[,] Add(int[,] m1, int[,] m2)
            {
                int n = m1.GetLength(0);
                int[,] result = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        result[i, j] = m1[i, j] + m2[i, j];
                    }
                }

                return result;
            }



            /**

            Subtracts the values in the second matrix from the values in the first matrix.
            @param m1 The first matrix.
            @param m2 The second matrix.
            @return The resulting matrix from the subtraction.
            */
            public static int[,] Subtract(int[,] m1, int[,] m2)
            {
                int r = m1.GetLength(0);
                int[,] result = new int[r, r];

                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < r; j++)
                    {
                        result[i, j] = m1[i, j] - m2[i, j];
                    }
                }

                return result;
            }



            /**

            @brief Divides a parent matrix into a child matrix starting from a specified row and column index.
            @param parentMatrix The matrix to be divided.
            @param childMatrix The matrix to store the divided part of parent matrix.
            @param rowStart The starting row index of the division in the parent matrix.
            @param colStart The starting column index of the division in the parent matrix.
            */
            public static void Divide(int[,] parentMatrix, int[,] childMatrix, int rowStart, int colStart)
            {
                for (int i = 0, i2 = rowStart; i < childMatrix.GetLength(0); i++, i2++)
                {
                    for (int j = 0, j2 = colStart; j < childMatrix.GetLength(1); j++, j2++)
                    {
                        childMatrix[i, j] = parentMatrix[i2, j2];
                    }
                }
            }

            /**

            @brief Merges a child matrix into a parent matrix starting from the specified row and column indices.
            @param childMatrix The matrix to be merged into the parent matrix.
            @param parentMatrix The matrix to merge the child matrix into.
            @param rowStart The starting row index in the parent matrix.
            @param colStart The starting column index in the parent matrix.
            */
            public static void Merge(int[,] childMatrix, int[,] parentMatrix, int rowStart, int colStart)
            {
                for (int i = 0, i2 = rowStart; i < childMatrix.GetLength(0); i++, i2++)
                {
                    for (int j = 0, j2 = colStart; j < childMatrix.GetLength(1); j++, j2++)
                    {
                        parentMatrix[i2, j2] = childMatrix[i, j];
                    }
                }
            }

        }
    }
}

























