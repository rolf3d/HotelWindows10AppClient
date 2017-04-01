using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelWindoes10App
{
    class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        
        public int Room_No { get; set; }

      
        public int Hotel_No { get; set; }

        //[StringLength(1)]
        public string Types { get; set; }

        public double? Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
