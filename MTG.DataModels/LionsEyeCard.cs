using CsvHelper.Configuration.Attributes;

namespace MTG.DataModels;

public record LionsEyeCard
{
    [Name("Name")]
    [Index(0)]
    public required string Name { get; init; }
    
    [Name("Set Code")]
    [Index(1)]
    public required string SetCode { get; init; }
    
    [Name("Collector Number")]
    [Index(2)]
    public required string CollectorNumber { get; init; }

    [Name("Language Code")]
    [Index(3)]
    public required string LanguageCode { get; init; }
    
    [Name("Number of Non-foil")]
    [Index(4)]
    public required int NumberOfNonFoil { get; init; }
    
    [Name("Number of Foil")]
    [Index(5)]
    public required int NumberOfFoil { get; init; }

    [Name("Favorite")]
    [Index(6)]
    public string Favorite => "false";
    
    [Name("Scryfall ID")]
    [Index(7)]
    public required string? ScryfallId { get; set; }

    private sealed class LionsEyeCardEqualityComparer : IEqualityComparer<LionsEyeCard>
    {
        public bool Equals(LionsEyeCard? x, LionsEyeCard? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.SetCode == y.SetCode 
                   && x.CollectorNumber == y.CollectorNumber 
                   && x.LanguageCode == y.LanguageCode
                   && x.NumberOfNonFoil == y.NumberOfNonFoil
                   && x.NumberOfFoil == y.NumberOfFoil
                   && x.ScryfallId == y.ScryfallId;
        }

        public int GetHashCode(LionsEyeCard obj)
        {
            return HashCode.Combine(obj.Name, obj.SetCode, obj.CollectorNumber, obj.LanguageCode);
        }
    }

    public static IEqualityComparer<LionsEyeCard> LionsEyeCardComparer { get; } = new LionsEyeCardEqualityComparer();
}