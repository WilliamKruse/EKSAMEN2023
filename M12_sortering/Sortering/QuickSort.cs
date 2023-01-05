namespace Sortering;

public static class QuickSort
{

    private static void Swap(int[] array, int k, int j)
    {
        int tmp = array[k];
        array[k] = array[j];
        array[j] = tmp;
    }

    private static void _quickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivot = Partition(array, low, high);
            _quickSort(array, low, pivot - 1);
            _quickSort(array, pivot + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        //sætter piv til den laveste
        int piv = array[low];
        int i = low;
        int j = high;
        //her finder vi to ting der skal byttes og bytter dem, til sidst returnere vi j så vi ved hvor vi skal starte den næste reccursion.
        while (i<j)
        {
            while (array[i] < piv)
            {
                i++;
            }
            while (array[j] > piv)
            {
                j--;
            }
            
            Swap(array, i, j);
        }
        return j;
       
    }

    public static void Sort(int[] array)
    {
        
        _quickSort(array, 0, array.Length - 1);
        
    }
}