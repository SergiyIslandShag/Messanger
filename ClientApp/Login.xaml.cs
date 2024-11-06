using System.Windows;

namespace ClientApp
{
	public partial class Login : Window
	{
		private Window _registrationWindow;

		public Login(Window registrationWindow)
		{
			InitializeComponent();
			_registrationWindow = registrationWindow;
		}

		private void LoginC(object sender, RoutedEventArgs e)
		{
			string username = UsernameTextBox.Text.Trim();
			string password = PasswordBox.Password.Trim();

			if (username == "admin" && password == "password123")
			{
				MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
				this.Close();
				_registrationWindow?.Close();
			}
			else
			{
				MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}