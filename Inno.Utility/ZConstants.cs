#region Information
/*
 * Author       : Zng Tfy
 * Email        : nvt87x@gmail.com
 * Phone        : +84 1645 515 010
 * ------------------------------- *
 * Create       : 29/03/2017 07:02
 * Update       : 29/03/2017 07:02
 * Checklist    : 1.0
 * Status       : OK
 */
#region License
/**************************************************************************************************************
 * Copyright © 2012-2017 SKG™ all rights reserved
 **************************************************************************************************************/
#endregion
#region Description
/**************************************************************************************************************
 * All constants
 **************************************************************************************************************/
#endregion
#endregion

using System;

namespace Inno.Utility
{
    /// <summary>
    /// DateTime format string
    /// </summary>
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
        public const string Date = "yyyy-MM-dd";

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
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        public const string SqlDateTimeNoSecond = "yyyy-MM-dd hh:mm";

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

        /// <summary>
        /// dd-MM-yyyy HH:mm:ss
        /// </summary>
        public const string DateTimeNoSecond = "dd/MM/yyyy hh:mm";
    }

    /// <summary>
    /// Special string
    /// </summary>
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

    /// <summary>
    /// Special char
    /// </summary>
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

    /// <summary>
    /// String format
    /// </summary>
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
        public const string Combine2Params = "{0}-{1}";

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
        /// Format normal Reference No CM/DCC/COM/2017/00000025
        /// </summary>
        public const string NormalRefNo = "{0}/{1}/{2}/{3}/{4}";

        /// <summary>
        /// {0};{1};{2}
        /// </summary>
        public const string Data3 = "{0};{1};{2}";
    }

    /// <summary>
    /// Default value
    /// </summary>
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
        /// Prefix name of upload file
        /// </summary>
        public const string PrefixUploadName = "PrefixUpName";

        /// <summary>
        /// Prefix id of div type of work
        /// </summary>
        public const string PrefixTypeId = "PrefixTypeId";

        /// <summary>
        /// Prefix id of div upload file
        /// </summary>
        public const string PrefixUploadId = "PrefixUpId";

        /// <summary>
        /// Prefix MR sub code
        /// </summary>
        public const string PrefixMRSub = "MR_SUBCAT_";

        /// <summary>
        /// Active
        /// </summary>
        public const string Active = "A";

        /// <summary>
        /// Captcha is not valid
        /// </summary>
        public const string InvalidCaptcha = "Captcha is not valid";

        /// <summary>
        /// Password
        /// </summary>
        public const string Password = "A@123!456@Z";

        /// <summary>
        /// Tenant portal host
        /// </summary>
        public const string TenantPortal = "http://localhost:55066/";

        /// <summary>
        /// Home controller
        /// </summary>
        public const string Home = "Home";

        /// <summary>
        /// All numbers
        /// </summary>
        public const string AllNumber = "0123456789";

        /// <summary>
        /// Approver code
        /// </summary>
        public const string ApproverCode = "A";

        /// <summary>
        /// Reviewer code
        /// </summary>
        public const string ReviewerCode = "R";

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
        /// Escalated
        /// </summary>
        public const string Escalated = "Escalated";

        /// <summary>
        /// Escalate
        /// </summary>
        public const string Escalate = "Escalate";

        /// <summary>
        /// Auto Escalate
        /// </summary>
        public const string AutoEscalate = "Auto Escalate";

        /// <summary>
        /// LowerTrue  return true
        /// </summary>
        public const string LowerTrue = "true";

        /// <summary>
        /// Anonymous
        /// </summary>
        public const string Anonymous = "Anonymous";

        /// <summary>
        /// In-House Staff
        /// </summary>
        public const string InHouseStaff = "In-House Staff";

        /// <summary>
        /// Staff
        /// </summary>
        public const string OptionStaff = "STF";

        /// <summary>
        /// Police
        /// </summary>
        public const string OptionPolice = "POL";

        /// <summary>
        /// 3rd Party
        /// </summary>
        public const string Option3rdParty = "3PT";

        /// <summary>
        /// POLICE
        /// </summary>
        public const string POLICE = "POLICE";

        /// <summary>
        /// 3RD
        /// </summary>
        public const string RD3PARTY = "3RD";

        /// <summary>
        /// City Centre Sharjah
        /// </summary>
        public const string SCC = "SCC";

        /// <summary>
        /// PerformMatching
        /// </summary>
        public const string PerformMatching = "PerformMatching";

        /// <summary>
        /// Cancel
        /// </summary>
        public const string Cancel = "Cancel";

        /// <summary>
        /// for On behalf PR search
        /// </summary>
        public const string UserOnBehalf = "(on behalf of  {0})";

        #endregion
        #region -- File --

        public const string F_JPG = ".jpg";

        public const string F_PDF = ".pdf";

        public const string S_FORMAT_IMAGE = "data:image/png;base64,{0}";

        public const string F_EXTENSION_XLSX = ".xlsx";

        public const string F_EXTENSION_CSV = ".csv";

        public const string F_EXTENSION_TXT = ".txt";

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

        //20180604 Frederick changed from 10 MB to 15 MB
        /// <summary>
        /// File max size bytes
        /// </summary>
        public const int FileMaxSize = 15728640;// 10485760;

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

        /// <summary>
        /// Default value Maxlength500
        /// </summary>
        public const int Maxlength250 = 250;
        /// <summary>
        /// Default value Maxlength500
        /// </summary>
        public const int Maxlength500 = 500;

        /// <summary>
        /// Default value Maxlength3000
        /// </summary>
        public const int Maxlength3000 = 3000;

        #endregion

        #region -- Bool --

        /// <summary>
        /// Default value bool
        /// </summary>
        public const bool Bool = false;

        #endregion
    }

    /// <summary>
    /// File accept
    /// </summary>
    public class FileAccept
    {
        /// <summary>
        /// All files
        /// </summary>
        public const string All = "*.*";

        /// <summary>
        /// RangeFileType
        /// </summary>
        public const string RangeFileType = ".doc,.docx,.xls,.xlsx,.ppt,.pptx,.pdf,.png,.gif,.jpg,.jpeg,.xlsm,.csv";

        /// <summary>
        /// All image files
        /// </summary>
        public const string Image = "image/*";
    }

    /// <summary>
    /// Path and Url
    /// </summary>
    public class PathUrl
    {
        public const string CommonPartial = "~/Views/Shared/";

        public const string PRPartial = "~/Views/PermitRequest/Shared/";

        public const string TestPartial = "~/Views/Test/Shared/";

        public const string TenantPartial = "~/Views/Tenant/Shared/"; //20170417 Frederick

        public const string MRPartial = "~/Views/MarketingRequest/Shared/";

        public const string WCPartial = "~/Views/Admin/Shared/";

        public const string UserPartial = "~/Views/User/Shared/";

        public const string AdminPartial = "~/Views/Admin/Shared/";

        public const string LFPartial = "~/Views/LostFound/Shared/";

        public const string CFPartial = "~/Views/ComplaintFeedback/Shared/";

        public const string LOPartial = "~/Views/Loyalty/Shared/";

        public const string UserActivation = "/User/ActiveUser"; // 20170217 Frederick
    }

    public class SharePointSubFolder
    {
        public const string Brand = "Brand Profile";
        public const string Company = "Company Profile";
        public const string Agreements = "Franchisee Agreement";
        public const string TradeLicense = "Trade License";//discuss
        public const string BusinessPlan = "Business Plan";//discuss
        public const string CommercialLicense = "Commercial License";//discuss        
        public const string Others = "Other Lead Documents";
        public const string External = "External";
        public const string SharePoint = "Sharepoint";

    }

    public class YardiWebSvcParam
    {
        public const string YardiLeadProspectRole = "Billing";
        public const string YardiProspectLeasingAgent = "Portal";
        public const string YardiProspectSource = "Website";
        public const string YardiProspectCustomer = "TBD"; //to be determined
        public const string YardiTern = "12";        
    }

    public class YardiWebSvcStatus
    {
        public const string New = "New";
        public const string Error = "Error";
        public const string SendToYardi = "Send To Yardi";
        public const string Withdraw = "Withdrawn";
        public const string SendFromYardi = "Send From Yardi";
    }

    public class IgnoreAddLocalTimeOffset
    {
        public static readonly string[] Columns = new string[] { "MallOpsHoursStart", "MallOpsHoursEnd", "MgmtOfficeOperatingHoursStart",
                                                                    "MgmtOfficeOperatingHoursEnd", "IncidentDate", "ReportedFoundOn", "ReportedLostOn", "WorkingTimingFrom", "WorkingTimingTo" };
    }
    /*public class ResetLocalTimeOffset
    {
        public static readonly string[] Columns = new string[] { "CreatedOn", "SubmittedOn", "ReadDateTime" };
    }*/
}