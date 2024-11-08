using System.Windows;

namespace ClientApp
{
	public partial class Login : Window
	{
		private Window _registrationWindow;
		private RegisterWindow registerWindow;

		public Login()
		{
			InitializeComponent();
		}

		public Login(RegisterWindow registerWindow)
		{
			this.registerWindow = registerWindow;
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