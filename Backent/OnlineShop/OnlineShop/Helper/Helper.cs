using Newtonsoft.Json;
using Persia;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace OnlineShop
{
    public static class Helper
    {
        public static string ToEnglishNumber(this string number)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var arabicDigits = new char[10] { '٠', '١', '٢', '٣', '٤', '٥', '٦', '٧', '٨', '٩' };
                var persianDigits = new char[10] { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };
                var englishDigits = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                if (!string.IsNullOrEmpty(number))
                    for (int i = 0; i < persianDigits.Length; i++)
                        number = number.Replace(persianDigits[i], englishDigits[i]).Replace(arabicDigits[i], englishDigits[i]);

                var englishNumber = number;
                //Log.Trace(ProjectValues.SuccessfulLog, sw.Elapsed.TotalMilliseconds);
                return englishNumber;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static T ToEnum<T>(this string stringValue) where T : struct
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var enumValue = (T)Enum.Parse(typeof(T), stringValue, true);

                //Log.Trace(ProjectValues.SuccessfulLog, sw.Elapsed.TotalMilliseconds);
                return enumValue;
            }
            catch (Exception ex)
            {
                return default;
            }
        }
        public static string ToPersianNumber(this string number)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var persianNumber = (string)null;
                if (!string.IsNullOrEmpty(number))
                    persianNumber = PersianWord.ToPersianString(number);

                //Log.Trace(ProjectValues.SuccessfulLog, sw.Elapsed.TotalMilliseconds);
                return persianNumber;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string ToSafePersianString(this string persianString)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var safePersianString = persianString;
                if (!string.IsNullOrEmpty(persianString))
                    safePersianString = persianString.Replace('ي', 'ی').Replace('ك', 'ک');

                //Log.Trace(ProjectValues.SuccessfulLog, sw.Elapsed.TotalMilliseconds);
                return safePersianString;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool TryGetValue<T>(this DataRow dataRow, int columnIndex, out T output)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                output = dataRow.Field<T>(columnIndex);
                return true;
            }
            catch (Exception ex)
            {
                output = default;
                return false;
            }
        }
        public static T JsonDeserializer<T>(string jsonString, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var instance = JsonConvert.DeserializeObject<T>(jsonString);

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return instance;
            }
            catch (Exception ex)
            {
                return default;
            }
        }
        public static string JsonSerializer<T>(T jsonObject)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var jsonString = JsonConvert.SerializeObject(jsonObject);

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return jsonString;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static long LongRandom(this Random random, long min, long max)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                byte[] buf = new byte[8];
                random.NextBytes(buf);
                long longRand = BitConverter.ToInt64(buf, 0);

                return Math.Abs(longRand % (max - min)) + min;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static DateTime? ShamsiDDMMYYToGregorianDateTime(string date, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var temp = date.Replace("/", "");
                if (temp.Contains("فوری"))
                    return null;

                var dateParts = date.Split('/');
                var gregorianDateTime = Calendar.ConvertToGregorian(ParseShamsiYear(dateParts[2]), Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[0]), DateType.Persian);

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return gregorianDateTime;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DateTime? ShamsiYYMMDDDateTimeToGregorianDateTime(string date, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var temp = date.Replace("/", "");
                if (temp.Contains("فوری"))
                    return null;

                if (!date.Contains("/"))
                    date = date.Insert(2, "/").Insert(5, "/");
                var dateParts = date.Split('/');
                var gregorianDateTime = Calendar.ConvertToGregorian(ParseShamsiYear(dateParts[0]), Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[2]), DateType.Persian);

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return gregorianDateTime;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DateTime? ShamsiYYYYMMDDDateTimeToGregorianDateTime(string date, char splitter = '/', [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var dateParts = date.Split(splitter);
                var y = Convert.ToInt32(dateParts[0]);
                var m = Convert.ToInt32(dateParts[1]);
                var d = Convert.ToInt32(dateParts[2]);
                var gregorianDateTime = Calendar.ConvertToGregorian(Convert.ToInt32(dateParts[0]), Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[2]), DateType.Persian);

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return gregorianDateTime;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DateTime? ShamsiYYYYMMDDHHTTDateTimeToGregorianDateTime(string dateTime, char splitter = ' ', [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var dateTimeParts = dateTime.Split(new char[] { splitter }, StringSplitOptions.RemoveEmptyEntries);
                var date = dateTimeParts[0].Split('/');
                var time = dateTimeParts[1].Split(':');
                var gregorianDateTime = Calendar.ConvertToGregorian(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), 0, DateType.Persian);

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return gregorianDateTime;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DateTime? ShamsiYYMMDDHHTTDateTimeToGregorianDateTime(string dateTime, char splitter = ' ', [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var temp = dateTime.Replace("/", "");
                if (temp.Contains("فوری"))
                    return null;

                var dateTimeParts = dateTime.Split(new char[] { splitter }, StringSplitOptions.RemoveEmptyEntries);
                var date = dateTimeParts[0].Split('/');
                var time = dateTimeParts[1].Split(':');
                var gregorianDateTime = Calendar.ConvertToGregorian(ParseShamsiYear(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), 0, DateType.Persian);

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return gregorianDateTime;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string ToGregorianDateTime(DateTime? dateTime)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var gregorianDateTime = dateTime.HasValue ? dateTime.Value.ToString("s") : null;

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return gregorianDateTime;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string ToPersianDateTime(DateTime? dateTime)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                if (!dateTime.HasValue)
                    return "نامشخص";

                var solarDateTime = Calendar.ConvertToPersian(dateTime.Value);
                var solarDateTimeString = solarDateTime.ToString();

                var time = dateTime.Value.ToString("HH:mm");
                if (!string.Equals(time, "00:00"))
                    solarDateTimeString = solarDateTimeString + " " + time;

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return solarDateTimeString;
            }
            catch (Exception ex)
            {
                return "نامشخص";
            }
        }
        public static string ToPersianDate(string date, char splitter = '/')
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var dateParts = date.Split(splitter);
                var y = Convert.ToInt32(dateParts[0]);
                var m = Convert.ToInt32(dateParts[1]);
                var d = Convert.ToInt32(dateParts[2]);
                var shamiDate = Calendar.ConvertToPersian(new DateTime(y, m, d)).ToString();

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return shamiDate;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static int ParseShamsiYear(string yearPart)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var year = 0;
                if (yearPart.Length == 1)
                {
                    year = Convert.ToInt32("14" + yearPart + "0");
                }
                else if (yearPart.Length == 2)
                {
                    if (Convert.ToInt64(yearPart) > 90)
                        year = Convert.ToInt32("13" + yearPart);
                    else
                        year = Convert.ToInt32("14" + yearPart);
                }
                else if (yearPart.Length == 4)
                {
                    year = Convert.ToInt32(yearPart);
                }
               

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return year;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static string AddSplitterToShamsiYYYYMMDDDateTimeToGregorianDateTime(string date)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var dateTime = date.Insert(4, "/");
                dateTime = dateTime.Insert(7, "/");

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return dateTime;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static long ToEpoch(DateTime dateTime)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var dateWithOffset = new DateTimeOffset(dateTime).ToUniversalTime();
                long epochTime = dateWithOffset.ToUnixTimeMilliseconds();

                return epochTime;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static string ToThousandSepratedInt(this string numberString)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                if (string.IsNullOrEmpty(numberString))
                {
                    return numberString;
                }

                double.TryParse($"{numberString.ToEnglishNumber()}", out double number);
                return number.ToString("#,##0;-#,##0;0");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string ToThousandSepratedInt(this long number)
        {
            return number.ToString("#,##0;-#,##0;0");
        }
        public static string ToThousandSepratedInt(this long? number)
        {
            if (number == null)
            {
                return null;
            }

            return ((long)number).ToString("#,##0;-#,##0;0");
        }
        public static string AddRials(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            return $"{str} ریال";
        }
        public static string ToThousandSepratedPersianNumber(this string numberString)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                if (string.IsNullOrEmpty(numberString))
                {
                    return numberString;
                }

                long.TryParse(numberString.ToEnglishNumber().ExtractJustTheDigits(), out long number);
                return number.ToString("#,##0").ToPersianNumber();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string ToThousandSepratedIntWithAddRials(this string numberString)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                if (string.IsNullOrEmpty(numberString))
                {
                    return AddRials("0");
                }

                var format = new System.Globalization.NumberFormatInfo
                {
                    NegativeSign = "-",
                    NumberDecimalSeparator = "."
                };
                double.TryParse($"{numberString.ToEnglishNumber()}", System.Globalization.NumberStyles.Float, format, out double number);
                return AddRials(number.ToString("#,##0;-#,##0;0"));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string ExtractJustTheDigits(this string text)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var justNumbers = string.IsNullOrEmpty(text) ? null : new string(text.Where(char.IsDigit).ToArray());

                //Log.Trace("successfully completed.", sw.ElapsedMilliseconds);
                return justNumbers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}