using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelWindoes10App
{
    class Hotel
    {
        public Hotel()
        {
            Rooms = new HashSet<Room>();
        }
        
        public int Hotel_No { get; set; }

        public string Name { get; set; }
        
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
