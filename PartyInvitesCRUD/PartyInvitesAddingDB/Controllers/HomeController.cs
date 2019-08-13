using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using PartyLibrary2;
using static PartyLibrary2.GuestProcessor;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                int created = CreateGuest(guestResponse.Nickname, guestResponse.Fancymail,
                    guestResponse.FavouriteAnimal, guestResponse.WillAttend);
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }
        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }

        public ViewResult ListAllResponses()
        {
            string connectionString = DataAccess.GetConnectionString();
            List<GuestModel> guestList = new List<GuestModel>();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, NickName, FancyMail, AnimalName FROM PartyPeople";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GuestModel guest = new GuestModel();
                    guest.Id = Int32.Parse(reader["Id"].ToString());
                    guest.NickName = reader["NickName"].ToString();
                    guest.FancyMail = reader["FancyMail"].ToString();
                    guest.AnimalName = reader["AnimalName"].ToString();                    
                    guestList.Add(guest);
                }
            }
            return View(guestList);
        }

        public ViewResult DeleteGuest(int id )
        {
            int created = GuestProcessor.DeleteGuest(id);
            return View("ListAllResponses");
        }

    }
}
