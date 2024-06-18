namespace AspektAssignment.Shared.CustomExceptions
{
    public class CountryNotFoundException : Exception
    {
        public CountryNotFoundException(string message) : base(message)
        {
        }
    }
}
