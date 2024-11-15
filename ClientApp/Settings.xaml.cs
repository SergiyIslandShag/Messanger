using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using data_access;
using data_access.NewFolder;

namespace ClientApp
{
    public partial class Settings : Window
    {
        private readonly MessangerDBContext dbContext;
        private const string PremiumCode = "timlidtop";
        private bool isPremiumActivated = false;
        User userSetting;

        public Settings()
        {
            InitializeComponent();
            dbContext = new MessangerDBContext();
            var users = dbContext.Users.ToList();
            userInfoListBox.ItemsSource = users;
        }
        public Settings(User user)
        {
            InitializeComponent();
            dbContext = new MessangerDBContext();
            List<User> users = new List<User>();
            users.Add(user);
            userInfoListBox.ItemsSource = users;
        }

        private void btnPremium_Click(object sender, RoutedEventArgs e)
        {
            if (txtPremiumCode.Text == PremiumCode)
            {
                if (!isPremiumActivated)
                {
                    foreach (var user in dbContext.Users)
                    {
                        user.Name += " $"; 
                    }
                    userInfoListBox.ItemsSource = dbContext.Users.ToList();
                    isPremiumActivated = true;
                    MessageBox.Show("Premium version activated!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Premium version is already activated.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid code. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
