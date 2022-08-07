using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using IT3045C_FinalProject.Data;
using IT3045C_FinalProject.Models;

namespace IT3045C_FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HobbyController : ControllerBase
    {
        private readonly ILogger<HobbyController> _logger;
        private readonly MemberInfo _ctx;
        public HobbyController(ILogger<HobbyController> logger, MemberInfo ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Get))]
        public IActionResult Get(int? id)
        {
            if (id == null || id < 1)
                return Ok(_ctx.Hobby.Take(5).ToList());

            var member = _ctx.Hobby.Find(id);
            if (member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Put))]
        public IActionResult Put(Hobby hobby)
        {
            if (hobby.Id == null || hobby.Id < 1)
                return BadRequest("Invalid member Id");

            var dbInfo = _ctx.Hobby.Find(hobby.Id);

            if (dbInfo == null)
                return NotFound();

            dbInfo.FullName = hobby.FullName;
            dbInfo.FavoriteHobby = hobby.FavoriteHobby;
            dbInfo.HowItStarted = hobby.HowItStarted;
            dbInfo.WhyItStarted = hobby.WhyItStarted;
            _ctx.Hobby.Update(dbInfo);
            var changes = _ctx.SaveChanges();

            if (changes > 0)
                return NoContent();


            return StatusCode(500, "Error occured on the server. Please try again in a few minutes.");
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Post))]
        public IActionResult Post(Hobby hobby)
        {
            if (string.IsNullOrEmpty(hobby.FullName))
            {
                return BadRequest("Must include a Full Name for the member.");
            }
            if (string.IsNullOrEmpty(hobby.FavoriteHobby))
            {
                return BadRequest("Must include a Favorite Hobby.");
            }
            if (string.IsNullOrEmpty(hobby.HowItStarted))
            {
                return BadRequest("Must include how you started this Hobby.");
            }
            if (string.IsNullOrEmpty(hobby.WhyItStarted))
            {
                return BadRequest("Must include a why you started this Hobby.");
            }

            hobby.Id = null;
            _ctx.Hobby.Add(hobby);
            var changes = _ctx.SaveChanges();
            if (changes > 0)
                return NoContent();

            return StatusCode(500, "Please try again later");
        }

        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Delete))]
        public IActionResult Delete(int? id, Hobby hobby)
        {
            if (id == null || id < 1)
                return BadRequest("Invalid member Id");

            var member = _ctx.Hobby.Find(id);
            if (member == null)
                return NotFound();

            _ctx.Hobby.Remove(member);
            var changes = _ctx.SaveChanges();

            if (changes > 0)
                return NoContent();

            return StatusCode(500, "Please try again later");
        }

    }
}