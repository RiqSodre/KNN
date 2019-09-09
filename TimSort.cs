using System;
using System.Collections.Generic;
using System.Text;

namespace kNN_Leo
{
    public class TimSort
    {
        public const int RUN = 32;

        // this function sorts array from left index to  
        // to right index which is of size atmost RUN  
        public static void insertionSort(float[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                float temp = arr[i];
                int j = i - 1;
                while (arr[j] > temp && j >= left)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }

        public static List<Flor> InsertionSort(float[] vetor, List<Flor> flores)
        {
            for (var i = 1; i < vetor.Length; i++)
            {
                Flor aux1 = flores[i];
                var aux = vetor[i];
                var j = i - 1;

                while (j >= 0 && vetor[j] > aux)
                {
                    vetor[j + 1] = vetor[j];
                    flores[j + 1] = flores[j];
                    j -= 1;
                }
                flores[j + 1] = aux1;
                vetor[j + 1] = aux;
            }

            return flores;
        }

        // merge function merges the sorted runs  
        public static void merge(float[] arr, int l, int m, int r)
        {
            // original array is broken in two parts  
            // left and right array  
            int len1 = m - l + 1, len2 = r - m;
            float[] left = new float[len1];
            float[] right = new float[len2];
            for (int x = 0; x < len1; x++)
                left[x] = arr[l + x];
            for (int x = 0; x < len2; x++)
                right[x] = arr[m + 1 + x];

            int i = 0;
            int j = 0;
            int k = l;

            // after comparing, we merge those two array  
            // in larger sub array  
            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            // copy remaining elements of left, if any  
            while (i < len1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }

            // copy remaining element of right, if any  
            while (j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }

        // iterative Timsort function to sort the  
        // array[0...n-1] (similar to merge sort)  
        public static float[] timSort(float[] arr, int n)
        {
            // Sort individual subarrays of size RUN  
            for (int i = 0; i < n; i += RUN)
                insertionSort(arr, i, Math.Min((i + 31), (n - 1)));

            // start merging from size RUN (or 32). It will merge  
            // to form size 64, then 128, 256 and so on ....  
            for (int size = RUN; size < n; size = 2 * size)
            {
                // pick starting point of left sub array. We  
                // are going to merge arr[left..left+size-1]  
                // and arr[left+size, left+2*size-1]  
                // After every merge, we increase left by 2*size  
                for (int left = 0; left < n; left += 2 * size)
                {
                    // find ending point of left sub array  
                    // mid+1 is starting point of right sub array  
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    // merge sub array arr[left.....mid] &  
                    // arr[mid+1....right]  
                    merge(arr, left, mid, right);
                }
            }
            return arr;
        }

        // utility function to print the Array  
        public static void printArray(float[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.Write("\n");
        }

        public static void PrintList(List<Flor> flores)
        {
            for (int i = 0; i < flores.Count; i++)
                Console.WriteLine(flores[i].sepala.x + "/" + flores[i].sepala.y + "/" + flores[i].petala.x + "/" + flores[i].petala.y + "/" + flores[i].type);
        }

    }
}
