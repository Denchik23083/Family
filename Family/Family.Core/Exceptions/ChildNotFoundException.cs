namespace Family.Core.Exceptions
{
    public class ChildNotFoundException : Exception
    {
        public ChildNotFoundException() { }

        public ChildNotFoundException(string message) : base(message) { }
    }
}
