using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data_access.NewFolder
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ServerAddress { get; set; }
        public int Port { get; set; }
        public ICollection<MessageInfo> Messages { get; set; }
        public User(int id,string name, string num, string address, int port)
        {
            Id = id;
            Name = name;
            PhoneNumber = num;
            ServerAddress = address;
            Port = port;
        }    
            
            
    }
}
