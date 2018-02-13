using MadBug.Data;
using MadBug.Data.Reposiories;
using MadBug.Domain;
using MadBugWebApi.Helpers;
using MadBugWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace MadBugWebApi.Controllers
{
    [Authorize]
    public class BugController : BaseApiController
    {
        /// <summary>
        ///  GET: api/Bug
        /// </summary>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(ICollection<BugApi>))]
        public IHttpActionResult Get()
        {
            using (var context = new DataContext())
            {
                BugRepository bugRepository = new BugRepository(context);
                var bugs = bugRepository.GetAll();
                var models = MapperHelper.Map<ICollection<BugApi>>(bugs);
                return Ok(models);
            }
        }

        // GET: api/Bug/5

        [ResponseType(typeof(BugApi))]
        public IHttpActionResult Get(int id)
        {
            using (var context = new DataContext())
            {
                BugRepository bugRepository = new BugRepository(context);
                var bug = bugRepository.Find(id);
                UserRepository userRepo = new UserRepository(context);
                bug.CreatedBy = userRepo.Find(CurrentUserId);
                var models = MapperHelper.Map<BugApi>(bug);
                return Ok(models);
            }
        }

        // POST: api/Bug

        [ResponseType(typeof(BugApi))]
        public IHttpActionResult Post([FromBody]CreateBugApi model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var context = new DataContext())
            {
                BugRepository bugRepository = new BugRepository(context);
                var entity = MapperHelper.Map<Bug>(model);
                entity.CreatedAt = DateTime.Now;
                entity.CreatedById = CurrentUserId;
                bugRepository.Insert(entity);
                context.SaveChanges();
                var bugApi = MapperHelper.Map<BugApi>(entity);
                return Ok(bugApi);
            }
        }

        // PUT: api/Bug/5
        public IHttpActionResult Put(int id, [FromBody]BugApi model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                using (var context = new DataContext())
                {
                    BugRepository bugRepository = new BugRepository(context);
                    var entity = MapperHelper.Map<Bug>(model);
                    entity.ModifiedAt = DateTime.Now;
                    entity.ModifiedById = CurrentUserId;
                    bugRepository.Update(entity);
                    context.SaveChanges();
                    var bugApi = MapperHelper.Map<BugApi>(entity);
                    return Ok(bugApi);
                }
            }
            catch(DbUpdateConcurrencyException ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Conflict, new { Message = "El registro ha sido modificado" }));
            }

        }
    }
}
