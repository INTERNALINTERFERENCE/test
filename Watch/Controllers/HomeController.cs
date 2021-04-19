using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watch.Models;

namespace Watch.Controllers
{
    public class HomeController : Controller
    {
        static RoomData roomData = new RoomData();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //join room button
        public RedirectResult JoinRoom(string userName, string roomCode)
        {
            //only for test
            //roomData.UserName = userName;
            //roomData.RoomCode = roomCode;
            //return Content($"{userName} joined the room");
            return Redirect("Player/VideoPlayer");
        }

        //create room button
        public IActionResult CreateRoom(string userName)
        {
            //only for test
            roomData.Users.Add(userName);
            var users = roomData.Users;

            return Content($"{userName} created the room, users online: {String.Join(',', users)}");
        }
      
    }
}
