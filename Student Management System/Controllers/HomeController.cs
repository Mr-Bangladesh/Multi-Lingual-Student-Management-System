using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Student_Management_System.Data;
using Student_Management_System.Models;
using Student_Management_System.Services;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context = null;
        private readonly ILanguageService _languageService = null;
        private readonly ICurrentDefaultService _currentDefaultService = null;
        private readonly ILocalResourceService _localResourceService = null;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, ILanguageService languageService, ICurrentDefaultService currentDefaultService, ILocalResourceService localResourceService)
        {
            _logger = logger;
            _context = context;
            _languageService = languageService;
            _currentDefaultService = currentDefaultService;
            _localResourceService = localResourceService;
        }

        public async Task<IActionResult> Index()
        {
            var languages = await _languageService.GetAllLanguageAsync();
            ViewBag.languages = new SelectList(languages, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Index(CurrentDefaultViewModel viewModel)
        {
            _currentDefaultService.AddCurrentDefaultProperty(viewModel);
            if(viewModel.PropertyId != 0)
            {
                _localResourceService.LoadLocalResourceAsync(viewModel.PropertyId);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
