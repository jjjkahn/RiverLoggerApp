//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using RiverLoggerApi.Models;
//using RiverLoggerApi.Repository.DbModels;
//using RiverLoggerApi.Services;

//namespace RiverLoggerApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EventController : ControllerBase
//    {
//        private readonly EventService eventService;
//        private readonly IAuthService authService;
//        private readonly IMapper mapper;

//        public EventController(EventService eventService, IAuthService authService, IMapper mapper)
//        {
//            this.eventService = eventService;
//            this.authService = authService;
//            this.mapper = mapper;
//        }

//        [HttpGet]
//        [Authorize]
//        public ActionResult<Event[]> GetAllForUser()
//        {
//            try
//            {
//                var userEmail = authService. .DecodeEmailFromToken(this.Request.Headers["Authorization"]);
//                var events = this.eventService.GetAllForUser(userEmail);
//                return Ok(events);
//            }
//            catch (Exception error)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpGet("{id}")]
//        [Authorize]
//        public ActionResult<Event> GetById(string id)
//        {
//            try
//            {
//                var eventEntity = this.eventService.GetById(id);

//                if (eventEntity != null)
//                {
//                    return Ok(eventEntity);
//                }

//                return NotFound();
//            }
//            catch (Exception error)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpPost]
//        [Authorize(Roles = "Administrator")]
//        public ActionResult<Event> Create(EventInputModel model)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    var mappedModel = this.mapper.Map<EventInputModel, Event>(model);
//                    var users = model.UserEmails.Select(x => this.authService.GetByEmail(x));
//                    mappedModel.UserEvents = users.Select(x => new UserEvent() { EventId = model.Id, UserId = x.UserId, User = x }).ToList();
//                    var eventEntity = this.eventService.Create(mappedModel);
//                    return Ok(eventEntity);
//                }

//                return BadRequest(ModelState);
//            }
//            catch (Exception error)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpPut]
//        [Authorize(Roles = "Administrator")]
//        public ActionResult<Event> Update(EventInputModel model)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    var mappedModel = this.mapper.Map<EventInputModel, Event>(model);
//                    var eventEntity = this.eventService.Update(mappedModel);
//                    if (eventEntity != null)
//                    {
//                        return Ok(eventEntity);
//                    }

//                    return NotFound();
//                }

//                return BadRequest(ModelState);
//            }
//            catch (Exception error)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpDelete("{id}")]
//        [Authorize(Roles = "Administrator")]
//        public ActionResult<Event> Delete(string id)
//        {
//            try
//            {
//                var eventEntity = this.eventService.Delete(id);
//                if (eventEntity != null)
//                {
//                    return Ok(eventEntity);
//                }

//                return NotFound();
//            }
//            catch (Exception error)
//            {
//                return StatusCode(500);
//            }
//        }

//    }
//}
