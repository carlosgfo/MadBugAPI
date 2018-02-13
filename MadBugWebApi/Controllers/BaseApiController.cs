using MadBugWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace MadBugWebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }

        protected ApplicationUser CurrentUser
        {
            get
            {
                //get User from session
                var claims = User as ClaimsPrincipal;
                var claimsThatHasId = claims.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier);
                if (claimsThatHasId.Count() > 0)
                {
                    var userId = claimsThatHasId.SingleOrDefault().Value;
                    //query in UserManager
                    var user = UserManager.FindById(userId);
                    return user;
                }
                return null;
            }
        }
        protected string CurrentUserId
        {
            get
            {
                return CurrentUser != null ? CurrentUser.Id : null;
            }
        }
    }

}