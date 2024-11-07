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

namespace ClientApp
{

	public partial class MainWindow : Window
	{
		IPEndPoint serverEndPoint;
		ObservableCollection<MessageInfo> messages = new ObservableCollection<MessageInfo>();
		ObservableCollection<User> users = new ObservableCollection<User>();
		UdpClient client;
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = users;
			client = new UdpClient();
			//string address = ConfigurationManager.AppSettings["ServerAddress"]!;
			//short port = short.Parse(ConfigurationManager.AppSettings["ServerPort"]!);
			//serverEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
		}

		private void Send(object sender, RoutedEventArgs e)
		{
			//string message = textbox.Text;
			//SendMessage(message);

		}
		private async void SendMessage(string message)
		{
			byte[] data = Encoding.UTF8.GetBytes(message);
			await client.SendAsync(data, serverEndPoint);
		}
		private void Search(object sender, RoutedEventArgs e)
		{

		}

		private void Settings(object sender, RoutedEventArgs e)
		{
			Settings settings = new Settings();
			settings.Show();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
		{

		}


		private void Button_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
		}
	}
}