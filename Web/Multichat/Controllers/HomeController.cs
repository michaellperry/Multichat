using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multichat.Models;
using Multichat.Model;

namespace Multichat.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Home/

        [HttpPost]
        public ActionResult Index(MessageBoardRequest request)
        {
            return Redirect("~/home/messageboard/" + Uri.EscapeUriString(request.Topic));
        }

        //
        // GET: /Home/MessageBoard/<topic>

        public ActionResult MessageBoard(string id)
        {
            var messageBoard = MvcApplication.SynchronizationService.GetMessageBoard(id);
            return View(new MessageBoardViewModel(messageBoard));
        }

        //
        // POST: /Home/MessageBoard/<topic>

        [HttpPost]
        public ActionResult MessageBoard(string id, MessageRequest request)
        {
            var messageBoard = MvcApplication.SynchronizationService.GetMessageBoard(id);
            messageBoard.SendMessage(request.Text);
            return Redirect("~/home/messageboard/" + Uri.EscapeUriString(id));
        }

    }
}
