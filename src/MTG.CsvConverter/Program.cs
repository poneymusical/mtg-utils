using System.Globalization;
using CsvHelper;
using MTG.DataModels;

var sourcePath = args[0];
var destinationPath = args[1];

IEnumerable<LeviathanCard> leviathanCards;
using var reader = new StreamReader(sourcePath);
using var leviathanCsv = new CsvReader(reader, CultureInfo.InvariantCulture);
leviathanCards = leviathanCsv.GetRecords<LeviathanCard>().ToList();
Console.WriteLine($"Found {leviathanCards.Sum(x => x.Count)} Leviathan cards");
var lionsEyeCards = leviathanCards.Select(Map).ToList() ;
Console.WriteLine($"Found {lionsEyeCards.Sum(x => x.NumberOfFoil + x.NumberOfNonFoil)} Lion cards");
await using var writer = new StreamWriter(destinationPath);
await using var lionsEyeCsv = new CsvWriter(writer, CultureInfo.InvariantCulture);
await lionsEyeCsv.WriteRecordsAsync(lionsEyeCards);
await writer.FlushAsync();

static LionsEyeCard Map(LeviathanCard leviathanCard)
{
    bool isNonFoil = IsNonFoil(leviathanCard);
    return new LionsEyeCard
    {
        Name = leviathanCard.Name,
        CollectorNumber = leviathanCard.CollectorNumber,
        SetCode = leviathanCard.Set,
        LanguageCode = leviathanCard.Language,
        NumberOfFoil = !isNonFoil ? leviathanCard.Count : 0,
        NumberOfNonFoil = isNonFoil ? leviathanCard.Count : 0,
        ScryfallId = leviathanCard.ScryfallId,
    };
}

static bool IsNonFoil(LeviathanCard leviathanCard) => 
    "nonfoil".Equals(leviathanCard.Finish, StringComparison.OrdinalIgnoreCase);


