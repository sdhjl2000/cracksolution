using System;

namespace CrackSolution
{
	public class SortHelper
	{
	
		public static int[] InsertSort(int[] array)
		{
			for (int i = 1; i < array.Length; i++) {
				int val = array [i];
				int j = i - 1;
				while(j>=0&&array[j]>val)
				{
					array [j + 1] = array [j];
					j--;
				}
				array [j+1] = val;
			}
			return array;
		}
		public static int[] BubbleSort(int[] array)
		{
			int length = array.Length;
			while (length > 0) {
				for (int i = 0; i < length-1; i++) {
					int val = array [i + 1];
					if (array [i] > val) {
						array [i + 1] = array [i];
						array [i] = val;
					}
				}
				length--;
			}
			return array;
		}

	}
}

