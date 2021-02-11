using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserAccess
{
    public class Repository
    {
        int x;
        public roles Roles()
        {
            using (UserContext db = new UserContext())
            {
                roles r = new roles();
                if (db.role.Where(rol => rol.role != null).Count() == 0)
                {
                    r.role = "user";
                    db.role.Add(r);
                    db.SaveChanges();
                    r = db.role.SingleOrDefault();
                }
                else
                {
                    r = db.role.SingleOrDefault();
                }
                return r;
            }
        }

        public int addUser(users u, int roleId)
        {
            using (UserContext db = new UserContext())
            {
                if (db.user.Where(usrs => usrs.uname == u.uname).Count() > 0)
                {
                    return 0;
                }
                else
                {
                    u.roleid = roleId;
                    db.user.Add(u);
                    x = db.SaveChanges();
                    return x;
                }
            }
        }
        public int loginUser(users u)
        {
            using (UserContext db = new UserContext())
            {
                if (db.user.Where(usrs => usrs.uname == u.uname&usrs.password==u.password).Count() > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
