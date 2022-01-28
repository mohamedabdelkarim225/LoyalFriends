using System;

namespace Inno.Utility
{
    /// <summary>
    /// All constants
    /// </summary>
    public static class Constants
    {

        #region --  Controller Action Methods --
        public struct ActionMethod
        {
            public const string Index = "Index";

        }
        #endregion


        #region -- QueryStringKey --
        public struct QueryStringKey
        {
            public const string ID = "ID";
        }
        #endregion
        

    // <summary>
    // DateTime format string
    // </summary>
    public class DateTimeFormat
        {
            /// <summary>
            /// MMM yyyy
            /// </summary>
            public const string MonthYear = "MMM yyyy";

            /// <summary>
            /// MMM dd
            /// </summary>
            public const string MonthDay = "MMM dd";

            /// <summary>
            /// ddd
            /// </summary>
            public const string Day = "ddd";

            /// <summary>
            /// yy
            /// </summary>
            public const string Year = "yy";

            /// <summary>
            /// dd/MM/yyyy
            /// </summary>
            public const string Date = "dd/MM/yyyy";

            /// <summary>
            /// hh:mm tt
            /// </summary>
            public const string TimeNoSec = "hh:mm tt";

            /// <summary>
            /// HH:mm:ss
            /// </summary>
            public const string Time = "HH:mm:ss";

            /// <summary>
            /// dd-MMM-yyyy hh:mm tt
            /// </summary>
            public const string DateTimeNoSec = Date + " " + TimeNoSec;

            /// <summary>
            /// dd-MMM-yyyy h:mm:ss tt
            /// </summary>
            public const string DateTime = "dd-MMM-yyyy hh:mm:ss tt";

            /// <summary>
            /// yyyy-MM-dd HH:mm:ss
            /// </summary>
            public const string SqlDateTime = "yyyy-MM-dd " + Time;

            /// <summary>
            /// MM/dd/yyyy HH:mm:ss
            /// </summary>
            public const string IsoDateTime = "yyyy/MM/dd " + Time;

            /// <summary>
            /// {0:dd-MMM-yyyy h:mm tt}
            /// </summary>
            public const string GridDateTimeNoSec = "{0:" + DateTimeNoSec + "}";

            /// <summary>
            /// {0:dd-MMM-yyyy h:mm:ss tt}
            /// </summary>
            public const string GridDateTime = "{0:" + DateTime + "}";

            /// <summary>
            /// {0:dd-MMM-yyyy}
            /// </summary>
            public const string GridDate = "{0:" + Date + "}";

            /// <summary>
            /// {0:hh:mm tt}
            /// </summary>
            public const string GridTime = "{0:" + TimeNoSec + "}";
        }

    // <summary>
    // Special string
    // </summary>
    public class SpecialString
        {
            public const string Slash = "/";

            public const string BackSlash = @"\";

            public const string Space = " ";

            public const string Semicolon = ";";

            public const string Comma = ",";

            public const string Question = "?";

            public const string Asterisk = "*";

            public const string Caret = "^";

            public const string Plus = "+";

            public const string Blank = "";

            public const string Hyphen = "-";

            public const string Dot = ".";

            public const string Quotation = "\"";

            public const string LeftSquare = "[";

            public const string RightSquare = "]";

            public const string Underscore = "_";

            public const string VBar = "|";

            public const string Ampersand = "&";

            public const string Percent = "%";

            /// <summary>
            /// +-
            /// </summary>
            public const string PlusHyphen = Plus + Hyphen;

            /// <summary>
            /// +--
            /// </summary>
            public const string PlusHyphenHyphen = PlusHyphen + Hyphen;

            /// <summary>
            /// --
            /// </summary>
            public const string DoubleHyphen = Hyphen + Hyphen;

            /// <summary>
            /// ", "
            /// </summary>
            public const string CommaSpace = Comma + Space;

            /// <summary>
            /// " - "
            /// </summary>
            public const string SpaceMinusSpace = Space + Hyphen + Space;

            /// <summary>
            /// //
            /// </summary>
            public const string DouleSlash = Slash + Slash;

            public const string CarriageReturn = "\r\n";

            public const string BrTag = "<br/>";

            /// <summary>
            /// Vietnamese dong
            /// </summary>
            public const string VND = "₫";

            /// <summary>
            /// United States dollar 
            /// </summary>
            public const string USD = "$";
        }

    // <summary>
    // Special char
    // </summary>
    public class SpecialChar
        {
            public const char Slash = '/';

            public const char BackSlash = '\\';

            public const char Space = ' ';

            public const char Semicolon = ';';

            public const char Comma = ',';

            public const char Question = '?';

            public const char Asterisk = '*';

            public const char Caret = '^';

            public const char Plus = '+';

            public const char Hyphen = '-';

            public const char Dot = '.';

            public const char Quotation = '"';

            public const char LeftSquare = '[';

            public const char RightSquare = ']';

            public const char Underscore = '_';

            public const char VBar = '|';

            public const char Ampersand = '&';

            public const char Percent = '%';

            public const char Colon = ':';
        }

