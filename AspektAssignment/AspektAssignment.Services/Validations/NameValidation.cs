namespace AspektAssignment.Services.Validations
{
    public static class NameValidation
    {
        public static bool IsNameValid(string name)
        {
            if(string.IsNullOrEmpty(name) || name.Length > 100)
            {
                return false;
            }
            return true;
        }
    }
}
