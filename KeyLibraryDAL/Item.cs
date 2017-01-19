using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyLibraryDAL
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int DevID { get; set; }
        public int PublisherID { get; set; }
    }
}
