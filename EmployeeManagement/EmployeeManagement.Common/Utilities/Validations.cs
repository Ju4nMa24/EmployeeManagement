using EmployeeManagement.Common.Constants;
using EmployeeManagement.Common.Constants.Enums;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

namespace EmployeeManagement.Common.Utilities
{
    public partial class Validations
    {
        /// <summary>
        /// This method is used to validate id.
        /// </summary>
        /// <param name="identification"></param>
        /// <returns></returns>
        public static bool IsIdentification(string identification) =>
            (CitizenshipCard().IsMatch(identification) || ForeignerId().IsMatch(identification) || Nit().IsMatch(identification));
        /// <summary>
        /// This method is used to format validate.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsImage(string path)
        {
            string? extension = Path.GetExtension(path)?.Replace(".", string.Empty).ToLowerInvariant().ToUpper();
            return extension == Formats.JPG.ToString() || extension == Formats.BMP.ToString()
                || extension == Formats.JPEG.ToString() || extension == Formats.GIF.ToString() || extension == Formats.PNG.ToString();
        }
        /// <summary>
        /// This method is used to validate plate.
        /// </summary>
        /// <param name="plate"></param>
        /// <returns></returns>
        public static bool IsAlphanumericAndHyphen(string text) => (AlphanumericAndHyphen().IsMatch(text));
        /// <summary>
        /// This method is used to validate text, making it alphanumeric.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsAlpanumeric(string text) => (Alpanumeric().IsMatch(text));

        /// <summary>
        /// This method is used to validate text, making it numeric.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNumeric(int text) => (Numeric().IsMatch(text.ToString()));
        /// <summary>
        /// This method is used to validate decimals.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsDecimal(string? text) => decimal.TryParse(text, out _);
        /// <summary>
        /// This method is used to validate date time.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsDateTime(DateTime date) => DateTime.TryParseExact(date.ToString(), Types.FORMAT_DATE, null, DateTimeStyles.None, out _);
        /// <summary>
        /// This method is used to validate ip address.
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIpAddress(string ip) => IPAddress.TryParse(ip, out _);
        /// <summary>
        /// This method is used to validate file path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsPath(string path) => Path.IsPathRooted(path);
        #region Regrex Validations
        [GeneratedRegex(RegularExpressions.NUMERIC)]
        private static partial Regex Numeric();
        [GeneratedRegex(RegularExpressions.ALPHANUMERIC)]
        private static partial Regex Alpanumeric();
        [GeneratedRegex(RegularExpressions.ALPHANUMERIC_AND_HYPHEN)]
        private static partial Regex AlphanumericAndHyphen();
        [GeneratedRegex(RegularExpressions.ONLY_CC)]
        private static partial Regex CitizenshipCard();
        [GeneratedRegex(RegularExpressions.ONLY_CE)]
        private static partial Regex ForeignerId();
        [GeneratedRegex(RegularExpressions.ONLY_NIT)]
        private static partial Regex Nit();
        #endregion
    }
}
