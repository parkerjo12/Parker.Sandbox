using Microsoft.IdentityModel.Protocols.WSFederation;
using Microsoft.IdentityModel.Web;
using Parker.Sandbox.Infrastructure;
using Parker.Sandbox.Views.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
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

		public ActionResult Protect()
		{
			var config = WebConfigurationManager.OpenWebConfiguration("/");
			var section = config.GetSection("sandbox");

			if (section != null && !section.SectionInformation.IsProtected)
			{
				section.SectionInformation.ProtectSection("RSAProtectedConfigurationProvider");
				config.SaveAs(@"C:\Projects\Misc\Parker.Sandbox\Parker.Sandbox\protected.config");
			}

			return new HttpStatusCodeResult(200);
		}

		public ActionResult Unprotect()
		{
			var config = WebConfigurationManager.OpenWebConfiguration("/");
			var section = config.GetSection("sandbox");

			if (section != null && section.SectionInformation.IsProtected)
			{
				section.SectionInformation.UnprotectSection();
			}

			return new HttpStatusCodeResult(200);
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Logoff()
		{
			FederatedAuthentication.SessionAuthenticationModule.SignOut();

			var signOutRequest = new SignOutRequestMessage(new Uri(FederatedAuthentication.WSFederationAuthenticationModule.Issuer));

			HttpContext.Response.Redirect(signOutRequest.WriteQueryString());

			return new HttpStatusCodeResult(HttpStatusCode.NotFound);
		}

		public ActionResult DraftLottery()
		{
			var listModel = new[] {
				new FantasyTeamViewModel { TeamName = "$$ Dollar Dollar $$", Coach = "Parker" },
				new FantasyTeamViewModel { TeamName = "Geno 911!", Coach = "Rashad" },
				new FantasyTeamViewModel { TeamName = "BEERcules", Coach = "Zak"},
				new FantasyTeamViewModel { TeamName = "U Mad Bro?", Coach = "Drew" },
				new FantasyTeamViewModel { TeamName = "Skys Out Thighs Out", Coach = "Allen" },
				new FantasyTeamViewModel { TeamName = "White Lies Matter", Coach = "Shining Light" },
				new FantasyTeamViewModel { TeamName = "Rusty Trombone", Coach = "Mitch" },
				new FantasyTeamViewModel { TeamName = "He's Back", Coach = "Schirmer" },
				new FantasyTeamViewModel { TeamName = "Stroke-Genius", Coach = "Kelcey" },
				new FantasyTeamViewModel { TeamName = "Enter The Tebow", Coach = "Aaron" }
			}.OrderBy(m => Guid.NewGuid()).ToList();

			foreach (var model in listModel)
				model.Id = listModel.IndexOf(model) + 1;

			return View(listModel);
		}

		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult MASCProfile(MASCProfileViewModel model)
		{
			return View();
		}

		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Checkout()
		{
			return View();
		}

		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Receipt()
		{
			return View();
		}
	}

	public class MASCProfileViewModel
	{
		public string Id { get; set; }
		public string CustomerIdentifier { get; set; }
	}
}