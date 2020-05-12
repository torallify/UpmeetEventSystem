using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UpmeetEventSystem.Models;
using UpmeetEventSystem.Services;

namespace UpmeetEventSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private DAL dal;

        public FavoriteController(IConfiguration config)
        {
            dal = new DAL(config);
        }

        [HttpGet("{id}")] //api/
        public IEnumerable<JoinedEvent> Get(int id)
        {
            return dal.GetAllFavoriteEvents(id);
        }

        //post (to add an event to favorites)
        [HttpPost]
        public Object AddToFavoriteEvents(Favorite favoriteEvent)
        {
            return dal.AddToFavoriteEvents(favoriteEvent);
        }

        //delete (to remove an event from favorites)
        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}