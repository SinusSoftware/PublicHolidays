namespace System
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Wraps static sort apis into a uniform extension method api.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static partial class PublicHolidays
    {
     
        public enum Bundeslaender
        {
            Baden_Wuerttemberg,
            Bayern,
            Berlin,
            Brandenburg,
            Bremen,
            Hamburg,
            Hessen,
            Mecklenburg_Vorpommern,
            Niedersachsen,
            Nordrhein_Westfalen,
            Rheinland_Pfalz,
            Saarland,
            Sachsen,
            Sachsen_Anhalt,
            Schleswig_Holstein,
            Thüringen
        }

        /// <summary>
        /// Hier eine kurze Beschreibung
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsSundayOrPublicHoliday(this DateTime source)
        {
            if (source.DayOfWeek == DayOfWeek.Sunday)
                return true;

            if (IsTagderDeutschenEinheit(source) ||
                IsErsterWeihnachtstag(source) ||
                IsZweiterWeihnachtstag(source) ||
                IsNeujahrstag(source) ||
                IsErsteMai(source) ||
                IsHeiligeDreiKönige(source) ||
                IsMariaeHimmelfahrt(source) ||
                IsReformationstag(source) ||
                IsAllerheiligen(source)
                )
            {
                return true;
            }

            DateTime ostersonntag = BerechneOstersonntag(source.Year);
            if (IsKarfreitag(ostersonntag, source) ||
                IsOstermontag(ostersonntag, source) ||
                IsChristiHimmelfahrt(ostersonntag, source) ||
                IsPfingstmontag(ostersonntag, source) ||
                IsFronleichnam(ostersonntag, source))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Hier eine kurze Beschreibung
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsSundayOrPublicHoliday(this DateTime source, Bundeslaender bundesland)
        {
            if (source.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            if (IsTagderDeutschenEinheit(source) ||
                IsErsterWeihnachtstag(source) ||
                IsZweiterWeihnachtstag(source) ||
                IsNeujahrstag(source) ||
                IsErsteMai(source))
            {
                return true;
            }

            DateTime ostersonntag = BerechneOstersonntag(source.Year);

            if (bundesland == Bundeslaender.Bayern)
            {
                if (IsHeiligeDreiKönige(source) || IsFronleichnam(ostersonntag, source) || IsMariaeHimmelfahrt(source) || IsAllerheiligen(source))
                {
                    return true;
                }
            }
            else if (bundesland == Bundeslaender.Baden_Wuerttemberg)
            {
                if (IsHeiligeDreiKönige(source) || IsFronleichnam(ostersonntag, source) || IsAllerheiligen(source))
                {
                    return true;
                }
            }
            else if (bundesland == Bundeslaender.Berlin)
            {
            }
            else if (bundesland == Bundeslaender.Brandenburg)
            {
                if (IsReformationstag(source))
                {
                    return true;
                }
            }
            else if (bundesland == Bundeslaender.Bremen)
            {
                if (IsReformationstag(source))
                {
                    return true;
                }
            }
            else if (bundesland == Bundeslaender.Hamburg)
            {
                if (IsReformationstag(source))
                {
                    return true;
                }
            }
            else if (bundesland == Bundeslaender.Hessen)
            {
                if (IsFronleichnam(ostersonntag, source))
                {
                    return true;
                }
            }
            else if (bundesland == Bundeslaender.Mecklenburg_Vorpommern)
            {
                if (IsReformationstag(source))
                {
                    return true;
                }
            }
            else if (bundesland == Bundeslaender.Niedersachsen)
            {
                if (IsReformationstag(source))
                {
                    return true;
                }
            }
            else if (bundesland == Bundeslaender.Nordrhein_Westfalen)
            {
                if (IsFronleichnam(ostersonntag, source) || IsAllerheiligen(source))
                {
                    return true;
                }
            }
            else if (bundesland == Bundeslaender.Rheinland_Pfalz)
            {
                if (IsFronleichnam(ostersonntag, source) || IsAllerheiligen(source))
                {
                    return true;
                }
            }
            else if (bundesland == Bundeslaender.Saarland)
            {
                if (IsFronleichnam(ostersonntag, source) || IsAllerheiligen(source))
                {
                    return true;
                }
            }

            if (IsKarfreitag(ostersonntag, source) ||
                IsOstermontag(ostersonntag, source) ||
                IsChristiHimmelfahrt(ostersonntag, source) ||
                IsPfingstmontag(ostersonntag, source))
            {
                return true;
            }

            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsFronleichnam(DateTime ostersonntag, DateTime source)
        {
            // Pfingstsonntag ist 49 Tage nach Ostersonntag
            DateTime pfingstsonntag = ostersonntag.AddDays(49);
            // Fronleichnam ist 11 Tage nach Pfingstsonntag
            if (pfingstsonntag.Year == source.Year && pfingstsonntag.Month == source.Month && pfingstsonntag.AddDays(11).Day == source.Day)
                return true;
            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsOstermontag(this DateTime source)
        {
            DateTime ostersonntag = BerechneOstersonntag(source.Year);
            return IsOstermontag(ostersonntag, source);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsKarfreitag(this DateTime source)
        {
            DateTime ostersonntag = BerechneOstersonntag(source.Year);
            return IsKarfreitag(ostersonntag, source);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsChristiHimmelfahrt(this DateTime source)
        {
            DateTime ostersonntag = BerechneOstersonntag(source.Year);
            return IsChristiHimmelfahrt(ostersonntag, source);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsPfingstmontag(this DateTime source)
        {
            DateTime ostersonntag = BerechneOstersonntag(source.Year);
            return IsPfingstmontag(ostersonntag, source);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsFronleichnam(this DateTime source)
        {
            DateTime ostersonntag = BerechneOstersonntag(source.Year);
            return IsFronleichnam(ostersonntag, source);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsTagderDeutschenEinheit(DateTime date)
        {
            if (date.Month == 10 && date.Day == 3)
            {
                return true;
            }
            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsErsterWeihnachtstag(DateTime date)
        {
            if (date.Month == 12 && date.Day == 25)
            {
                return true;
            }
            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsZweiterWeihnachtstag(DateTime date)
        {
            if (date.Month == 12 && date.Day == 26)
            {
                return true;
            }
            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsNeujahrstag(DateTime date)
        {
            if (date.Month == 1 && date.Day == 1)
            {
                return true;
            }
            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsErsteMai(DateTime date)
        {
            if (date.Month == 5 && date.Day == 1)
            {
                return true;
            }
            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsHeiligeDreiKönige(DateTime date)
        {
            if (date.Month == 1 && date.Day == 6)
            {
                return true;
            }
            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsMariaeHimmelfahrt(DateTime date)
        {
            if (date.Month == 8 && date.Day == 15)
            {
                return true;
            }
            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsReformationstag(DateTime date)
        {
            if (date.Month == 10 && date.Day == 31)
            {
                return true;
            }
            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAllerheiligen(DateTime date)
        {
            if (date.Month == 11 && date.Day == 1)
            {
                return true;
            }
            return false;
        }

        private static DateTime BerechneOstersonntag(int year)
        {
            // Algorithmen zur Berechnung des Ostersonntags (z.B. Meeus/Jones/Butcher)
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31;
            int day = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateTime(year, month, day);
        }

        private static bool IsOstermontag(DateTime ostersonntag, DateTime source)
        {
            // Ostermontag ist der Tag nach Ostersonntag
            if (ostersonntag.Year == source.Year && ostersonntag.Month == source.Month && ostersonntag.AddDays(1).Day == source.Day)
                return true;
            return false;
        }

        private static bool IsKarfreitag(DateTime ostersonntag, DateTime source)
        {
            // Karfreitag ist der Freitag vor Ostersonntag
            if (ostersonntag.Year == source.Year && ostersonntag.Month == source.Month && ostersonntag.AddDays(-2).Day == source.Day)
                return true;
            return false;
        }

        private static bool IsChristiHimmelfahrt(DateTime ostersonntag, DateTime source)
        {
            // Christi Himmelfahrt ist 40 Tage nach Ostersonntag
            // 39 Tage, da Ostersonntag selbst als Tag 1 zählt
            if (ostersonntag.Year == source.Year && ostersonntag.Month == source.Month && ostersonntag.AddDays(39).Day == source.Day)
                return true;
            return false;
        }

        private static bool IsPfingstmontag(DateTime ostersonntag, DateTime source)
        {
            // Pfingstmontag ist 50 Tage nach Ostersonntag
            if (ostersonntag.Year == source.Year && ostersonntag.Month == source.Month && ostersonntag.AddDays(50).Day == source.Day)
                return true;
            return false;
        }
    }
}