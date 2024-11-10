using data_access.NewFolder;
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

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public User User { get; set; }
        public AddContact()
        {
            InitializeComponent();
            User = new User();
        }
        public AddContact(User user)
        {
            InitializeComponent();
            User = user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User.Name =NameTextBox.Text;
            User.Email =EmailTextBox.Text;
            User.Password = PasswordBox.Password;
            this.Hide();
        }
    }
}
