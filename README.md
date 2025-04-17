# Public Holidays
The DLL PublicHolidays shows whether a specific date is a Sunday or a public holiday (Eastern, DayOfGermanUnity,...).
The public holidays only apply to Germany.

Die DLL PublicHolidays zeigt an, ob ein bestimmtes Datum ein Sonntag oder ein Feiertag ist (Ostern, Tag der deutschen Einheit,...).
Die Feiertage beziehen sich nur auf Deutschland.

## Installation
Use the package manager [Nuget](https://www.nuget.org/packages/SinusSoftware.PublicHolidays) to install PublicHolidays.


## Usage

 ```csharp

# Example
DateTime datetime = DateTime.Now;
bool value1 = datetime.IsSundayOrPublicHoliday(PublicHolidays.FederalStates.Bavaria);

bool value2 = datetime.IsEasterMonday();

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
