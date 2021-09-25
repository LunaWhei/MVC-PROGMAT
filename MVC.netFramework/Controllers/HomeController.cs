using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.netFramework.Controllers;
using MVC.netFramework.Models;
using MySql.Data.MySqlClient;

namespace MVC.netFramework.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            if (Session["userID"] != null)
            {
                return View();
            }
            else
            {
               return RedirectToAction("Index", "Login");
            }
            
        }

        public ActionResult Books_Rents()
        {
            if (Session["userID"] != null)
            {
            List<RentedBooksModel> list1 = new List<RentedBooksModel>();

            MySqlConnection mysql = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            string query = "SELECT Books.Title, Books.Author, Rents.Book_id, Rents.User_login, Books.Cover,Rent_time, Users.Login FROM Rents INNER JOIN Books ON Rents.Book_id = Books.ID Inner JOin Users On Rents.User_login = Users.Id";
            MySqlCommand comm = new MySqlCommand(query);
            comm.Connection = mysql;

            mysql.Open();
            MySqlDataReader dr = comm.ExecuteReader();
            dr.Read();
            if (dr != null)
            {
                    list1.Add(new RentedBooksModel
                    {
                        BookID = dr["Book_id"].ToString(),
                        UserID = dr["User_Login"].ToString(),
                        Title = dr["Title"].ToString(),
                        Author = dr["Author"].ToString(),
                        Cover = dr["Cover"].ToString(),
                        User = dr["Login"].ToString(),
                        RentialDate = Convert.ToDateTime(dr["Rent_time"])


                    }); ;
                    
                }
            mysql.Close();
            
            return View(list1);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Delete(RentedBooksModel model)
        {
            ViewBag.ReturnBookID = model.Title.ToString();
            return RedirectToAction("Books_Rents", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}