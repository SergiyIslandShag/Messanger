using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.NewFolder
{
    public class MessageInfo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }


        public User User { get; set; }
        public int UserId { get; set; }
        public MessageInfo(string Text, DateTime Date)
        {
            this.Text = Text; this.Date = Date;
        }
        public override string ToString()
        {
            return $"{Text} . Date : {Date}";
        }
    }
}
