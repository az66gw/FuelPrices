using System.Globalization;

namespace FuelPrices.Core.Stations;

// Radius search only (list.php) — prices.php/detail.php left out until the follow-up service's scope is known.
public class TankerkoenigClient(HttpClient httpClient, string apiKey)
{
  public async Task<List<Station>> GetAllByLocationAsync(double lat, double lng, double radiusKm, FuelType fuelType = FuelType.All, StationSortOrder sort = StationSortOrder.Distance)
  {
    var requestUri = $"list.php?lat={lat.ToString(CultureInfo.InvariantCulture)}&lng={lng.ToString(CultureInfo.InvariantCulture)}&rad={radiusKm.ToString(CultureInfo.InvariantCulture)}&type={ToQueryValue(fuelType)}&sort={ToQueryValue(sort)}&apikey={apiKey}";

    var response = await httpClient.GetAsync(requestUri);
    response.EnsureSuccessStatusCode();
    var jsonResponse = await response.Content.ReadAsStringAsync();

    var result = Json.Deserialize<StationSearchResult>(jsonResponse)
        ?? throw new InvalidOperationException("Failed to deserialize the Tankerkoenig station search response.");

    if (!result.Ok)
      throw new TankerkoenigRequestFailedException(result.Message ?? "Unknown error.");

    return result.Stations;
  }

  private static string ToQueryValue(FuelType fuelType) => fuelType switch
  {
    FuelType.All => "all",
    FuelType.E5 => "e5",
    FuelType.E10 => "e10",
    FuelType.Diesel => "diesel",
    _ => throw new ArgumentOutOfRangeException(nameof(fuelType))
  };

  private static string ToQueryValue(StationSortOrder sort) => sort switch
  {
    StationSortOrder.Distance => "dist",
    StationSortOrder.Price => "price",
    _ => throw new ArgumentOutOfRangeException(nameof(sort))
  };
}
