using System.Text;
using Back2Basics.DataStructures.Linear;

namespace DataStructures.Linear.SingleLinkedList;

public sealed class LinkedList<T> : ILinkedList<T> where T : notnull
{
    public sealed class Node(T value)
    {
        public T Value { get; set; } = value;
        public Node? Next { get; set; } = null;
    }

    public LinkedList(IReadOnlyCollection<T> x)
    {
        Head = new Node(x.First());
        foreach (var x2 in x.Skip(1))
            Insert(x2);
    }

    public Node Head { get; set; }

    public void Insert(T item)
    {
        var iter = Head;

        while (iter.Next != null)
            iter = iter.Next;

        iter.Next = new Node(item);
    }

    public string Print()
    {
        var strb = new StringBuilder();
        var iter = Head;
        while (iter != null)
        {
            var apend = "";
            if (iter.Next != null)
                apend = " -> ";

            strb.Append(iter.Value.ToString() + apend);
            iter = iter.Next;
        }

        return strb.ToString();
    }

    public void Remove(T item)
    {
        Node? prev = null;
        var iter = Head;

        while (iter != null)
        {
            if (iter.Value!.Equals(item) && prev == null && iter.Next != null)
            {
                Head = iter.Next;
                return;
            }

            if (iter.Value!.Equals(item) && prev != null)
            {
                prev.Next = iter.Next;
                return;
            }

            prev = iter;
            iter = iter.Next;
        }
    }

    public void Reverse()
    {
        var iter = Head;
        Node? prev = null;

        while (iter != null)
        {
            var next = iter.Next;
            iter.Next = prev;
            prev = iter;
            iter = next;

            if (iter == null)
                Head = prev;
        }
    }

    public void Swap(T item1, T item2)
    {
        var iter = Head;

        Node? item1Prev = null;
        Node? item1Node = null;
        Node? item1Next = null;

        Node? item2Prev = null;
        Node? item2Node = null;
        Node? item2Next = null;

        Node? prev = null;
        while (iter != null)
        {
            if (iter.Value!.Equals(item1))
            {
                item1Prev = prev;
                item1Node = iter;
                item1Next = iter.Next;
            }

            if (iter.Value!.Equals(item2))
            {
                item2Prev = prev;
                item2Node = iter;
                item2Next = iter.Next;
            }

            prev = iter;
            iter = iter.Next;
        }

        if (item1Prev is not null)
        {
            item1Prev.Next = item2Node;
        }
        else
        {
            Head = item2Node!;
        }
        item2Node!.Next = item1Next;
        if (item2Prev is not null)
        {
            item2Prev.Next = item1Node;
        }
        else
        {
            Head = item1Node!;
        }
        item1Node!.Next = item2Next;
    }

    public int GetIterativeLength()
    {
        var iter = Head;
        var i = 0;
        while (iter != null)
        {
            i++;
            iter = iter.Next;
        }

        return i;
    }

    public int GetRecursiveLength()
    {
        return GetLength(Head);

        static int GetLength(Node? node)
        {
            if (node == null)
                return 0;

            return 1 + GetLength(node.Next);
        }
    }
}