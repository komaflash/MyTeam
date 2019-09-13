using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTeam.Contracts;
using MyTeam.Entities;

namespace MyTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IUnitOfWork context;

        public TeamsController(IUnitOfWork context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Team>> Get()
        {
            return Ok(context.Teams.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Team> Get(int id)
        {
            return Ok(context.Teams.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string teamName)
        {
            if (string.IsNullOrWhiteSpace(teamName))
                return BadRequest();

            context.Teams.Add(new Team { Name = teamName });
            context.SaveChanges();
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string teamName)
        {
            var team = context.Teams.Get(id);

            if (team == null)
                return NotFound();

            team.Name = teamName;

            context.Teams.Update(team);
            context.SaveChanges();
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.Teams.Delete(context.Teams.Get(id));
            context.SaveChanges();
        }
    }
}
