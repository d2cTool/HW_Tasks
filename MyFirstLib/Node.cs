namespace MyFirstLib
{
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
