namespace FuelPrices.Core.Stations;

public sealed class TankerkoenigRequestFailedException : Exception
{
  public TankerkoenigRequestFailedException(string reason)
      : base($"Tankerkoenig request failed: {reason}")
  {
    Reason = reason;
  }

  public string Reason { get; }
}
