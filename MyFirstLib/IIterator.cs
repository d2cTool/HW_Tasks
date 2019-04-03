namespace MyFirstLib
{
    public interface IIterator<T>
    {
        T First();
        T Next();
        T Current { get; }
        bool IsDone { get; }
    }
}
