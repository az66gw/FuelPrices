using FuelPrices.Core.Stations;
using System.Globalization;

namespace FuelPrices.Explorer
{
  public partial class MainForm : Form
  {
    private readonly TankerkoenigClient Client;

    public MainForm(TankerkoenigClient client)
    {
      Client = client;
      InitializeComponent();

      FuelTypeComboBox.Items.AddRange(["Alle", "E5", "E10", "Diesel"]);
      FuelTypeComboBox.SelectedIndex = 0;

      SortComboBox.Items.AddRange(["Entfernung", "Preis"]);
      SortComboBox.SelectedIndex = 0;
    }

    private async void SearchButton_Click(object? sender, EventArgs e)
    {
      if (!double.TryParse(LatTextBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var lat) ||
          !double.TryParse(LngTextBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var lng))
      {
        MessageBox.Show(this, "Lat/Lng muessen gueltige Dezimalzahlen sein (Punkt als Trennzeichen).", "Ungueltige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      var fuelType = FuelTypeComboBox.SelectedIndex switch
      {
        1 => FuelType.E5,
        2 => FuelType.E10,
        3 => FuelType.Diesel,
        _ => FuelType.All
      };

      var sort = SortComboBox.SelectedIndex == 1 ? StationSortOrder.Price : StationSortOrder.Distance;

      SearchButton.Enabled = false;
      try
      {
        var stations = await Client.GetAllByLocationAsync(lat, lng, (double)RadiusNumericUpDown.Value, fuelType, sort);
        StationsDataGridView.DataSource = stations;
      }
      catch (TankerkoenigRequestFailedException ex)
      {
        MessageBox.Show(this, ex.Message, "Tankerkoenig-Anfrage fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (HttpRequestException ex)
      {
        MessageBox.Show(this, ex.Message, "Netzwerkfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        SearchButton.Enabled = true;
      }
    }
  }
}
