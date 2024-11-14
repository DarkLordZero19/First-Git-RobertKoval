using System;
class BinarySearches
{
    static void Main()
    {
        int[] array = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
        int target = 7;

        int index = BinarySearch(array, target);

        if (index != -1)
        {
            Console.WriteLine($"Элемент {target} найден на индексе {index}.");
        }
        else
        {
            Console.WriteLine($"Элемент {target} не найден в массиве.");
        }
    }

    static int BinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            // Проверяем, равен ли элемент в середине искомому
            if (array[mid] == target)
            {
                return mid; // Возвращаем индекс найденного элемента
            }
            // Если элемент больше, игнорируем левую половину
            else if (array[mid] < target)
            {
                left = mid + 1;
            }
            // Если элемент меньше, игнорируем правую половину
            else
            {
                right = mid - 1;
            }
        }
        return -1; // Элемент не найден
    }
}