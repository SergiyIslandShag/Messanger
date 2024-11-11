using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using data_access;
using data_access.NewFolder;

namespace ClientApp
{
	public partial class Settings : Window
	{
        private readonly MessangerDBContext dbContext;
		private const string PremiumCode = "timlidtop";
		private bool isPremiumActivated = false;
		public Settings()
		{
			InitializeComponent();
            dbContext = new MessangerDBContext();
			userInfoListBox.ItemsSource= dbContext.Users.ToList();	
        }


		private void btnPremium_Click(object sender, RoutedEventArgs e)
		{
			if (txtPremiumCode.Text == PremiumCode)
			{
				if (!isPremiumActivated)
				{

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