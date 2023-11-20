using Microsoft.AspNetCore.Mvc;
using MUK.NTierMvcProjectTemplate.Web.Models;
using MUK.NTierMvcProjectTemplate.BL.Services;
using System.Diagnostics;
using System.Security.Cryptography;
using AutoMapper;
using MUK.NTierMvcProjectTemplate.Dtos.Concrete;
using Microsoft.AspNetCore.Identity;
using MUK.NTierMvcProjectTemplate.BL.Managers;

namespace MUK.NTierMvcProjectTemplate.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IEmailService emailService, IAccountService accountService, IMapper mapper)
        {
            _emailService = emailService;
            _accountService = accountService;
            _mapper = mapper;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {   
            if(ModelState.IsValid)
            {
                var dto = _mapper.Map<CreateAppUserDto>(vm);
                var result = await _accountService.RegisterAsync(dto);

                if (result.IsSuccess)
                {
                    return RedirectToAction("LogIn");
                }
                ViewBag.RegisterError = result.Message;
            }
            
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> EmailActivation(string userId, string token)
        {
            var result = await _accountService.ActivateEmailAsync(userId, token);

            ViewBag.LoginMessage = result.Message;

            return View("LogIn");
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel wm)
        {
            if(ModelState.IsValid)
            {
                var dto = _mapper.Map<LogInAppUserDto>(wm);
                var result = await _accountService.LogInAsync(dto);

                if(result.IsSuccess)
                {
                    return RedirectToAction("Manage","Thing");
                }
                
                ViewBag.LoginMessage = result.Message;
                return View(wm);
            }
            return View(wm);
        }

        public async Task<IActionResult> LogOut()
        {
            _accountService.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
