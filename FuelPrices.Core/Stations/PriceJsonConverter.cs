using System.Text.Json;
using System.Text.Json.Serialization;

namespace FuelPrices.Core.Stations;

// Tankerkoenig encodes "no price available" as JSON `false` instead of `null` for diesel/e5/e10.
public sealed class PriceJsonConverter : JsonConverter<double?>
{
  public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.TokenType switch
  {
    JsonTokenType.Number => reader.GetDouble(),
    JsonTokenType.False => null,
    JsonTokenType.Null => null,
    _ => throw new JsonException($"Unexpected token {reader.TokenType} for a fuel price.")
  };

  public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
  {
    if (value.HasValue)
      writer.WriteNumberValue(value.Value);
    else
      writer.WriteBooleanValue(false);
  }
}
