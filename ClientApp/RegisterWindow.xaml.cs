using data_access;
using data_access.NewFolder;
using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClientApp
{
	public partial class RegisterWindow : Window
	{
		private readonly MessangerDBContext _dbContext;

		public RegisterWindow()
		{
			InitializeComponent();
			_dbContext = new MessangerDBContext();
		}

		private void RegisterQ(object sender, RoutedEventArgs e)
		{
			User user = new User();

			string name = NameTextBox.Text;
			string email = EmailTextBox.Text;
			string password = PasswordBox.Password;
			string phoneNumber = PhoneNumberTextBox.Text;

			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(phoneNumber))
			{
				MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			user.Name = name;
			user.Email = email;
			user.Password = password;
			user.PhoneNumber = phoneNumber;
			user.Port = 4040;
			user.ServerAddress = "127.0.0.1";

			try
			{
				_dbContext.Users.Add(user);

				_dbContext.SaveChanges();

				MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

				this.Hide();
				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private void Login(object sender, RoutedEventArgs e)
		{
			Login loginWindow = new Login();
			loginWindow.Show();
			this.Hide();
		}
	}
}
