using MVC.netFramework.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.netFramework.Controllers
{ 
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(LoginModel model)
        {

            try
            {
                MySqlConnection mysql = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                string query = "select * from Users where `login` =" + "\"" + model.Login + "\"" + "AND Password =" + "\"" + model.Password + "\"";
                MySqlCommand comm = new MySqlCommand(query);
                comm.Connection = mysql;

                mysql.Open();
                MySqlDataReader dr = comm.ExecuteReader();
                dr.Read();
                if (dr != null)
                {
                    Session["userID"] = dr["Login"].ToString();
                    Session["userID_ID"] = dr["ID"].ToString();
                }
                mysql.Close();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["name"] = "Niestety wystąpił problem podczas logowania";
                return RedirectToAction("Index", "Login");
            }
            
        }
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("index", "Home");
        }

    }
}