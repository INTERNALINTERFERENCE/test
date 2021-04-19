using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watch.Models;

namespace Watch.Controllers
{
    public class PlayerController : Controller
    {
        public static RoomData roomData = new RoomData();

        public IActionResult VideoPlayer(string userName, string roomCode)
        {
            roomData.UserName = userName;
            roomData.RoomCode = roomCode;

            return View(roomData);
        }
    }
}
