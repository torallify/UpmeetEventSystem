using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UpmeetEventSystem.Models;
using Dapper;

namespace UpmeetEventSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private string connString;

        public EventController(IConfiguration config)
        {
            connString = config.GetConnectionString("default");
        }

        // get: all the events
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM UpMeetEvents";

            IEnumerable<Event> result = conn.Query<Event>(command);

            conn.Close();

            return result;
        }

        // getDetail: all the info on one event
        [HttpGet("{id}")] // /api/1
        public Event GetDetail(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM UpMeetEvents WHERE ID=@id";

            Event result = conn.QueryFirst<Event>(command, new { id = id });

            conn.Close();

            return result;
        }

        //getTopics: Just returns the category names (DISTINCT)
        [HttpGet("topics")] // /api/topics
        public IEnumerable<string> GetCategories()
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT DISTINCT Topic FROM UpMeetEvents";

            IEnumerable<string> result = conn.Query<string>(command);

            conn.Close();

            return result;
        }

        // getByCategory: all the info on events within a given category
        [HttpGet("topics/{top}")] //  /api/menu/categories/entrees
        public IEnumerable<Event> GetByTopic(string top)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM UpMeetEvents WHERE Topic=@topic";

            IEnumerable<Event> result = conn.Query<Event>(command,
                new { topic = top });

            conn.Close();

            return result;
        }
    }
}