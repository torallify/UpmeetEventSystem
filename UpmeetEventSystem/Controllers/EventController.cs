using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using UpmeetEventSystem.Services;
using UpmeetEventSystem.Models;

namespace UpmeetEventSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private DAL dal;

        public EventController(IConfiguration config)
        {
            dal = new DAL(config);
        }

        // get: all the events
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return dal.GetAllEvents();
        }

        // getDetail: all the info on one event
        [HttpGet("{id}")] // /api/1
        public Event GetDetail(int id)
        {
            return dal.GetDetail(id);
        }

        //getTopics: Just returns the category names (DISTINCT)
        [HttpGet("topics")] // /api/topics
        public IEnumerable<string> GetTopics()
        {
            return dal.GetTopics();
        }

        // getByCategory: all the info on events within a given category
        [HttpGet("topics/{top}")] //  /api/menu/categories/entrees
        public IEnumerable<Event> GetByTopic(string top)
        {
            return dal.GetByTopic(top);
        }

        [HttpPost]
        public int AddEvent(Event newEvent)
        {
            int result = dal.AddEvent(newEvent);
            return result;
        }

    }
}