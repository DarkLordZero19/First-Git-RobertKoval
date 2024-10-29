using System;
class BinarySearch
{
    static void Main(string[] args)
    {
        int[] numbers = { 11, 12, 22, 25, 34, 64, 90 };
        int target = 25;

        int index = JustBinarySearch(numbers, target);

        if (index != -1)
        {
            Console.WriteLine($"Element found at index: {index}");
        }
        else
        {
            Console.WriteLine("Element not found.");
        }
    }

    private static int JustBinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;

            if (arr[middle] == target)
                return middle;

            if (arr[middle] < target)
                left = middle + 1;
            else
                right = middle - 1;
        }

        return -1; // Element not found
    }
}

