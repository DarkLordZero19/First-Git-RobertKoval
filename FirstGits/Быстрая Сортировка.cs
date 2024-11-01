using System;
class Быстрая_сортировка
{
    static void Main(string[] args)
    {
        int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine("Original array:");
        PrintArray(numbers);

        QuickSort(numbers, 0, numbers.Length - 1);

        Console.WriteLine("Sorted array:");
        PrintArray(numbers);
    }

    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            // Find pivot element such that
            // element smaller than pivot are on the left and elements greater than pivot are on the right
            int pivotIndex = Partition(arr, low, high);

            // Recursively sort elements before partition and after partition
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; // pivot
        int i = (low - 1); // Index of smaller element

        for (int j = low; j < high; j++)
        {
            // If current element is smaller than or equal to pivot
            if (arr[j] <= pivot)
            {
                i++;

                // Swap arr[i] and arr[j]
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        // Swap arr[i + 1] and arr[high] (or pivot)
        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;

        return i + 1;
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

//git commit -m "Initial commit: Implement Insertion Sort"
