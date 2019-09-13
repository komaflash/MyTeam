using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTeam.Contracts;
using MyTeam.Entities;

namespace MyMember.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IUnitOfWork context;

        public MembersController(IUnitOfWork context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Member>> Get()
        {
            return Ok(context.Members.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Member> Get(int id)
        {
            return Ok(context.Members.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string memberName)
        {
            if (string.IsNullOrWhiteSpace(memberName))
                return BadRequest();

            context.Members.Add(new Member { Name = memberName });
            context.SaveChanges();
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string memberName)
        {
            var member = context.Members.Get(id);

            if (member == null)
                return NotFound();

            member.Name = memberName;

            context.Members.Update(member);
            context.SaveChanges();
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.Members.Delete(context.Members.Get(id));
            context.SaveChanges();
        }
    }
}
