using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Collections.ObjectModel;
using data_access.NewFolder;
using Microsoft.EntityFrameworkCore;
using data_access;


namespace ClientApp
{

	public partial class MainWindow : Window
	{
		IPEndPoint serverEndPoint;
		ObservableCollection<MessageInfo> messages = new ObservableCollection<MessageInfo>();
		ViewModel ViewModel;
        MessangerDBContext messangerDBContext = new MessangerDBContext();
        UdpClient client;
        
		public MainWindow()
		{
			InitializeComponent();
			ViewModel = new ViewModel();
			this.DataContext = ViewModel;
			client = new UdpClient();
			//string address = ConfigurationManager.AppSettings["ServerAddress"]!;
			//short port = short.Parse(ConfigurationManager.AppSettings["ServerPort"]!);
			//serverEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
		}

		private void Send(object sender, RoutedEventArgs e)
        {
            string message = textbox.Text;
            if (!string.IsNullOrEmpty(message))
            {
                SendMessage(message);
                textbox.Clear();
            }
        }
		private async void SendMessage(string message)
		{
			if (serverEndPoint != null)
			{
				byte[] data = Encoding.UTF8.GetBytes(message);
				await client.SendAsync(data, serverEndPoint);
			}
		}
		private void Settings(object sender, RoutedEventArgs e)
		{
			Settings settings = new Settings();
			settings.Show();
		}

		private void Add_Contact(object sender, RoutedEventArgs e)
		{
			User userr = new User();
			AddContact addContact = new AddContact(userr);
			userr.Port = 4040;
			userr.ServerAddress = "127.0.0.1";
			userr.PhoneNumber = "3333";


			addContact.ShowDialog();

			ViewModel.Add(userr);
            messangerDBContext.Add(userr);
            messangerDBContext.SaveChanges();

			
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			MessageBox.Show(ViewModel.SelectedItem.Name);
        }
    }
	public class ViewModel 
	{
        public ObservableCollection<User> users = new ObservableCollection<User>();
        public User SelectedItem { get; set; }
		public void Add(User user)
		{
            users.Add(user);
        }
    }
}