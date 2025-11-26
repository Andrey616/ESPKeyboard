using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YourProject.Services;

namespace ESP_Keyboard
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			LoadMacros();
			
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private ComboBox[] comboBoxes;

		private void LoadMacros()
		{

			var dbService = new DatabaseService();
			dbService.InitializeDatabase(); // Создаст БД при первом запуске
			comboBoxes = new[] { ComboBoxBut1, ComboBoxBut2, ComboBoxBut3, ComboBoxBut4, ComboBoxBut5, ComboBoxBut6 };
			foreach (var comboBox in comboBoxes)
			{
				comboBox.ItemsSource = dbService.GetMacros();
				comboBox.DisplayMemberPath = "KeyCombination";
				comboBox.SelectedValuePath = "Id";
			}



			
		}
	}
}