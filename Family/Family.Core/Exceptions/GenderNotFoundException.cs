namespace Family.Core.Exceptions
{
    public class GenderNotFoundException : Exception
    {
        public GenderNotFoundException() { }

        public GenderNotFoundException(string message) : base(message) { }
    }
}
