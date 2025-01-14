using CsvHelper.Configuration.Attributes;

namespace MTG.DataModels;

public record LeviathanCard
{
    [Name("oracle_id")] 
    public required Guid? OracleId { get; set; }
    
    [Name("name")]
    public required string Name { get; set; }

    [Name("lang")]
    public required string Language { get; set; }

    [Name("scryfall_id")]
    public required string? ScryfallId { get; set; }
    
    [Name("colletor_number")]
    public required string CollectorNumber { get; set; }
    
    [Name("set")]
    public required string Set { get; set; }
    
    [Name("finish")]
    public required string Finish { get; set; }
    
    [Name("proxy")]
    public required bool Proxy { get; set; }
    
    [Name("count")]
    public required int Count { get; set; }
    
    [Name("folder")]
    public required string Folder { get; set; }
}