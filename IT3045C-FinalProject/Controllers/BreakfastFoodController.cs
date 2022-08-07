using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using IT3045C_FinalProject.Data;
using IT3045C_FinalProject.Models;

namespace IT3045C_FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakfastFoodController : ControllerBase
    {
        private readonly ILogger<BreakfastFoodController> _logger;
        private readonly MemberInfo _ctx;
        public BreakfastFoodController(ILogger<BreakfastFoodController> logger, MemberInfo ctx)
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
                return Ok(_ctx.Breakfast.Take(5).ToList());

            var member = _ctx.Breakfast.Find(id);
            if (member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Put))]
        public IActionResult Put(Breakfast breakfast)
        {
            if (breakfast.Id == null || breakfast.Id < 1)
                return BadRequest("Invalid member Id");

            var dbInfo = _ctx.Breakfast.Find(breakfast.Id);

            if (dbInfo == null)
                return NotFound();

            dbInfo.FullName = breakfast.FullName;
            dbInfo.FavoriteBreakfastFood = breakfast.FavoriteBreakfastFood;
            dbInfo.FavoriteSide = breakfast.FavoriteSide;
            dbInfo.FavoriteBreakfastTime = breakfast.FavoriteBreakfastTime;
            _ctx.Breakfast.Update(dbInfo);
            var changes = _ctx.SaveChanges();

            if (changes > 0)
                return NoContent();


            return StatusCode(500, "Error occured on the server. Please try again in a few minutes.");
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Post))]
        public IActionResult Post(Breakfast breakfast)
        {
            if (string.IsNullOrEmpty(breakfast.FullName))
            {
                return BadRequest("Must include a Full Name for the member.");
            }
            if (string.IsNullOrEmpty(breakfast.FavoriteBreakfastFood))
            {
                return BadRequest("Must include a Favorite Breakfast Food.");
            }
            if (string.IsNullOrEmpty(breakfast.FavoriteSide))
            {
                return BadRequest("Must include a Favorite Breakfast Side.");
            }
            if (string.IsNullOrEmpty(breakfast.FavoriteBreakfastTime))
            {
                return BadRequest("Must include Your Favorite Meal Time For Breakfast.");
            }

            breakfast.Id = null;
            _ctx.Breakfast.Add(breakfast);
            var changes = _ctx.SaveChanges();
            if (changes > 0)
                return NoContent();

            return StatusCode(500, "Please try again later");
        }

        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions),
              nameof(DefaultApiConventions.Delete))]
        public IActionResult Delete(int? id, Breakfast breakfast)
        {
            if (id == null || id < 1)
                return BadRequest("Invalid member Id");

            var member = _ctx.Breakfast.Find(id);
            if (member == null)
                return NotFound();

            _ctx.Breakfast.Remove(member);
            var changes = _ctx.SaveChanges();

            if (changes > 0)
                return NoContent();

            return StatusCode(500, "Please try again later");
        }

    }
}