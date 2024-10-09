using System;
class Сортировка_слияниями
{
    static void Main(string[] args)
    {
        int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine("Original array:");
        PrintArray(numbers);

        MergeSort(numbers, 0, numbers.Length - 1);

        Console.WriteLine("Sorted array:");
        PrintArray(numbers);
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            // Find the middle point
            int middle = left + (right - left) / 2;
            // Sort first and second halves
            MergeSort(arr, left, middle);
            MergeSort(arr, middle + 1, right);
            // Merge the sorted halves
            Merge(arr, left, middle, right);
        }
    }

    static void Merge(int[] arr, int left, int middle, int right)
    {
        // Find sizes of two subarrays to be merged
        int n1 = middle - left + 1;
        int n2 = right - middle;
        // Create temporary arrays
        int[] L = new int[n1];
        int[] R = new int[n2];
        // Copy data to temporary arrays
        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, middle + 1, R, 0, n2);
        // Merge the temporary arrays
        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }
        // Copy remaining elements of L[] if any
        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }
        // Copy remaining elements of R[] if any
        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
