﻿using MVC5RealWorld.Models.DB;
using MVC5RealWorld.Models.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC5RealWorld.Security
{
    public class AuthorizeRoleAttribute:AuthorizeAttribute
    {
        private readonly string[] userAssignedRoles;

        public AuthorizeRoleAttribute( params string[] roles)
        {
            this.userAssignedRoles = roles;
        }

        // ponto de entrada para a validação, retorna se um usuario pode acessar uma pagina ou nao
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            using (DemoDBEntities db = new DemoDBEntities())
            {
                UserManager UM = new UserManager();
                foreach (var roles in userAssignedRoles)
                {
                    authorize = UM.IsUserInRole(httpContext.User.Identity.Name, roles);
                    if (authorize)
                        return authorize;
                }
            }
            return authorize;            
        }

        // redireciona usuarios nao autorizados a uma determinada pagina
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Home/UnAuthorized");
        }

    }
}
