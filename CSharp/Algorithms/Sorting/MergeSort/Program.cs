namespace MergeSort;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 7, 4, 10, 5, 1, 8 };
 
        Console.WriteLine("Original array");
        DisplayArray(arr);
 
        MergeSort(arr, 0, arr.Length - 1);
 
        Console.WriteLine("\nSorted array");
        DisplayArray(arr);
    }
 
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }
 
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0;
 
        while (i <= mid && j <= right)
        {
            if (arr[i] <= arr[j])
                temp[k++] = arr[i++];
            else
                temp[k++] = arr[j++];
        }
        while (i <= mid)
        {
            temp[k++] = arr[i++];
        }
        while (j <= right)
        {
            temp[k++] = arr[j++];
        }
        for (i = left; i <= right; i++)
        {
            arr[i] = temp[i - left];
        }
 
    }
 
    static void DisplayArray(int[] arr)
    {
        foreach (int i in arr)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}