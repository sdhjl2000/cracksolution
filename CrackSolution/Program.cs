using System;

namespace CrackSolution
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Console.WriteLine (RemoveDuplicate("aaab"));
			//Console.WriteLine (RemoveDuplicate("ababc"));
			//Console.WriteLine (RemoveDuplicate("abcabcd"));
			//Console.WriteLine (RemoveDuplicate("eabcdaec"));
			//Console.WriteLine (IsRotation("erbottlewat","aterbottlew"));
			//Console.WriteLine (IsRotation("hujinjinliang","liangjinhujin"));
			Node first = new Node (10);
			Node first2 = new Node (19);
			Node first3 = new Node (8);
			Node first4 = new Node (17);
			Stack st = new Stack (1);
			st.Push (first);
			st.Push (first2);
			st.Push (first3);
			st.Push (first4);

			Stack st2 = new Stack (2);
			Stack st3 = new Stack (3);
			//OrderStack (st, st2, 0);
			st.Dump ();
			st2.Dump ();
			st3.Dump ();
			//MoveTower (st, st3, st2,st.Count);
			//st.Dump ();
			//st2.Dump ();
			//st3.Dump ();
			//TestAddList ();
			//GeneratePar (3);

			int[] array=new int[]{3,4,5,7,2,4,8};
			var result = SortHelper.BubbleSort (array);
			foreach (var i in result) {
				Console.WriteLine (i);
			}
			Console.ReadLine ();
		}

		public static void GeneratePar(int count)
		{
			char[] str = new char[count*2];
			printPar(count, count, str, 0);
		}

		public static void printPar(int left,int right,char[] str,int count)
		{
			if (left >= 0 && right >= 0 && left <= right) {

				if (left == 0 && right == 0) {
					Console.WriteLine (str);
				} else {
					if (left > 0) {
						str [count] = '(';
						printPar (left - 1, right, str, count + 1);
					}
					if (right > 0) {
						str [count] = ')';
						printPar (left, right - 1, str, count + 1);
					}
				}
			}
		}

		public static void MoveTower(Stack now ,Stack to,Stack temp,int count)
		{ 
			if (now.Count == 0||count==0)
				return;
//			if (count == 1) {
//				Node n = now.Pop ();
//				to.Push (n);
//				Console.WriteLine (n.data.ToString()+" From " + now.StackIndex.ToString () + " " + to.StackIndex.ToString ());
//				return;
//			}
			 
			MoveTower (now, temp, to, count-1);
			if (now.Count > 0) {
				Node m = now.Pop ();
				to.Push (m);
				Console.WriteLine (m.data.ToString()+" InsideFrom " + now.StackIndex.ToString () + " " + to.StackIndex.ToString ());
			}
			MoveTower (temp, to, now, count-1);
			 
		}

		public static void OrderStack(Stack s1,Stack s2,int count)
		{
			if (s1.Count == 0) {
				return;
			}
			Node max = new Node (0);
			while (s1.Count > 0) {
				Node node = s1.Pop ();
				if (node.data > max.data) {
					max = node;
				}
				s2.Push (node);
			}
			while (s2.Count > count) {
				Node node = s2.Pop ();
				if (node.data != max.data) {
					s1.Push (node);
				}
			}
			s2.Push (max);
			count++;
			OrderStack (s1, s2, count);
		}

		static void TestStack ()
		{
			Node first = new Node (10);
			Node first2 = new Node (8);
			Node first3 = new Node (7);
			Stack st = new Stack (1);
			st.Push (first);
			st.Push (first2);
			Console.WriteLine (st.Pop ().data);
			st.Push (first3);
			Console.WriteLine (st.Pop ().data);
			Console.WriteLine (st.Pop ().data);
		}

		static void TestAddList ()
		{
			Node first = new Node (3);
			Node first2 = new Node (1);
			Node first3 = new Node (5);
			first.next = first2;
			first2.next = first3;


			Node second = new Node (5);
			Node second2 = new Node (9);
			Node second3 = new Node (2);
			second.next = second2;
			second2.next = second3;

			var node = AddList (null, first, second, false);
			while (node != null) {
				Console.WriteLine (node.data);
				node = node.next;
			}
			 
		}
		public static Node AddList(Node pre,Node n1,Node n2,bool addone)
		{
			var datasum = n1.data + n2.data + (addone ? 1 : 0);
			if (datasum >= 10) {
				addone = true;
				datasum = datasum - 10;
			} else {
				addone = false;
			}
			Node current = new Node (datasum);
			if (n1.next != null) {
				AddList (current, n1.next, n2.next, addone);
			}
			if (pre != null) {
				pre.next = current;
			} 
			return current;
		}
		public static bool IsRotation(string str1,string str2)
		{
			var list1 = str1.ToCharArray ();
			var list2 = str2.ToCharArray ();
			var l1 = list1.Length;
			var l2 = list2.Length;
			if (l1 != l2)
				return false;
		 
				for (int j = 0; j < l2; j++) {
					bool istoend = false;
				if (list2 [j] == list1 [0]) {
						istoend = true;
						var currentadd = 0;
						while (j + currentadd < l2-1) {
							currentadd++;
							if (list2 [j + currentadd] != list1 [ currentadd]) {
								istoend = false;break;
							}
						}
					}
					if (istoend) {
						if (str1.Contains (str2.Substring (0, j)))
							return true;
					}


			}
			return false;

		}

		public static string ReverseStr(string str)
		{
			char temp;
			var charlist = str.ToCharArray ();
			for (int i = 0; i < charlist.Length / 2; i++) {
				temp = charlist [i];
				charlist [i] = charlist [charlist.Length - i-1];
				charlist [charlist.Length - i-1] = temp;
			}
			return String.Join ("", charlist);
		}
		public static string RemoveDuplicate(string str)
		{
			int currentindex ;
			int shortstrlenght = 1;
			bool iscurrentdu = false;
			bool ispredu = false;
			var charlist = str.ToCharArray ();
			for (currentindex = 1; currentindex < charlist.Length ; currentindex++) {
				var nextchar = charlist [currentindex];
				iscurrentdu = false;
				for (int i = 0; i < shortstrlenght; i++) {
					if (charlist [i] == nextchar) {
						iscurrentdu = true;break;
					}
				}
				if (!iscurrentdu) {
					shortstrlenght++;
					if (ispredu) {
						charlist [shortstrlenght-1] = nextchar;
					}
				}
				ispredu = iscurrentdu;
			}
			//Console.WriteLine (string.Join ("", charlist));
			return string.Join ("", charlist).Substring (0, shortstrlenght);
		}
	}
}
