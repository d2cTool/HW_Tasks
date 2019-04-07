namespace MyFirstLib
{
    /// <summary>
    /// Represent a node in linked list.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the node.</typeparam>
    public class Node<T>
    {
        public T Element { get; set; }
        public Node<T> Next { get; set; }
        public bool HasNext => (Next != null);
        public Node(T element)
        {
            Element = element;
        }
    }
}
