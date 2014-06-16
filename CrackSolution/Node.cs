using System;
using System.Text;

namespace CrackSolution
{
	public class Node
	{
		public Node next;
		public int data;
		public Node (int idata)
		{
			data = idata;
		}
	}

	public class Stack
	{
		public Node top;
		public int Count;
		public int StackIndex;
		public Stack(int index)
		{
			StackIndex = index;
		}
		public Node Pop(){
			if (top != null) {
				var temp = top;
				top = top.next;
				Count--;
				return temp;
			}

			return null;
		}
		public void Push(Node node)
		{
			Count++;
			node.next = top;
			top = node;
		}

		public  void Dump()
		{
			Node head=top;

			StringBuilder str = new StringBuilder ();
			while(head!=null)
			{
				str.Append(head.data.ToString()+"-");
				head=head.next;
			}
			Console.WriteLine ("StatckIndex " + StackIndex.ToString ()+":"+str.ToString());
		}

	}
	public class Queue
	{

		public Node first,last;
		public void Enqueue(Node node)
		{
			if (first == null) {
				first = node;
				last = node;
			} else {
				node.next = first;
				first = node;
			}
		}
		public Node Dequeue()
		{
			if (last != null) {
				var temp = last;

			}
			return null;
		}
	}
}

