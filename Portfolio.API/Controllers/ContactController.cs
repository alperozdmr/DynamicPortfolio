using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Entity.concrete;
using Portfolio.Helper.Dtos;
using Portfolio.Service.Abstract;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService ContactService, IMapper mapper)
        {
            _contactService = ContactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetListAll();
            return Ok(_mapper.Map<List<ContactDto>>(values));
        }
        [HttpPost]
        public IActionResult AddContact(ContactDto var)
        {
            var value = _mapper.Map<Contact>(var);
            _contactService.TAdd(value);
            return Ok("İletişim kısmı başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok("İletişim alanı silindi");
        }
        [HttpPut]
        public IActionResult UpdateContact(ContactDto var)
        {
            var value = _mapper.Map<Contact>(var);
            _contactService.TUpdate(value);
            return Ok("İletişim alanı güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetByID(id);
            return Ok(_mapper.Map<ContactDto>(value));
        }
    }
}
