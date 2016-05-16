﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MartinKMe.ViewModels.Speaking;
using MartinKMe.Models;
using Microsoft.Data.Entity;

namespace MartinKMe.Controllers
{
    public class SpeakingController : Controller
    {
        private ApplicationDbContext _context;

        public SpeakingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var talks = await _context.Talk.ToListAsync();

            var vm = new IndexViewModel()
            {
                Talks = talks
            };
     
            return View(vm);
        }

        public async Task<IActionResult> Talk(string talk)
        {
            var thisTalk = await _context.Talk.Where(o => o.Url.ToLower() == talk).FirstOrDefaultAsync();

            var vm = new TalkViewModel()
            {
                ThisTalk = thisTalk
            };

            return View(vm);
        }


    }
}
