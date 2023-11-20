using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MUK.NTierMvcProjectTemplate.BL.Managers;
using MUK.NTierMvcProjectTemplate.BL.Services;
using MUK.NTierMvcProjectTemplate.Dtos.Concrete;
using MUK.NTierMvcProjectTemplate.Entities.Concretes;
using MUK.NTierMvcProjectTemplate.Web.Models;
using System.Security.Claims;

namespace MUK.NTierMvcProjectTemplate.Web.Controllers
{
    public class MakaleController : Controller
    {
        private readonly IMakaleService _makaleManager;
        private readonly IKonuService _konuService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public MakaleController(IMapper mapper, IMakaleService makaleManager, IKonuService konuService, UserManager<AppUser> userManager)
        {
            _makaleManager = makaleManager;
            _mapper = mapper;
            _konuService = konuService;
            _userManager = userManager;
        }

        public IActionResult Manage()
        {
            var dtos = _makaleManager.GetAll().Context.Where(x => x.AppUserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.Bloglar = _mapper.Map<List<MakaleViewModel>>(dtos);
            var konuVms = _konuService.GetAll().Context;
            var konular = new List<SelectListItem>();

            foreach (var item in konuVms)
            {
                konular.Add(new SelectListItem { Text = item.Ad, Value = item.Id.ToString() });
            }

            ViewBag.Konular = konular;

            return View();
        }

        [HttpPost]
        public IActionResult Add(MakaleViewModel vm) 
        {
            var dto = _mapper.Map<MakaleDto>(vm);
            dto.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _makaleManager.Insert(dto);
            return RedirectToAction("Manage");
        }

        public IActionResult Edit(int id) 
        {
            var item = _makaleManager.Get(id).Context;
            var wm = _mapper.Map<MakaleViewModel>(item);
            
            var konuVms = _konuService.GetAll().Context;
            var konular = new List<SelectListItem>();

            foreach (var item2 in konuVms)
            {
                konular.Add(new SelectListItem { Text = item2.Ad, Value = item2.Id.ToString() });
            }

            ViewBag.Konular = konular;
            return View(wm);
        }

        [HttpPost]
        public IActionResult Edit(MakaleViewModel vm)
        {
            var dto = _mapper.Map<MakaleDto>(vm);
            dto.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _makaleManager.Update(dto);
            return RedirectToAction("Manage");
        }

        
        public IActionResult Delete(int id) 
        {
            var dto = (_makaleManager.Get(id).Context);
            _makaleManager.Delete(dto);
            return RedirectToAction("Manage");
        }

        public IActionResult Oku(int id)
        {
            var dto = _makaleManager.Get(id).Context;
            dto.OkunmaSayisi += 1;
            _makaleManager.Update(dto);
            var user =  _userManager.Users.Where(u => u.Id == dto.AppUserId).FirstOrDefault();
            ViewBag.Yazar = user.Name + " " + user.Surname;
            var vm = _mapper.Map<MakaleViewModel>(dto);
            return View(vm);
        }
    }
}
