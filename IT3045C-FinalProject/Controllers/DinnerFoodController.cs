using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using IT3045C_FinalProject.Data;
using IT3045C_FinalProject.Models;

namespace IT3045C_FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DinnerFoodController : ControllerBase
    {
        private readonly ILogger<DinnerFoodController> _logger;
        private readonly MemberInfo _ctx;
        public DinnerFoodController(ILogger<DinnerFoodController> logger, MemberInfo ctx)
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
                return Ok(_ctx.Dinner.Take(5).ToList());

            var member = _ctx.Dinner.Find(id);
            if (member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Put))]
        public IActionResult Put(Dinner dinner)
        {
            if (dinner.Id == null || dinner.Id < 1)
                return BadRequest("Invalid member Id");

            var dbInfo = _ctx.Dinner.Find(dinner.Id);

            if (dbInfo == null)
                return NotFound();

            dbInfo.FullName = dinner.FullName;
            dbInfo.FavoriteDish = dinner.FavoriteDish;
            dbInfo.FavoriteSide = dinner.FavoriteSide;
            dbInfo.FavoriteJoint = dinner.FavoriteJoint;
            _ctx.Dinner.Update(dbInfo);
            var changes = _ctx.SaveChanges();

            if (changes > 0)
                return NoContent();


            return StatusCode(500, "Error occured on the server. Please try again in a few minutes.");
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Post))]
        public IActionResult Post(Dinner dinner)
        {
            if (string.IsNullOrEmpty(dinner.FullName))
            {
                return BadRequest("Must include a Full Name for the member.");
            }
            if (string.IsNullOrEmpty(dinner.FavoriteDish))
            {
                return BadRequest("Must include a Favorite Dinner Entree.");
            }
            if (string.IsNullOrEmpty(dinner.FavoriteSide))
            {
                return BadRequest("Must include a Favorite Dinner Side.");
            }
            if (string.IsNullOrEmpty(dinner.FavoriteJoint))
            {
                return BadRequest("Must include Your Favorite Restauraunt for Dinner.");
            }

            dinner.Id = null;
            _ctx.Dinner.Add(dinner);
            var changes = _ctx.SaveChanges();
            if (changes > 0)
                return NoContent();

            return StatusCode(500, "Please try again later");
        }

        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Delete))]
        public IActionResult Delete(int? id, Dinner dinner)
        {
            if (id == null || id < 1)
                return BadRequest("Invalid member Id");

            var member = _ctx.Dinner.Find(id);
            if (member == null)
                return NotFound();

            _ctx.Dinner.Remove(member);
            var changes = _ctx.SaveChanges();

            if (changes > 0)
                return NoContent();

            return StatusCode(500, "Please try again later");
        }

    }
}