namespace EmployeeManagement.Common.Constants
{
    public class RegularExpressions
    {
        public const string ONLY_TEXT = @"^[a-zA-Z\s]+$";
        public const string ALPHANUMERIC_AND_HYPHEN = @"^[a-zA-Z0-9-]*$";
        public const string ALPHANUMERIC = @"^[a-zA-Z0-9]*$";
        public const string NUMERIC = @"^[0-9]*$";
        public const string ONLY_CC = @"^\d{1,10}$";
        public const string ONLY_CE = @"^[a-zA-Z]\d{1,10}$";
        public const string ONLY_NIT = @"^\d{9,15}$";
    }
}
