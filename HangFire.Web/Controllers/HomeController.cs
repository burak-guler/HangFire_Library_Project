using Hangfire;
using Hangfire.Annotations;
using HangFire.Web.Models;
using HangFire.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HangFire.Web.Controllers
{
    public class HomeController : Controller
    {
        private IMessageService messageService;

        public HomeController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public void Index()
        {
            RecurringJob.AddOrUpdate("my-recurring-job", () => messageService.SendMessage(), "* * * * * *");
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