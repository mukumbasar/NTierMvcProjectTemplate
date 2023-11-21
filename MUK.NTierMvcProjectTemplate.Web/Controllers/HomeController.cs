using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MUK.NTierMvcProjectTemplate.BL.Services;
using MUK.NTierMvcProjectTemplate.Web.Models;
using System.Diagnostics;

namespace MUK.NTierMvcProjectTemplate.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IMakaleService _makaleManager;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMakaleService makaleManager, IMapper mapper)
		{
			_logger = logger;
			_makaleManager = makaleManager;
			_mapper = mapper;
		}

		public IActionResult Index()
		{

			var dtos = _makaleManager.GetAll().Context;
			var vms = _mapper.Map<List<MakaleViewModel>>(dtos);

			return View(vms);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}