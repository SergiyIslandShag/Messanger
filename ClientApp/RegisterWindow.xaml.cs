using System;
using System.Windows;
using System.Windows.Controls;

namespace ClientApp
{
	public partial class RegisterWindow : Window
	{
		public RegisterWindow()
		{
			InitializeComponent();
		}
		private void Register(object sender, RoutedEventArgs e)
		{
			string name = NameTextBox.Text;
			string email = EmailTextBox.Text;
			string password = PasswordBox.Password;

			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

			this.Hide();
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();

			this.Close();
		}

		private void Login(object sender, RoutedEventArgs e)
		{
			Login loginWindow = new Login(this);
			loginWindow.Show();
			this.Hide();
		}
	}
}