using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook_Api.Dal;
using PhoneBook_Models;

namespace PhoneBook_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly PhoneBookContext _context;

        public ContactController(PhoneBookContext context)
        {
            _context = context;
        }

        // GET: api/Contact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            return await _context.Contacts.ToListAsync();
        }

        // GET: api/Contact/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // POST: api/Contact
        [HttpPost]
        public async Task<ActionResult<Contact>> Post([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = contact.ContactId }, contact);
        }

        // PUT: api/Contact/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> Put(int id, [FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (id != contact.ContactId)
                return BadRequest();

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(contact);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(c => c.ContactId == id);
        }
    }
}
