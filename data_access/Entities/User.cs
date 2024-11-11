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
		public string Password {  get; set; }
		public string Email {  get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ServerAddress { get; set; }
        public int Port { get; set; }
        public ICollection<MessageInfo> Messages { get; set; }
        public User() { }   
        public User(int id, string name, string password, string email,  string address, int port, string phoneNumber)
        {
            Id = id;
            Name = name;
            Password= password;
            Email = email;
            PhoneNumber = phoneNumber;
			ServerAddress = address;
            Port = port;
        }
        public override string ToString()
        {
            return $"{Name }";
        }
    }
}
