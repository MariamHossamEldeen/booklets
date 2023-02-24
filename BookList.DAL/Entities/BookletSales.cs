using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklets.DAL.Entities
{
    public class BookletSales
    {
        


        public int ID { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.AddMonths(7);
        public int BookletID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        
       
    }
}
