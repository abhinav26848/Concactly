using Concactly.Data;
using Concactly.Models;
using Concactly.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Concactly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactlyDbContext dbcontext;
        public ContactsController(ContactlyDbContext dbContext)
        {
            this.dbcontext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllContacts() 
        {
            var contacts= dbcontext.Contacts.ToList();
            return Ok(contacts);
        }
        [HttpPost]
        public IActionResult AddContact(AddContactRequestDTO request)
        {
            var domainModelContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Favorite = request.Favorite,
            };
            dbcontext.Contacts.Add(domainModelContact);
            dbcontext.SaveChanges();
            return Ok(domainModelContact);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact(Guid id)
        {
            var contact = dbcontext.Contacts.Find(id);
            if (contact is not null)
            {
                dbcontext.Contacts.Remove(contact);
                dbcontext.SaveChanges();
            }
            return Ok();
        }
    }
}
