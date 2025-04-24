namespace System
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// PublicHolidays in germany
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static partial class PublicHolidays
    {
        ///<summary>Enum for the federal states of germany</summary>
        public enum FederalStates
        {
            ///<summary>Baden-W&#252;ttemberg</summary>
            Baden_Wuerttemberg,
            ///<summary>Bayern</summary>
            Bavaria,
            ///<summary>Berlin</summary>
            Berlin,
            ///<summary>Brandenburg</summary>
            Brandenburg,
            ///<summary>Bremen</summary>
            Bremen,
            ///<summary>Hamburg</summary>
            Hamburg,
            ///<summary>Hessen</summary>
            Hesse,
            ///<summary>Mecklenburg-Vorpommern</summary>
            Mecklenburg_Western_Pomerania,
            ///<summary>Niedersachsen</summary>
            Lower_Saxony,
            ///<summary>Nordrhein-Westfalen</summary>
            North_Rhine_Westphalia,
            ///<summary>Rheinland-Pfalz</summary>
            Rhineland_Palatinate,
            ///<summary>Saarland</summary>
            Saarland,
            ///<summary>Sachsen</summary>
            Saxony,
            ///<summary>Sachsen-Anhalt</summary>
            Saxony_Anhalt,
            ///<summary>Schleswig-Holstein</summary>
            Schleswig_Holstein,
            ///<summary>Th&#252;ringen</summary>
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
        /// The day is a Sunday or only a nationwide public holiday<br/>
        /// Der Tag ist ein Sonntag oder nur ein bundesweiter öffentlicher Feiertag
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsSundayOrPublicHolidayOnlyNationwide(this DateTime source)
        {
            if (source.DayOfWeek == DayOfWeek.Sunday)
                return true;

            if (IsDayOfGermanUnity(source) ||
                IsFirstChristmasDay(source) ||
                IsBoxingDay(source) ||
                IsNewYearsDay(source) ||
                IsLabourDay(source)
                )
            {
                return true;
            }

            DateTime ostersonntag = CalculateEasterSunday(source.Year);
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
        /// The day is a Sunday or public holiday on a spezified federal state<br/>
        /// Der Tag ist ein Sonntag oder ein öffentlicher Feiertag in einem bestimmten Bundesland
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsSundayOrPublicHoliday(this DateTime source, FederalStates federalstate)
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
                IsReformationDay(source, federalstate) ||
                IsRepentanceAndPrayerDay(source, federalstate) ||
                IsAnniversaryOfTheLiberationFromNationalSocialismAndTheEndOfTheSecondWorldWar(source, federalstate) ||
                IsWorldChildrensDay(source, federalstate) ||
                IsInternationalWomensDay(source, federalstate) ||
                IsAllSaintsDay(source, federalstate) ||
                IsAssumptionDay(source, federalstate) ||
                IsEpiphany(source, federalstate))
            {
                return true;
            }

            DateTime ostersonntag = CalculateEasterSunday(source.Year);

            if (IsGoodFriday(ostersonntag, source) ||
                IsEasterMonday(ostersonntag, source) ||
                IsAscensionOfChrist(ostersonntag, source) ||
                IsWhitMonday(ostersonntag, source) ||
                IsCorpusChristi(ostersonntag, source, federalstate)
                )
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
        public static bool IsDayOfGermanUnity(this DateTime source)
        {
            if (source.Month == 10 && source.Day == 3)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Erster Weihnachtsfeiertag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsFirstChristmasDay(this DateTime source)
        {
            if (source.Month == 12 && source.Day == 25)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Zweiter Weihnachtsfeiertag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsBoxingDay(this DateTime source)
        {
            if (source.Month == 12 && source.Day == 26)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Neujahrstag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsNewYearsDay(this DateTime source)
        {
            if (source.Month == 1 && source.Day == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Erste Mai'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsLabourDay(this DateTime source)
        {
            if (source.Month == 5 && source.Day == 1)
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
        public static bool IsCorpusChristi(this DateTime source, FederalStates federalState)
        {
            DateTime ostersonntag = CalculateEasterSunday(source.Year);
            return IsCorpusChristi(ostersonntag, source, federalState);
        }

        /// <summary>
        /// In german 'HeiligeDreiKönige'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsEpiphany(this DateTime source)
        {
            if (source.Month == 1 && source.Day == 6)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'HeiligeDreiKönige'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsEpiphany(this DateTime source, FederalStates federalState)
        {
            if (federalState == FederalStates.Bavaria ||
                federalState == FederalStates.Baden_Wuerttemberg)
            {
                return IsEpiphany(source);
            }
            return false;
        }

        /// <summary>
        /// In german 'MariaeHimmelfahrt'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAssumptionDay(this DateTime source)
        {
            if (source.Month == 8 && source.Day == 15)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'MariaeHimmelfahrt'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAssumptionDay(this DateTime source, FederalStates federalState)
        {
            if (federalState == FederalStates.Bavaria ||
                federalState == FederalStates.Saarland)
            {
                return IsAssumptionDay(source);
            }
            return false;
        }

        /// <summary>
        /// In german 'Allerheiligen'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAllSaintsDay(this DateTime source)
        {
            if (source.Month == 11 && source.Day == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Allerheiligen'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAllSaintsDay(this DateTime source, FederalStates federalState)
        {
            if (federalState == FederalStates.North_Rhine_Westphalia ||
                federalState == FederalStates.Rhineland_Palatinate ||
                federalState == FederalStates.Saarland ||
                federalState == FederalStates.Baden_Wuerttemberg ||
                federalState == FederalStates.Bavaria)
            {
                return IsAllSaintsDay(source);
            }
            return false;
        }

        /// <summary>
        /// In german 'Reformationstag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsReformationDay(this DateTime source)
        {
            if (source.Month == 10 && source.Day == 31)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Reformationstag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsReformationDay(this DateTime source, FederalStates federalState)
        {

            if (federalState == FederalStates.Mecklenburg_Western_Pomerania ||
                federalState == FederalStates.Brandenburg ||
                federalState == FederalStates.Saxony ||
                federalState == FederalStates.Saxony_Anhalt ||
                federalState == FederalStates.Thuringia)
            {
                if (source.Year >= 1990)
                {
                    return IsReformationDay(source);
                }
            }
            if (federalState == FederalStates.Lower_Saxony ||
                federalState == FederalStates.Hamburg ||
                federalState == FederalStates.Schleswig_Holstein ||
                federalState == FederalStates.Bremen)
            {
                if (source.Year >= 2018)
                {
                    return IsReformationDay(source);
                }
            }
            return false;
        }

        /// <summary>
        /// In german 'Weltkindertag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsWorldChildrensDay(this DateTime source)
        {
            if (source.Month == 09 && source.Day == 20)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Weltkindertag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsWorldChildrensDay(this DateTime source, FederalStates federalState)
        {
            if (federalState == FederalStates.Thuringia)
            {
                return IsWorldChildrensDay(source);
            }
            return false;
        }

        /// <summary>
        /// In german 'Internationaler Frauentag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsInternationalWomensDay(this DateTime source)
        {
            if (source.Month == 03 && source.Day == 08)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Internationaler Frauentag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsInternationalWomensDay(this DateTime source, FederalStates federalState)
        {
            if (federalState == FederalStates.Berlin ||
                federalState == FederalStates.Mecklenburg_Western_Pomerania)
            {
                return IsInternationalWomensDay(source);
            }
            return false;
        }

        /// <summary>
        ///  In german 'Jahrestag der Befreiung vom Nationalsozialismus und Ende des Zweiten Weltkriegs'
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAnniversaryOfTheLiberationFromNationalSocialismAndTheEndOfTheSecondWorldWar(this DateTime source)
        {
            if (source.Year == 2025 && source.Month == 05 && source.Day == 08)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///  In german 'Jahrestag der Befreiung vom Nationalsozialismus und Ende des Zweiten Weltkriegs'
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsAnniversaryOfTheLiberationFromNationalSocialismAndTheEndOfTheSecondWorldWar(this DateTime source, FederalStates federalState)
        {
            if (federalState == FederalStates.Berlin)
            {
                return IsAnniversaryOfTheLiberationFromNationalSocialismAndTheEndOfTheSecondWorldWar(source);
            }
            return false;
        }

        /// <summary>
        /// In german 'Buss- und Bettag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsRepentanceAndPrayerDay(this DateTime source)
        {
            // Erster Advent ist der vierte Sonntag vor dem 25. Dezember
            DateTime ersterAdvent = CalculateFirstAdvent(source.Year);

            DateTime totensonntag = ersterAdvent.AddDays(-7);

            // Buß- und Bettag ist der Mittwoch vor dem Totensonntag
            DateTime bussUndBettag = totensonntag.AddDays(-4); // 4 Tage zurück von Sonntag zu Mittwoch

            if (bussUndBettag.Year == source.Year && bussUndBettag.Month == source.Month && bussUndBettag.Day == source.Day)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// In german 'Buss- und Bettag'.
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static bool IsRepentanceAndPrayerDay(this DateTime source, FederalStates federalState)
        {

            if (federalState == FederalStates.Saxony)
            {
                return IsRepentanceAndPrayerDay(source);
            }
            else if (federalState == FederalStates.Lower_Saxony ||
                     federalState == FederalStates.Hamburg ||
                     federalState == FederalStates.Schleswig_Holstein ||
                     federalState == FederalStates.Bremen)
            {
                if (source.Year < 1995)
                {
                    return IsRepentanceAndPrayerDay(source);
                }
            }
            return false;
        }

        //private

        private static bool IsCorpusChristi(DateTime ostersonntag, DateTime source,  FederalStates federalState)
        {
            if (federalState == FederalStates.Bavaria ||
                federalState == FederalStates.Baden_Wuerttemberg ||
                federalState == FederalStates.Hesse ||
                federalState == FederalStates.North_Rhine_Westphalia ||
                federalState == FederalStates.Rhineland_Palatinate ||
                federalState == FederalStates.Saarland
                )
            {
                return IsCorpusChristi(ostersonntag, source);
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