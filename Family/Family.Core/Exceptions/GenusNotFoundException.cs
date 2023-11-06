namespace Family.Core.Exceptions
{
    public class GenusNotFoundException : Exception
    {
        public GenusNotFoundException() { }

        public GenusNotFoundException(string message) : base(message) { }
    }
}
