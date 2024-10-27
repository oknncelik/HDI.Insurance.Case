using HDI.Core.Results;
using HDI.Entities.DTOs;
using HDI.Partner.Integration.Abstruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HDI.Partner.UI.Controllers
{
    public class WorkController : Controller
    {
        private readonly IPartnerService _partnerService;
        public WorkController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}