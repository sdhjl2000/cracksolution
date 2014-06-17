using System;
using System.Linq;
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
		public static void QuickSort(int[] array,int left,int right)
		{
			if (left < right) {
				int middle = array [(left + right )/ 2];
				int i = left - 1;
				int j = right + 1;
				while (true) {
					while (array [++i] < middle);
					while (array [--j] > middle);
					if (i >= j) {
						break;
					}
					Swap (array, i, j);
				}
				QuickSort(array, left, i - 1);
				QuickSort(array, j + 1, right);
			}
		}

		private static void Swap(int[] numbers, int i, int j)
		{
			Console.WriteLine( string.Join (",", numbers.Select (x => x.ToString ()).ToArray ()));
			Console.WriteLine ("Swap I:" + i.ToString () + "("+numbers[i].ToString()+") To J:" + j.ToString ()+"("+numbers[j].ToString()+")");
			int number = numbers[i];
			numbers[i] = numbers[j];
			numbers[j] = number;
			Console.WriteLine( string.Join (",", numbers.Select (x => x.ToString ()).ToArray ()));
		}

	}
}

