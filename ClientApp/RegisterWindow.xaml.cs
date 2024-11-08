using data_access;
using data_access.NewFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
			string name = NameTextBox.Text;
			string email = EmailTextBox.Text;
			string password = PasswordBox.Password;
			string phoneNumber = PasswordBox.Password;

			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			var existingUser = _dbContext.Users.FirstOrDefault(u => u.Email == email);
			if (existingUser != null)
			{
				MessageBox.Show("A user with this email already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			var newUser = new User(name, email, password, phoneNumber);

			_dbContext.Users.Add(newUser);
			_dbContext.SaveChanges();

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
