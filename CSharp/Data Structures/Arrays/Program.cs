namespace ArraysDemo;

public class Program
{
    public static void Main()
    {
        //Insertion
        int[] arr = { 1, 22, 3, 4, 52, 6, 7 };
        int[] newArr = new int[arr.Length + 1];
        int insertIndex = 3;
        int newValue = 99;

        for (int i = 0; i < insertIndex; i++)
            newArr[i] = arr[i];

        newArr[insertIndex] = newValue;

        for (int i = insertIndex; i < arr.Length; i++)
            newArr[i + 1] = arr[i];

        foreach (int num in newArr)
            Console.WriteLine(num);

        //Deletion
        int[] arr2 = { 1, 22, 3, 4, 52, 6, 7 };
        int[] newArr2 = new int[arr2.Length - 1];
        int idx = 0;
        for (int i = 0; i < arr2.Length; i++)
        {
            if (i == 2) continue;
            newArr2[idx] = arr2[i];
            Console.WriteLine(newArr2[idx]);
            idx++;
        }

        //Searching
        int[] arr3 = { 1, 2, 3, 4, 5 };
        int elem = Array.Find(arr3, x => x == 2);

        //Sorting
        int[] arr4 = { 5, 3, 8, 1, 2 };
        Array.Sort(arr4);

        //Reversing
        int[] arr5 = { 1, 2, 3, 4, 5 };
        Array.Reverse(arr5);

        //Copying
        int[] arr6 = { 1, 2, 3, 4, 5 };
        int[] newArr6 = new int[5];
        Array.Copy(arr6, newArr6, arr6.Length);

        //2D array
        int[,] arr2D = new int[2, 3]; // 2x3 2D array
        arr2D[0, 0] = 1;
        arr2D[0, 1] = 2;
        arr2D[0, 2] = 3;
        arr2D[1, 0] = 4;
        arr2D[1, 1] = 5;
        arr2D[1, 2] = 6;
    
        //3D array
        int[,,] arr3D = new int[2, 2, 2]; // 2x2x2 3D array
        arr3D[0, 0, 0] = 1;
        arr3D[0, 0, 1] = 2;
        arr3D[0, 1, 0] = 3;
        arr3D[0, 1, 1] = 4;
        arr3D[1, 0, 0] = 5;
        arr3D[1, 0, 1] = 6;
        arr3D[1, 1, 0] = 7;
        arr3D[1, 1, 1] = 8;

        //Jagged array
        int[][] jaggedArr = new int[3][]; // Array of 3 arrays
        jaggedArr[0] = new int[] { 1, 2 };
        jaggedArr[1] = new int[] { 3, 4, 5 };
        jaggedArr[2] = new int[] { 6, 7, 8, 9 };


        //Linear Search
        int[] arr7 = { 1, 2, 3, 4, 5, 6 };
        int target = 6;

        int index = LinearSearch(arr, target);

        if (index != 1)
        {
            Console.WriteLine($"Element {target} found at index {index}");
        }
        else
        {
            Console.WriteLine($"Element {target} not found in the array");
        }
    }

    static int LinearSearch(int[] arr7, int target)
    {
        for (int i = 0; i < arr7.Length; i++)
        {
            if (arr7[i] == target)
            {
                return i; // Return the index if found
            }
            
        }
        return -1; // Return -1 if not found
    }
}
 