namespace Family.Core.Exceptions
{
    public class ParentNotFoundException : Exception
    {
        public ParentNotFoundException() { }

        public ParentNotFoundException(string message) : base(message) { }
    }
}
