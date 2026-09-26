namespace FuelPrices.Core.Stations;

public class StationSearchResult
{
  public bool Ok { get; set; }
  public string License { get; set; } = string.Empty;
  public string Data { get; set; } = string.Empty;
  public string? Status { get; set; }
  public string? Message { get; set; }
  public List<Station> Stations { get; set; } = [];
}
