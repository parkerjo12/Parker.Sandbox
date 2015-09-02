using Microsoft.IdentityModel.Protocols.WSFederation;
using Microsoft.IdentityModel.Web;
using Parker.Sandbox.Views.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parker.Sandbox.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Logoff()
		{
			if (HttpContext.User.Identity.IsAuthenticated)
			{
				FederatedAuthentication.SessionAuthenticationModule.SignOut();

				var signOutRequest = new SignOutRequestMessage(new Uri(FederatedAuthentication.WSFederationAuthenticationModule.Issuer), "https://masc-sts.vc3.com/logoff.aspx");

				HttpContext.Response.Redirect(signOutRequest.WriteQueryString());
			}

			return RedirectToActionPermanent("Index");
		}

		public ActionResult DraftLottery()
		{
			return View(new[] {
				new FantasyTeamViewModel { Id = 1,  TeamName = "Suns Out Guns Out", Coach = "Parker" },
				new FantasyTeamViewModel { Id = 2,  TeamName = "Geno 911!", Coach = "Rashad" },
                new FantasyTeamViewModel { Id = 3,  TeamName = "Yuuuupp pppppp", Coach = "Zak"},
				new FantasyTeamViewModel { Id = 4,  TeamName = "U Mad Bro?", Coach = "Drew" },
				new FantasyTeamViewModel { Id = 5,  TeamName = "Skys Out Thighs Out", Coach = "Allen" },
				new FantasyTeamViewModel { Id = 6,  TeamName = "Trap Queen", Coach = "Shining Light" },
				new FantasyTeamViewModel { Id = 7,  TeamName = "Rusty Trombone", Coach = "Mitch" },
				new FantasyTeamViewModel { Id = 8,  TeamName = "He's Back", Coach = "Schirmer" },
				new FantasyTeamViewModel { Id = 9,  TeamName = "Stroke Genius", Coach = "Kelcey" },
				new FantasyTeamViewModel { Id = 10,  TeamName = "Late to the Party", Coach = "Aaron" }
			});
		}
	}
}