using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserAccess;

namespace simple_login_register.Controllers
{
    public class DefaultController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage RegisterUser(users u)
        {
            try
            {
                using (UserContext db = new UserContext())
                {
                    if (u.uname != null && u.password != null)
                    {
                        if (db.role.Count() == 0)
                        {
                            roles r = new roles();
                            r.role = "user";
                            db.role.Add(r);
                            db.SaveChanges();
                            var rolee = db.role.SingleOrDefault();
                            u.roleid = rolee.id;
                            db.user.Add(u);
                            db.SaveChanges();
                        }
                        else
                        {
                            users usr = new users();
                            var rolee = db.role.SingleOrDefault();
                            u.roleid = rolee.id;
                            db.user.Add(u);
                            db.SaveChanges();
                        }
                        return Request.CreateResponse(HttpStatusCode.OK, "user registered");
                    }
                    else
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "enter username password");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage LoginUser(users u)
        {
            try
            {
                if (u.uname!=""  && u.password !="")
                {
                    using (UserContext DB = new UserContext())
                    {
                        var users = DB.user.Where(usr => usr.password == u.password & usr.uname == u.uname).SingleOrDefault();
                        if (users != null)
                        {
                            var roles = DB.role.Where(rol => rol.id == users.roleid).SingleOrDefault();
                            string msg = "your role is " + roles.role;
                            return Request.CreateResponse(HttpStatusCode.OK, msg);
                        }
                        else
                            return Request.CreateResponse(HttpStatusCode.Forbidden, "wrong username password");
                    }

                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "enter the username password");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
