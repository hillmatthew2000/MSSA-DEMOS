namespace InterpolationSearch;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 10, 15, 20, 25, 30, 35, 40 };
        int target = 30;
 
        Console.WriteLine("Array: " + string.Join(",", arr));
        Console.WriteLine($"Searching for {target}");
 
        int index = InterpolationSearch(arr, target);
 
        if (index != -1)
            Console.WriteLine($"Element {target} found at index {index}");
        else
            Console.WriteLine($"Element {target} not found in the array");
 
    }
 
    public static int InterpolationSearch(int[] arr, int x)
    {
        int lo = 0;
        int hi = arr.Length - 1;
 
        while (lo <= hi && x >= arr[lo] && x <= arr[hi])
        {
            if (lo == hi)
            {
                if (arr[lo] == x) return lo;
                return -1;
            }
 
            int mid = lo + ((x - arr[lo]) * (hi - lo)) / (arr[hi] - arr[lo]);
            if (arr[mid] == x)
                return mid;
            if (arr[mid] < x)
                lo = mid + 1;
            else
                hi = mid - 1;
        }
        return -1;
    }
}