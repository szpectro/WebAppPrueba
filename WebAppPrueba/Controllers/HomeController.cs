using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WEBapi.Services;
using WebAppPrueba.Models;

namespace WebAppPrueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebApi _webApi;
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IWebApi webApi, IConfiguration configuration,ILogger<HomeController> logger)
        {
            _logger = logger;
            _webApi = webApi;
            _configuration = configuration;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                var token = await _webApi.GetToken(_configuration["WebApi:username"], _configuration["WebApi:password"]);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
            return View();
        }

        public IActionResult Vista()
        {

            return View();
        }
        public IActionResult Index2() 
        {
            try
            {
            }
            catch (Exception ex) {
                Debug.Write(ex);
            }
            return View();
        }

        [Authorize(Roles = "ADMIN")]
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
