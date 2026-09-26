using FuelPrices.Core;
using FuelPrices.Core.Stations;

namespace FuelPrices.Explorer
{
  public class Program
  {
    private const string ConfigFilePath = "FuelPricesConfig.json";
    private const string BaseAddress = "https://creativecommons.tankerkoenig.de/json/";

    [STAThread]
    public static void Main()
    {
      Directory.SetCurrentDirectory(AppContext.BaseDirectory);

      var config = LoadOrCreateConfig();
      if (string.IsNullOrEmpty(config.ApiKey))
      {
        MessageBox.Show(
            $"Bitte einen Tankerkoenig-API-Key in '{ConfigFilePath}' eintragen (Registrierung unter https://onboarding.tankerkoenig.de) und die Anwendung neu starten.",
            "API-Key fehlt",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        return;
      }

      var httpClient = new HttpClient { BaseAddress = new Uri(BaseAddress) };
      var client = new TankerkoenigClient(httpClient, config.ApiKey);

      ApplicationConfiguration.Initialize();
      Application.Run(new MainForm(client));
    }

    private static FuelPricesConfig LoadOrCreateConfig()
    {
      if (!File.Exists(ConfigFilePath))
      {
        var template = new FuelPricesConfig();
        File.WriteAllText(ConfigFilePath, Json.Serialize(template));
        return template;
      }

      var configJson = File.ReadAllText(ConfigFilePath);
      return Json.Deserialize<FuelPricesConfig>(configJson) ?? new FuelPricesConfig();
    }
  }
}
