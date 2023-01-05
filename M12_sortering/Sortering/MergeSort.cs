namespace Sortering;

public static class MergeSort
{

    private static void Swap(int[] array, int k, int j)
    {
        int tmp = array[k];
        array[k] = array[j];
        array[j] = tmp;
    }

    public static void Sort(int[] array)
    {
        _mergeSort(array, 0, array.Length - 1);
    }

    private static void _mergeSort(int[] array, int l, int h)
    {
        if (l < h)
        {
            int m = (l + h) / 2;
            _mergeSort(array, l, m);
            _mergeSort(array, m + 1, h);
            Merge(array, l, m, h);
        }
    }

    private static void Merge(int[] array, int low, int middle, int high)
    {
        
        List<int> splitL = array.ToList().GetRange(low, middle - low + 1);
        List<int> splitR = array.ToList().GetRange(middle+1, high - middle);

        int k = low;
        while (splitL.Count > 0 && splitR.Count>0)
        {
            if (splitL[0] <= splitR[0])
            {
                array[k] = splitL[0];
                splitL.RemoveAt(0);
            }
            else
            {
                array[k] = splitR[0];
                splitR.RemoveAt(0);
            }
            k++;
        }

        while (splitL.Count > 0)
        {
            array[k] = splitL[0];
            splitL.RemoveAt(0);
            k++;
        }

        
        while (splitR.Count > 0)
        {
            array[k] = splitR[0];
            splitR.RemoveAt(0);
            k++;
        }
    }


}


