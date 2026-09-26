namespace FuelPrices.Explorer
{
  partial class MainForm
  {
    private System.ComponentModel.IContainer components = null!;

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      LatLabel = new Label();
      LatTextBox = new TextBox();
      LngLabel = new Label();
      LngTextBox = new TextBox();
      RadiusLabel = new Label();
      RadiusNumericUpDown = new NumericUpDown();
      FuelTypeLabel = new Label();
      FuelTypeComboBox = new ComboBox();
      SortLabel = new Label();
      SortComboBox = new ComboBox();
      SearchButton = new Button();
      TopPanel = new FlowLayoutPanel();
      StationsDataGridView = new DataGridView();
      ((System.ComponentModel.ISupportInitialize)RadiusNumericUpDown).BeginInit();
      ((System.ComponentModel.ISupportInitialize)StationsDataGridView).BeginInit();
      TopPanel.SuspendLayout();
      SuspendLayout();
      //
      // LatLabel
      //
      LatLabel.AutoSize = true;
      LatLabel.Margin = new Padding(3, 8, 3, 3);
      LatLabel.Text = "Lat:";
      //
      // LatTextBox
      //
      LatTextBox.Text = "50.1109";
      LatTextBox.Width = 90;
      //
      // LngLabel
      //
      LngLabel.AutoSize = true;
      LngLabel.Margin = new Padding(9, 8, 3, 3);
      LngLabel.Text = "Lng:";
      //
      // LngTextBox
      //
      LngTextBox.Text = "8.6821";
      LngTextBox.Width = 90;
      //
      // RadiusLabel
      //
      RadiusLabel.AutoSize = true;
      RadiusLabel.Margin = new Padding(9, 8, 3, 3);
      RadiusLabel.Text = "Radius (km):";
      //
      // RadiusNumericUpDown
      //
      RadiusNumericUpDown.DecimalPlaces = 1;
      RadiusNumericUpDown.Maximum = 25;
      RadiusNumericUpDown.Minimum = 1;
      RadiusNumericUpDown.Value = 5;
      RadiusNumericUpDown.Width = 70;
      //
      // FuelTypeLabel
      //
      FuelTypeLabel.AutoSize = true;
      FuelTypeLabel.Margin = new Padding(9, 8, 3, 3);
      FuelTypeLabel.Text = "Kraftstoff:";
      //
      // FuelTypeComboBox
      //
      FuelTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      FuelTypeComboBox.Width = 90;
      //
      // SortLabel
      //
      SortLabel.AutoSize = true;
      SortLabel.Margin = new Padding(9, 8, 3, 3);
      SortLabel.Text = "Sortierung:";
      //
      // SortComboBox
      //
      SortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      SortComboBox.Width = 100;
      //
      // SearchButton
      //
      SearchButton.Margin = new Padding(12, 3, 3, 3);
      SearchButton.Text = "Suchen";
      SearchButton.Click += SearchButton_Click;
      //
      // TopPanel
      //
      TopPanel.AutoSize = true;
      TopPanel.Controls.Add(LatLabel);
      TopPanel.Controls.Add(LatTextBox);
      TopPanel.Controls.Add(LngLabel);
      TopPanel.Controls.Add(LngTextBox);
      TopPanel.Controls.Add(RadiusLabel);
      TopPanel.Controls.Add(RadiusNumericUpDown);
      TopPanel.Controls.Add(FuelTypeLabel);
      TopPanel.Controls.Add(FuelTypeComboBox);
      TopPanel.Controls.Add(SortLabel);
      TopPanel.Controls.Add(SortComboBox);
      TopPanel.Controls.Add(SearchButton);
      TopPanel.Dock = DockStyle.Top;
      TopPanel.Padding = new Padding(8);
      //
      // StationsDataGridView
      //
      StationsDataGridView.AllowUserToAddRows = false;
      StationsDataGridView.AllowUserToDeleteRows = false;
      StationsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      StationsDataGridView.Dock = DockStyle.Fill;
      StationsDataGridView.ReadOnly = true;
      StationsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      //
      // MainForm
      //
      ClientSize = new Size(1000, 600);
      Controls.Add(StationsDataGridView);
      Controls.Add(TopPanel);
      MinimumSize = new Size(700, 400);
      Text = "FuelPrices Explorer";
      ((System.ComponentModel.ISupportInitialize)RadiusNumericUpDown).EndInit();
      ((System.ComponentModel.ISupportInitialize)StationsDataGridView).EndInit();
      TopPanel.ResumeLayout(false);
      TopPanel.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    private Label LatLabel = null!;
    private TextBox LatTextBox = null!;
    private Label LngLabel = null!;
    private TextBox LngTextBox = null!;
    private Label RadiusLabel = null!;
    private NumericUpDown RadiusNumericUpDown = null!;
    private Label FuelTypeLabel = null!;
    private ComboBox FuelTypeComboBox = null!;
    private Label SortLabel = null!;
    private ComboBox SortComboBox = null!;
    private Button SearchButton = null!;
    private FlowLayoutPanel TopPanel = null!;
    private DataGridView StationsDataGridView = null!;
  }
}
