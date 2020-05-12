using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UpmeetEventSystem.Models;

namespace UpmeetEventSystem.Services
{
    public class DAL
    {
        private string connString;

        public DAL(IConfiguration config)
        {
            connString = config.GetConnectionString("default");
        }

        public IEnumerable<Event> GetAllEvents()
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM UpMeetEvents";

            IEnumerable<Event> result = conn.Query<Event>(command);

            conn.Close();

            return result;
        }

        public Event GetDetail(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM UpMeetEvents WHERE ID=@id";

            Event result = conn.QueryFirst<Event>(command, new { id = id });

            conn.Close();

            return result;
        }

        public IEnumerable<string> GetTopics()
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT DISTINCT Topic FROM UpMeetEvents";

            IEnumerable<string> result = conn.Query<string>(command);

            conn.Close();

            return result;
        }

        public IEnumerable<Event> GetByTopic(string top)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM UpMeetEvents WHERE Topic=@topic";

            IEnumerable<Event> result = conn.Query<Event>(command,
                new { topic = top });

            conn.Close();

            return result;
        }

        public IEnumerable<JoinedEvent> GetAllFavoriteEvents(int id)
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

        public Object AddToFavoriteEvents(Favorite favoriteEvent)
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

        public Object Delete(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "DELETE FROM Favorites WHERE ID=@id";

            int result = conn.Execute(command, new { id = id });

            conn.Close();

            return new
            {
                result = result,
                success = result == 1 ? true : false
            };
        }
    }
}
