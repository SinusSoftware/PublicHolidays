namespace System
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Wraps static sort apis into a uniform extension method api.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static partial class PublicHolidays
    {
        ///<summary></summary>
        public enum FederalStates
        {
            ///<summary></summary>
            Baden_Wuerttemberg,
            ///<summary></summary>
            Bavaria,
            ///<summary></summary>
            Berlin,
            ///<summary></summary>
            Brandenburg,
            ///<summary></summary>
            Bremen,
            ///<summary></summary>
            Hamburg,
            ///<summary></summary>
            Hesse,
            ///<summary></summary>
            Mecklenburg_Western_Pomerania,
            ///<summary></summary>
            Lower_Saxony,
            ///<summary></summary>
            North_Rhine_Westphalia,
            ///<summary></summary>
            Rhineland_Palatinate,
            ///<summary></summary>
            Saarland,
            ///<summary></summary>
            Saxony,
            ///<summary></summary>
            Saxony_Anhalt,
            ///<summary></summary>
            Schleswig_Holstein,
            ///<summary></summary>
            Thuringia
        }

        /// <summary>
        /// The day is a Sunday or public holiday anywhere in germany<br/>
        /// Der Tag ist ein Sonntag oder ein öffentlicher Feiertag in irgendeinem Bundesland
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsSundayOrPublicHoliday(this DateTime source)
        {
            if (source.DayOfWeek == DayOfWeek.Sunday)
                return true;

            if (IsDayOfGermanUnity(source) ||
                IsFirstChristmasDay(source) ||
                IsBoxingDay(source) ||
                IsNewYearsDay(source) ||
                IsLabourDay(source) ||
                IsEpiphany(source) ||
                IsAssumptionDay(source) ||
                IsReformationDay(source) ||
                IsAllSaintsDay(source) ||
                IsRepentanceAndPrayerDay(source) ||
                IsWorldChildrensDay(source) ||
                IsInternationalWomensDay(source) ||
                IsAnniversaryOfTheLiberationFromNationalSocialismAndTheEndOfTheSecondWorldWar(source)
                )
            {
                return true;
            }

            DateTime ostersonntag = CalculateEasterSunday(source.Year);
            if (IsGoodFriday(ostersonntag, source) ||
                IsEasterMonday(ostersonntag, source) ||
                IsAscensionOfChrist(ostersonntag, source) ||
                IsWhitMonday(ostersonntag, source) ||
                IsCorpusChristi(ostersonntag, source))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// The day is a Sunday or public holiday on a spezified federal state<br/>
        /// Der Tag ist ein Sonntag oder ein öffentlicher Feiertag in einem bestimmten Bundesland
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsSundayOrPublicHoliday(this DateTime source, FederalStates bundesland)
        {
            if (source.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            if (IsDayOfGermanUnity(source) ||
                IsFirstChristmasDay(source) ||
                IsBoxingDay(source) ||
                IsNewYearsDay(source) ||
                IsLabourDay(source) ||
                IsReformationDay(source, bundesland) ||
                IsRepentanceAndPrayerDay(source, bundesland) ||
                IsAnniversaryOfTheLiberationFromNationalSocialismAndTheEndOfTheSecondWorldWar(source, bundesland) ||
                IsWorldChildrensDay(source, bundesland) ||
                IsInternationalWomensDay(source, bundesland) ||
                IsAllSaintsDay(source, bundesland) ||
                IsAssumptionDay(source, bundesland) ||
                IsEpiphany(source, bundesland))
            {
                return true;
            }

            DateTime ostersonntag = CalculateEasterSunday(source.Year);

            if (bundesland == FederalStates.Bavaria)
            {
                if (IsCorpusChristi(ostersonntag, source))
                {
                    return true;
                }
            }
            else if (bundesland == FederalStates.Baden_Wuerttemberg)
            {
                if (IsCorpusChristi(ostersonntag, source))
                {
                    return true;
                }
            }

            else if (bundesland == FederalStates.Hesse)
            {
                if (IsCorpusChristi(ostersonntag, source))
                {
                    return true;
                }
            }
            else if (bundesland == FederalStates.North_Rhine_Westphalia)
            {
                if (IsCorpusChristi(ostersonntag, source))
                {
                    return true;
                }
            }
            else if (bundesland == FederalStates.Rhineland_Palatinate)
            {
                if (IsCorpusChristi(ostersonntag, source))
                {
                    return true;
                }
            }
            else if (bundesland == FederalStates.Saarland)
            {
                if (IsCorpusChristi(ostersonntag, source))
                {
                    return true;
                }
            }
            if (IsGoodFriday(ostersonntag, source) ||
                IsEasterMonday(ostersonntag, source) ||
                IsAscensionOfChrist(ostersonntag, source) ||
                IsWhitMonday(ostersonntag, source))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// In german 'Ostermontag'. Monday after easter sunday
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsEasterMonday(this DateTime source)
        {
            DateTime ostersonntag = CalculateEasterSunday(source.Year);
            return IsEasterMonday(ostersonntag, source);
        }

        /// <summary>
        /// In german 'Karfreitag'. Friday before easter sunday
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsGoodFriday(this DateTime source)
        {
            DateTime ostersonntag = CalculateEasterSunday(source.Year);
            return IsGoodFriday(ostersonntag, source);
        }

        /// <summary>
        /// In german 'Christi Himmelfahrt'. 40 days after easter sunday
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAscensionOfChrist(this DateTime source)
        {
            DateTime ostersonntag = CalculateEasterSunday(source.Year);
            return IsAscensionOfChrist(ostersonntag, source);
        }

        /// <summary>
        /// In german 'Pfingstmontag'. 50 days after easter sunday
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsWhitMonday(this DateTime source)
        {
            DateTime ostersonntag = CalculateEasterSunday(source.Year);
            return IsWhitMonday(ostersonntag, source);
        }

        /// <summary>
        /// In german 'Tag der deutschen Einheit'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsDayOfGermanUnity(this DateTime date)
        {
            if (date.Month == 10 && date.Day == 3)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Erster Weihnachtsfeiertag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsFirstChristmasDay(this DateTime date)
        {
            if (date.Month == 12 && date.Day == 25)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Zweiter Weihnachtsfeiertag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsBoxingDay(this DateTime date)
        {
            if (date.Month == 12 && date.Day == 26)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Neujahrstag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsNewYearsDay(this DateTime date)
        {
            if (date.Month == 1 && date.Day == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Erste Mai'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsLabourDay(this DateTime date)
        {
            if (date.Month == 5 && date.Day == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Fronleichnam'. 11 days after whit monday
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsCorpusChristi(this DateTime source)
        {
            DateTime ostersonntag = CalculateEasterSunday(source.Year);
            return IsCorpusChristi(ostersonntag, source);
        }

        /// <summary>
        /// In german 'Fronleichnam'. 11 days after whit monday
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsCorpusChristi(this DateTime source, FederalStates bundesland)
        {
            DateTime ostersonntag = CalculateEasterSunday(source.Year);
            if (bundesland == FederalStates.Bavaria ||
                bundesland == FederalStates.Baden_Wuerttemberg ||
                bundesland == FederalStates.Hesse ||
                bundesland == FederalStates.North_Rhine_Westphalia ||
                bundesland == FederalStates.Rhineland_Palatinate ||
                bundesland == FederalStates.Saarland
                )
            {
                return IsCorpusChristi(source);
            }
            return false;
        }

        /*
        /// <summary>
        /// In german 'Fronleichnam'. 11 days after whit monday
        /// </summary>
        */
        //private static bool IsCorpusChristi(DateTime date, DateTime ostersonntag, FederalStates bundesland)
        //{

        //    return IsCorpusChristi(ostersonntag, date);
        //}


        /// <summary>
        /// In german 'HeiligeDreiKönige'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsEpiphany(this DateTime date)
        {
            if (date.Month == 1 && date.Day == 6)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'HeiligeDreiKönige'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsEpiphany(this DateTime date, FederalStates bundesland)
        {
            if (bundesland == FederalStates.Bavaria ||
                bundesland == FederalStates.Baden_Wuerttemberg)
            {
                return IsEpiphany(date);
            }
            return false;
        }

        /// <summary>
        /// In german 'MariaeHimmelfahrt'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAssumptionDay(this DateTime date)
        {
            if (date.Month == 8 && date.Day == 15)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'MariaeHimmelfahrt'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAssumptionDay(this DateTime date, FederalStates bundesland)
        {
            if (bundesland == FederalStates.Bavaria ||
                bundesland == FederalStates.Saarland)
            {
                return IsAssumptionDay(date);
            }
            return false;
        }

        /// <summary>
        /// In german 'Allerheiligen'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAllSaintsDay(this DateTime date)
        {
            if (date.Month == 11 && date.Day == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Allerheiligen'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAllSaintsDay(this DateTime date, FederalStates bundesland)
        {
            if (bundesland == FederalStates.North_Rhine_Westphalia ||
                bundesland == FederalStates.Rhineland_Palatinate ||
                bundesland == FederalStates.Saarland ||
                bundesland == FederalStates.Baden_Wuerttemberg ||
                bundesland == FederalStates.Bavaria)
            {
                return IsAllSaintsDay(date);
            }
            return false;
        }

        /// <summary>
        /// In german 'Reformationstag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsReformationDay(this DateTime date)
        {
            if (date.Month == 10 && date.Day == 31)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Reformationstag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsReformationDay(this DateTime date, FederalStates bundesland)
        {

            if (bundesland == FederalStates.Mecklenburg_Western_Pomerania ||
                bundesland == FederalStates.Brandenburg ||
                bundesland == FederalStates.Saxony ||
                bundesland == FederalStates.Saxony_Anhalt ||
                bundesland == FederalStates.Thuringia)
            {
                if (date.Year >= 1990)
                {
                    return IsReformationDay(date);
                }
            }
            if (bundesland == FederalStates.Lower_Saxony ||
                bundesland == FederalStates.Hamburg ||
                bundesland == FederalStates.Schleswig_Holstein ||
                bundesland == FederalStates.Bremen)
            {
                if (date.Year >= 2018)
                {
                    return IsReformationDay(date);
                }
            }
            return false;
        }

        /// <summary>
        /// In german 'Weltkindertag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsWorldChildrensDay(this DateTime date)
        {
            if (date.Month == 09 && date.Day == 20)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Weltkindertag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsWorldChildrensDay(this DateTime date, FederalStates bundesland)
        {
            if (bundesland == FederalStates.Thuringia)
            {
                return IsWorldChildrensDay(date);
            }
            return false;
        }

        /// <summary>
        /// In german 'Internationaler Frauentag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsInternationalWomensDay(this DateTime date)
        {
            if (date.Month == 03 && date.Day == 08)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Internationaler Frauentag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsInternationalWomensDay(this DateTime date, FederalStates bundesland)
        {
            if (bundesland == FederalStates.Berlin ||
                bundesland == FederalStates.Mecklenburg_Western_Pomerania)
            {
                return IsInternationalWomensDay(date);
            }
            return false;
        }

        /// <summary>
        ///  In german 'Jahrestag der Befreiung vom Nationalsozialismus und Ende des Zweiten Weltkriegs'
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAnniversaryOfTheLiberationFromNationalSocialismAndTheEndOfTheSecondWorldWar(this DateTime date)
        {
            if (date.Year == 2025 && date.Month == 05 && date.Day == 08)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///  In german 'Jahrestag der Befreiung vom Nationalsozialismus und Ende des Zweiten Weltkriegs'
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAnniversaryOfTheLiberationFromNationalSocialismAndTheEndOfTheSecondWorldWar(this DateTime date, FederalStates bundesland)
        {
            if (bundesland == FederalStates.Berlin)
            {
                return IsAnniversaryOfTheLiberationFromNationalSocialismAndTheEndOfTheSecondWorldWar(date);
            }
            return false;
        }

        /// <summary>
        /// In german 'Buss- und Bettag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsRepentanceAndPrayerDay(this DateTime date)
        {
            // Erster Advent ist der vierte Sonntag vor dem 25. Dezember
            DateTime ersterAdvent = CalculateFirstAdvent(date.Year);

            DateTime totensonntag = ersterAdvent.AddDays(-7);

            // Buß- und Bettag ist der Mittwoch vor dem Totensonntag
            DateTime bussUndBettag = totensonntag.AddDays(-4); // 4 Tage zurück von Sonntag zu Mittwoch

            if (bussUndBettag.Year == date.Year && bussUndBettag.Month == date.Month && bussUndBettag.Day == date.Day)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Buss- und Bettag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsRepentanceAndPrayerDay(this DateTime date, FederalStates bundesland)
        {

            if (bundesland == FederalStates.Saxony)
            {
                return IsRepentanceAndPrayerDay(date);
            }
            else if (bundesland == FederalStates.Lower_Saxony ||
                     bundesland == FederalStates.Hamburg ||
                     bundesland == FederalStates.Schleswig_Holstein ||
                     bundesland == FederalStates.Bremen)
            {
                if (date.Year < 1995)
                {
                    return IsRepentanceAndPrayerDay(date);
                }
            }
            return false;
        }



        private static bool IsCorpusChristi(DateTime ostersonntag, DateTime source)
        {
            // Pfingstsonntag ist 49 Tage nach Ostersonntag
            DateTime pfingstsonntag = ostersonntag.AddDays(49);
            // Fronleichnam ist 11 Tage nach Pfingstsonntag
            pfingstsonntag = pfingstsonntag.AddDays(11);
            if (pfingstsonntag.Year == source.Year && pfingstsonntag.Month == source.Month && pfingstsonntag.Day == source.Day)
                return true;
            return false;
        }

        private static bool IsEasterMonday(DateTime ostersonntag, DateTime source)
        {
            // Ostermontag ist der Tag nach Ostersonntag
            ostersonntag = ostersonntag.AddDays(1);
            if (ostersonntag.Year == source.Year && ostersonntag.Month == source.Month && ostersonntag.Day == source.Day)
                return true;
            return false;
        }

        private static bool IsGoodFriday(DateTime ostersonntag, DateTime source)
        {
            // Karfreitag ist der Freitag vor Ostersonntag
            ostersonntag = ostersonntag.AddDays(-2);
            if (ostersonntag.Year == source.Year && ostersonntag.Month == source.Month && ostersonntag.Day == source.Day)
                return true;
            return false;
        }

        private static bool IsAscensionOfChrist(DateTime ostersonntag, DateTime source)
        {
            // Christi Himmelfahrt ist 40 Tage nach Ostersonntag
            // 39 Tage, da Ostersonntag selbst als Tag 1 zählt
            ostersonntag = ostersonntag.AddDays(39);
            if (ostersonntag.Year == source.Year && ostersonntag.Month == source.Month && ostersonntag.Day == source.Day)
                return true;
            return false;
        }

        private static bool IsWhitMonday(DateTime ostersonntag, DateTime source)
        {
            // Pfingstmontag ist 50 Tage nach Ostersonntag
            ostersonntag = ostersonntag.AddDays(50);
            if (ostersonntag.Year == source.Year && ostersonntag.Month == source.Month && ostersonntag.Day == source.Day)
                return true;
            return false;
        }

        //Calculations
        private static DateTime CalculateFirstAdvent(int year)
        {
            DateTime christmas = new DateTime(year, 12, 25);

            // Finde den Wochentag des 25. Dezember
            DayOfWeek christmasDayOfWeek = christmas.DayOfWeek;

            // Berechne den ersten Advent
            DateTime firstAdvent = christmas.AddDays(-((int)christmasDayOfWeek + 21));

            return firstAdvent;
        }

        private static DateTime CalculateEasterSunday(int year)
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
    }
}