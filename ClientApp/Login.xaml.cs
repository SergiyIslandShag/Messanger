using data_access;
using data_access.NewFolder;
using System;
using System.Linq;
using System.Windows;

namespace ClientApp
{
	public partial class Login : Window
	{
		private readonly MessangerDBContext _dbContext2;

		public Login()
		{
			InitializeComponent();
			_dbContext2 = new MessangerDBContext();
		}

		private void LoginС(object sender, RoutedEventArgs e)
		{
			string name = NameTextBox.Text;
			string email = EmailTextBox.Text;
			string password = PasswordBox.Password;

			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			try
			{
				User user = _dbContext2.Users.FirstOrDefault(u => u.Name == name && u.Email == email && u.Password == password);

				if (user == null)
				{
					MessageBox.Show("Invalid credentials. Please check your name, email, and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
