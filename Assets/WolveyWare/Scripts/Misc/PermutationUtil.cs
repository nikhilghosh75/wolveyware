using System;
using System.Linq;

public class PermutationUtil 
{
    public static int[] IntArrayFromTo(int from, int to)
    {
        int[] array = new int[to - from];
        for(int i = from; i < to; i++)
        {
            array[i - from] = i;
        }
        return array;
    }

    /// <summary>
    /// Knuth shuffle
    /// Copied from this link: https://stackoverflow.com/questions/14535274/randomly-permutation-of-n-consecutive-integer-number
    /// </summary>        
    public static int[] Shuffle(int[] array)
    {
        Random random = new Random();
        int n = array.Count();
        while (n > 1)
        {
            n--;
            int i = random.Next(n + 1);
            int temp = array[i];
            array[i] = array[n];
            array[n] = temp;
        }

        return array;
    }
}
