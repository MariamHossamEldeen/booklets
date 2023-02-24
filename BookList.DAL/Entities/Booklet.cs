using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklets.DAL.Entities
{
    public enum Activity 
    {
        //[Description("Commercial")]
        Commercial,
        //[Description("Agricultural")]
        Agricultural,
        //[Description("Other")]
        Other
    };
    public enum Status
    {
        Avilable,
        Sold
    };
    public class Booklet

    {
        public int BookletID { get; set; }
        public Activity Activity { get; set; }
        public Status Status { get; set; }


        // Navigational Property One To One
        //public BookletSales BookletSales { get; set; }




    }
}
