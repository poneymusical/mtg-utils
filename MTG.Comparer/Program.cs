using System.Globalization;
using CsvHelper;
using MTG.DataModels;

var sourcePath = args[0];
var resultPath = args[1];

using var sourceReader = new StreamReader(sourcePath);
using var sourceCsv = new CsvReader(sourceReader, CultureInfo.InvariantCulture);
var sourceCards = sourceCsv
    .GetRecords<LionsEyeCard>()
    .ToList();

using var resultReader = new StreamReader(resultPath);
using var resultCsv = new CsvReader(resultReader, CultureInfo.InvariantCulture);
var resultCards = resultCsv
    .GetRecords<LionsEyeCard>()
    .ToList();

var delta = sourceCards
    .Where(sourceCard => !resultCards.Any(resultCard => LionsEyeCard.LionsEyeCardComparer.Equals(resultCard, sourceCard)))
    .ToList();
Console.WriteLine($"Found {delta.Count} unique cards with total {delta.Sum(x => x.NumberOfNonFoil + x.NumberOfFoil)}");
foreach (var sourceCard in delta)
    Console.WriteLine(sourceCard);

