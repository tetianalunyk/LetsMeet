using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LetsTogether.BLL.DTO;
using LetsTogether.BLL.Interfaces;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using LetsTogether.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LetsTogether.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;
        private readonly IProfileService profileService;
        private readonly IEventService eventService;
        private readonly IProfileManager profileManager;
        private readonly IMapper mapper;


        public EventController(
            IUserService _userService,
            IEventService _eventService,
            ICategoryService _categoryService,
            IProfileService _profileService,
            IProfileManager _profileManager,
            IMapper _mapper

            )
        {
            userService = _userService;
            eventService = _eventService;
            categoryService = _categoryService;
            profileService = _profileService;
            profileManager = _profileManager;
            mapper = _mapper;
    }

        public IActionResult AddEvent()
        {
            EventModel eventModel = new EventModel
            {
                Categories = categoryService.Categories(),
                SelectedCategories = new List<string>()
            };
            return View(eventModel);
        }

        public IActionResult MyEvents(string id)
        {
            List<MyEventsModel> myEvents = new List<MyEventsModel>();
            foreach (var eve in eventService.GetEvents(id))
            {
                myEvents.Add(mapper.Map<EventsDTO, MyEventsModel>(eve));
            }
            return View(myEvents);
        }

        public async Task<IActionResult> VisitEvent(int id)
        {
            User user = profileManager.FindByUserName(User.Identity.Name);
            eventService.Visit(id, user.Id);
            return RedirectToAction("AllEvents", new { id = user.Id });
        }


        public async Task<IActionResult> NotVisitEvent(int id)
        {
            User user = profileManager.FindByUserName(User.Identity.Name);
            eventService.NotVisit(id, user.Id);
            return RedirectToAction("AllEvents", new { id = user.Id });
        }

        public IActionResult AllEvents(string id)
        {
            List<MyEventsModel> myEvents = new List<MyEventsModel>();
            foreach (var eve in eventService.AllEvents(id))
            {
                myEvents.Add(mapper.Map<EventsDTO, MyEventsModel>(eve));
            }
            return View(myEvents);
        }

       [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddEvent(EventModel model)
        {
            User user = profileManager.FindByUserName(User.Identity.Name);
            if (model.DateFrom < DateTime.Now)
            {
                ModelState.AddModelError("", "Wrong Date of Beginning");
            }
            else { 
                if (model.DateFrom > model.DateTo)
                    ModelState.AddModelError("", "Wrong Date of End");
                else
                {
                    EventDTO eventDTO = mapper.Map<EventModel, EventDTO>(model);
                    eventDTO.UserId = user.Id;
                    await eventService.Add(eventDTO);
                    return RedirectToAction("Profile", "Profile");
                }
            }
            model.Categories = categoryService.Categories();
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}