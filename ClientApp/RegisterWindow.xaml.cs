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
		private readonly MessangerDBContext _dbContex1;

		public RegisterWindow()
		{
			InitializeComponent();
			_dbContex1 = new MessangerDBContext();
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

			if (name.Length < 3)
			{
				MessageBox.Show("Name must be at least 3 characters long.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			if (!IsValidEmail(email))
			{
				MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			if (password.Length < 6 || !password.Any(char.IsDigit) || !password.Any(char.IsUpper) || !password.Any(char.IsLower))
			{
				MessageBox.Show("Password must be at least 6 characters long and include at least one uppercase letter, one lowercase letter, and one number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			if (!IsValidPhoneNumber(phoneNumber))
			{
				MessageBox.Show("Please enter a valid phone number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			bool userExists = _dbContex1.Users.Any(u => u.Email == email || u.PhoneNumber == phoneNumber);
			if (userExists)
			{
				MessageBox.Show("A user with this email or phone number already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
				_dbContex1.Users.Add(user);

				_dbContex1.SaveChanges();

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

		private bool IsValidEmail(string email)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == email;
			}
			catch
			{
				return false;
			}
		}
		private bool IsValidPhoneNumber(string phoneNumber)
		{
			return phoneNumber.StartsWith("+380") && phoneNumber.Length == 13 && phoneNumber.Skip(1).All(char.IsDigit);
		}
		private void Login(object sender, RoutedEventArgs e)
		{
			Login loginWindow = new Login();
			loginWindow.Show();
			this.Hide();
		}
	}
}
