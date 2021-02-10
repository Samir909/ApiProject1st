using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WepApiProject.Models;

namespace WepApiProject.Controllers
{
    public class UserController : ApiController
    {

        DatabaseContext db = new DatabaseContext();

        //api/user
        public IEnumerable<User> GetUsers()
        {
            return db.users.ToList();
        }

        //api/user/2
        public User GetUser(int id)
        {
            return db.users.Find(id);
        }


        //api/user
        [HttpPost]
        public HttpResponseMessage AddUser(User model)
        {

            try
            {
                db.users.Add(model);
                db.SaveChanges();
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.Created);
                return responseMessage;
            }
            catch(Exception ex)
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return responseMessage;
            }

        }

        [HttpPost]
        public HttpResponseMessage UpdateUser(int id,User model)
        {

            try
            {
                if (id==model.UserId)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                    return responseMessage;
                }
                else
                {
                    HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return responseMessage;
                }
            }
            catch (Exception ex)
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return responseMessage;
            }

        }


        public HttpResponseMessage DeleteUser(int id)
        {
            User user = db.users.Find(id);
            if (user!=null)
            {
                db.users.Remove(user);
                db.SaveChanges();
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                return responseMessage;
            }
            else
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
                return responseMessage;
            }
        }
    }
}
