namespace Back2Basics.DataStructures.Linear;

public interface ILinkedList<T> where T : notnull
{
    public void Insert(T item);
    public void Remove(T item);
    public void Reverse();
    public void Swap(T item1, T item2);
    public int GetIterativeLength();
    public int GetRecursiveLength();
    public string Print();
}
