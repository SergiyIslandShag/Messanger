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
		User userMain;
        
		public MainWindow()
		{
			InitializeComponent();
			ViewModel = new ViewModel();
			this.DataContext = ViewModel;
			client = new UdpClient();
			string address = ConfigurationManager.AppSettings["ServerAddress"]!;
			short port = short.Parse(ConfigurationManager.AppSettings["ServerPort"]!);
			serverEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
		}
        //join
        private void JoinBtn(object sender, RoutedEventArgs e)
        {
            string message = "$<join>";
            SendMessage(message);
            Listen();
        }
        private void Send(object sender, RoutedEventArgs e)
        {
            
            string message = textbox22.Text;
            SendMessage(message);
            MessageInfo messageInfo = new MessageInfo(message , DateTime.Now);
            ViewModel.Add2(messageInfo);
           // messangerDBContext.Add(messageInfo);
           // messangerDBContext.SaveChanges();
        }
        private async void SendMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(data, data.Length, serverEndPoint);
            
        }
        private async void Listen()
        public MainWindow(User user)
        {
            InitializeComponent();
            ViewModel = new ViewModel();
            this.DataContext = ViewModel;
            client = new UdpClient();
			userMain = user;
            //string address = ConfigurationManager.AppSettings["ServerAddress"]!;
            //short port = short.Parse(ConfigurationManager.AppSettings["ServerPort"]!);
            //serverEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
        }

        private void Send(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                var data = await client.ReceiveAsync();
                string message = Encoding.UTF8.GetString(data.Buffer);
                messages.Add(new MessageInfo(message, DateTime.Now));
            }
        }
        private void Settings(object sender, RoutedEventArgs e)
		{
			Settings settings = new Settings(userMain);
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    public class ViewModel 
	{
        private ObservableCollection<User> users = new ObservableCollection<User>();
        private ObservableCollection<MessageInfo> messages = new ObservableCollection<MessageInfo>();
		public IEnumerable<User> Users => users;
        public IEnumerable<MessageInfo> Messages => messages;
        public User SelectedItem { get; set; }
		public void Add(User user )
		{
            users.Add(user);
            
        }
        public void Add2( MessageInfo mess)
        {
           
            messages.Add(mess);
        }
    }
}