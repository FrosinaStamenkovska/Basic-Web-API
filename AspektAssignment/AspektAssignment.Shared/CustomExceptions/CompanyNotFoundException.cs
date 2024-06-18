namespace AspektAssignment.Shared.CustomExceptions
{
    public class CompanyNotFoundException : Exception
    {
        public CompanyNotFoundException(string message) : base(message)
        {
        }
    }
}
