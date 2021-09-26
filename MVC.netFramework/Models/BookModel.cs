using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC.netFramework.Models
{
    public class BookModel
    {
        [DisplayName("Tytuł")]
        public string Title { get; set; }
        [DisplayName("Autor")]
        public string Author { get; set; }
        [DisplayName("Opis")]
        public string Cover { get; set; }
        public string BookID { get; set; }
    }
}