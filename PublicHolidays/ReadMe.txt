﻿=== PublicHolidays ===

Author: Dirk Tamke
eMail: SinusSoftware@gmx.net
GitHub URI: https://github.com/SinusSoftware/PublicHolidays
License: MIT
License URI: https://choosealicense.com/licenses/mit/


== Description ==

The DLL PublicHolidays shows whether a specific date is a Sunday or a public holiday (Eastern, DayOfGermanUnity,...).
The public holidays only apply to Germany.

Die DLL PublicHolidays zeigt an, ob ein bestimmtest Datum ein Sonntag oder ein Feiertag ist (Oster, Tag der deutschen Einheit,...).
Die Feritage beziehen sich nur auf Deutschland

Example:
DateTime datetime = DateTime.Now;
bool value = datetime.IsSundayOrPublicHoliday(PublicHolidays.FederalStates.Bavaria);

== Changelog ==

= 1.0.2 =
* Add function to check only for sundays and nationwide holidays
* Code maintenance
* More comments

= 1.0.1 =
* Show comments

= 1.0 =
* First version