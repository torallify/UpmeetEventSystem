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

namespace UpmeetEventSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private string connString;

        public FavoriteController(IConfiguration config)
        {
            connString = config.GetConnectionString("default");
        }

        [HttpGet("{id}")] //api/
        public IEnumerable<JoinedEvent> Get(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT FAV.ID, FAV.UserID, FAV.EventID, ";
            command += "UME.EventName, UME.Topic, UME.Description, UME.Location ";
            command += "FROM UpMeetEvents UME JOIN Favorites FAV";
            command += " ON UME.ID = FAV.EventID WHERE FAV.UserID=@id";

            IEnumerable<JoinedEvent> result = conn.Query<JoinedEvent>(command,
                new { id = id });

            conn.Close();

            return result;
        }

        //post (to add an event to favorites)
        [HttpPost]
        public Object AddToCart(Favorite favoriteEvent)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "INSERT INTO Favorites (UserID, EventID) ";
            command += "VALUES (@userID, @eventID)";

            int result = conn.Execute(command, new
            {
                userID = favoriteEvent.UserID,
                eventID = favoriteEvent.EventID,
            });

            conn.Close();

            return new
            {
                result = result,
                success = result == 1 ? true : false
            };
        }

        //delete (to remove an event from favorites)
        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "DELETE FROM Favorites WHERE ID=@id";

            int result = conn.Execute(command, new { id = id });

            conn.Close();

            //TODO: Return success or error code
            return new
            {
                result = result,
                success = result == 1 ? true : false
            };
        }
    }
}