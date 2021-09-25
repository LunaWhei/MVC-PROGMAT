using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.netFramework.Models
{
    public class RentedBooksModel
    {
        public string BookID { get; set; }
        public string UserID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string User { get; set; }
        public DateTime RentialDate { get; set; }
    }
}