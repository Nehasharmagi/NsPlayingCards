﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NsPlayingCards.Controllers
{
    public class PlayingCardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
       
    }
}
