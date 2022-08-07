using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using IT3045C_FinalProject.Models;
using IT3045C_FinalProject.Data;

namespace IT3045C_FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamMemberController : ControllerBase
    {
        private readonly ILogger<TeamMemberController> _logger;
        private readonly MemberInfo _ctx;

        public TeamMemberController(ILogger<TeamMemberController> logger, MemberInfo ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Get))]
        public IActionResult Get(int? id)
        {
            //return Ok(_ctx.Member.ToList());

            if (id == null || id < 1)
                return Ok(_ctx.Member.Take(5).ToList());

            var member = _ctx.Member.Find(id);
            if (member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Put))]
        public IActionResult Put(Member information)
        {
            if (information.ID == null || information.ID < 1)
                return BadRequest("Invalid member Id");

            var dbInfo = _ctx.Member.Find(information.ID);
            if (dbInfo == null)
                return NotFound();

            dbInfo.FullName = information.FullName;
            dbInfo.Program = information.Program;
            dbInfo.Year = information.Year;
            dbInfo.DOB = information.DOB;
            _ctx.Member.Update(dbInfo);
            var changes = _ctx.SaveChanges();

            if (changes > 0)
                return NoContent();


            return StatusCode(500, "Error occured on the server. Please try again in a few minutes.");
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Post))]
        public IActionResult Post(Member information)
        {
            if (string.IsNullOrEmpty(information.FullName))
            {
                return BadRequest("Must include a Full Name for the member.");
            }
            information.ID = null;
            _ctx.Member.Add(information);
            var changes = _ctx.SaveChanges();
            if (changes > 0)
                return NoContent();

            return StatusCode(500, "Please try again later");
        }

        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Delete))]
        public IActionResult Delete(int? id, Member information)
        {
            if (id == null || id < 1)
                return BadRequest("Invalid member Id");

            //var dbInfo = _ctx.Member.Find(information.ID);
            //if (dbInfo == null)
            //return NotFound();

            var member = _ctx.Member.Find(id);
            if (member == null)
                return NotFound();

            _ctx.Member.Remove(member);
            var changes = _ctx.SaveChanges();
            if (changes > 0)
                return NoContent();

            return StatusCode(500, "Please try again later");
        }

    }
}