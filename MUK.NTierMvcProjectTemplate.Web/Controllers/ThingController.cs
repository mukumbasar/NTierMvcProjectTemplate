using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MUK.NTierMvcProjectTemplate.BL.Managers;
using MUK.NTierMvcProjectTemplate.BL.Services;
using MUK.NTierMvcProjectTemplate.Dtos.Concrete;
using MUK.NTierMvcProjectTemplate.Entities.Concrete;
using MUK.NTierMvcProjectTemplate.Web.Models;
using System.Security.Claims;

namespace MUK.NTierMvcProjectTemplate.Web.Controllers
{
    public class ThingController : Controller
    {
        private readonly IThingService _thingManager;
        private readonly IMapper _mapper;

        public ThingController(IMapper mapper, IThingService thingManager)
        {
            _thingManager = thingManager;
            _mapper = mapper;
        }

        public IActionResult Manage()
        {
            var dtos = (_thingManager.GetAll()).Context;
            ViewBag.Things = _mapper.Map<List<ThingViewModel>>(dtos);
            return View();
        }

        [HttpPost]
        public IActionResult Add(ThingViewModel vm) 
        {
            var dto = _mapper.Map<ThingDto>(vm);
            dto.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _thingManager.Insert(dto);
            return RedirectToAction("Manage");
        }

        public IActionResult Edit(int id) 
        {
            var item = _thingManager.Get(id).Context;
            var wm = _mapper.Map<ThingViewModel>(item);
            return View(wm);
        }

        [HttpPost]
        public IActionResult Edit(ThingViewModel vm)
        {
            var dto = _mapper.Map<ThingDto>(vm);
            dto.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _thingManager.Update(dto);
            return RedirectToAction("Manage");
        }

        
        public IActionResult Delete(int id) 
        { 
            var dto = (_thingManager.Get(id).Context);
            _thingManager.Delete(dto);
            return RedirectToAction("Manage");
        }
    }
}