    // <summary>
    // String format
    // </summary>
    public class StringFormat
        {
            /// <summary>
            /// {0}://{1}
            /// </summary>
            public const string Host = "{0}://{1}";

            /// <summary>
            /// {0} / {1}{2}{3} / {4}
            /// </summary>
            public const string ContactPerson = "{0} / {1}{2}{3} / {4}";

            /// <summary>
            /// {0} / {1}
            /// </summary>
            public const string Combine = "{0} / {1}";

            /// <summary>
            /// {0} ({1})
            /// </summary>
            public const string CombineParentheses = "{0} ({1})";

            /// <summary>
            /// {0}-{1}
            /// </summary>
            public const string Combine2Params = "{0} - {1}";

            /// <summary>
            /// {0} {1} {2}
            /// </summary>
            public const string Combine3Params = "{0} {1} {2}";

            /// <summary>
            /// ({0}-{1})
            /// </summary>
            public const string CombineParentheses2 = "(" + Combine2Params + ")";

            /// <summary>
            /// ({0})
            /// </summary>
            public const string Combine1Param = "({0})";

            /// <summary>
            /// {0} - {1}, {2} - {3}
            /// </summary>
            public const string CombineDateTimeRange = "{0} - {1}, {2} - {3}";

            /// <summary>
            /// data:image;base64,{0}
            /// </summary>
            public const string ImageBase64 = "data:image;base64,{0}";

            /// <summary>
            /// Reset password link
            /// </summary>
            public const string ResetLink = "<a style='font-size:17px;' href='{0}'>Click here to reset your password</a>";

            /// <summary>
            /// +{0}-{1}-{2}
            /// For ContactNo in Lost and Found
            /// </summary>
            public const string CombineContactNo = "+{0}-{1}-{2}";

            /// <summary>
            /// Format file name
            /// </summary>
            public const string FileName = "{0}_{1:yyyyMMdd-HHmm}.{2}";

            /// <summary>
            /// Format custom Reference No DCC/17/25
            /// </summary>
            public const string CustomRefNo = "{0}/{1}/{2}";

   
            /// <summary>
            /// {0};{1};{2}
            /// </summary>
            public const string Data3 = "{0};{1};{2}";
        }

    // <summary>
    // Default value
    // </summary>
    public class DefaultValue
        {
            #region -- DateTime --

            /// <summary>
            /// Min date
            /// </summary>
            public static DateTime MinDate = new DateTime(1900, 1, 1);

            /// <summary>
            /// Max date
            /// </summary>
            public static DateTime MaxDate = new DateTime(2099, 12, 31);

            /// <summary>
            /// Start date event calendar
            /// </summary>
            public static DateTime StartEvent = new DateTime(2013, 6, 13, 0, 0, 0);

            #endregion

            #region -- String --
            /// <summary>
            /// To
            /// </summary>
            public const string To = " To ";

            /// <summary>
            /// No
            /// </summary>
            public const string No = "No";

            /// <summary>
            /// Yes
            /// </summary>
            public const string Yes = "Yes";

            /// <summary>
            /// Default value object
            /// </summary>
            public const string Object = null;

            /// <summary>
            /// True
            /// </summary>
            public const string True = "True";

            /// <summary>
            /// LowerTrue  return true
            /// </summary>
            public const string LowerTrue = "true";

            #endregion

            #region -- Int --

            /// <summary>
            /// Minimum year
            /// </summary>
            public const int MinYear = 2010;

            /// <summary>
            /// Maximum year
            /// </summary>
            public const int MaxYear = 2100;

            /// <summary>
            /// Max items per row
            /// </summary>
            public const int MaxItems = 4;

            /// <summary>
            /// Max MR items for list
            /// </summary>
            public const int MaxMRItems = 7;

            /// <summary>
            /// File max size bytes
            /// </summary>
            public const int FileMaxSize = 2097152;

            /// <summary>
            /// Expired time life of URL reset password
            /// </summary>
            public const int ExpiredTimeLife = 1440;

            /// <summary>
            /// Captcha size
            /// </summary>
            public const int CaptchaSize = 5;

            /// <summary>
            /// Event calendar Holiday code
            /// </summary>
            public const int HolidayCode = 6;

            /// <summary>
            /// Request amount related
            /// </summary>
            public const int RequestAmount = 5;

            /// <summary>
            /// Page
            /// </summary>
            public const int Page = 1;

            /// <summary>
            /// Page size
            /// </summary>
            public const int PageSize = 10;

            /// <summary>
            /// Default value int
            /// </summary>
            public const int Int = 0;

            #endregion

            #region -- Bool --

            /// <summary>
            /// Default value bool
            /// </summary>
            public const bool Bool = false;

            #endregion
        }

    // <summary>
    // File accept
    // </summary>
    public class FileAccept
        {
            /// <summary>
            /// All files
            /// </summary>
            public const string All = "*.*";

            /// <summary>
            /// All image files
            /// </summary>
            public const string Image = "image/*";
        }

    // <summary>
    // Path and Url
    // </summary>
    public class PathUrl
        {
            public const string AdminPartial = "~/Views/Admin/Shared/";
        }
    }
    }