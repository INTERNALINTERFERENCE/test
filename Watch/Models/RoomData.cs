using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch.Models
{
    public class RoomData
    {
        public string UserName { get; set; }
        public string RoomCode { get; set; }

        public List<string> Users { get; set; } = new List<string>();
    }
}
