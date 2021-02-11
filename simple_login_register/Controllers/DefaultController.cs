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
        Repository repo = new Repository();

        [HttpPost]
        public HttpResponseMessage RegisterUser(users u)
        {
            try
            {
                    if ( string.IsNullOrWhiteSpace(u.uname)==false && string.IsNullOrWhiteSpace(u.password) == false)
                    {

                        roles r = repo.Roles();
                        int i = repo.addUser(u, r.id);

                    if (i > 0)                   // 1 means new user registered
                    {
                            return Request.CreateResponse(HttpStatusCode.OK, 1);
                        }
                    else                            // 0 means user already register 
                    {
                            return Request.CreateResponse(HttpStatusCode.Forbidden, 0);
                        }

                    }

                else                                //3 means user password fields should not be empty
                    return Request.CreateResponse(HttpStatusCode.Forbidden, 3);
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
                if (string.IsNullOrWhiteSpace(u.uname)==false  && string.IsNullOrWhiteSpace(u.password)==false)

                {
                    using (UserContext DB = new UserContext())
                    {

                        if (repo.loginUser(u)>0)
                        {
                            //var roles = repo.Roles();
                            //string msg = "your role is " + roles.role;
                            return Request.CreateResponse(HttpStatusCode.OK,1);
                        }
                        else          //2 means username password didnt mathced
                            return Request.CreateResponse(HttpStatusCode.Forbidden,0);
                    }

                } 
                else                 //0 means enter username password
                    return Request.CreateResponse(HttpStatusCode.BadRequest,2);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
