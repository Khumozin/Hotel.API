using System;
using System.Collections.Generic;
using AutoMapper;
using Hotel.API.Data;
using Hotel.API.Dtos;
using Hotel.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmail _repository;
        private readonly IMapper _mapper;

        public EmailsController(IEmail repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/emails/GetByConfigID/{id}
        [HttpGet("GetByConfigID/{id}")]
        public ActionResult<IEnumerable<EmailReadDto>> GetAllEmailsBySystemConfigID(Guid id)
        {
            var emailsFromRepo = _repository.GetAllEmailsByConfigID(id);
            if (emailsFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EmailReadDto>(emailsFromRepo));
        }

        // GET api/emails/{id}
        [HttpGet("{id}", Name = "GetEmaillByID")]
        public ActionResult<EmailReadDto> GetEmaillByID(Guid id)
        {
            var emailFromRepo = _repository.GetEmailByID(id);
            if (emailFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EmailReadDto>(emailFromRepo));
        }

        // POST api/emails
        [HttpPost]
        public ActionResult<EmailReadDto> CreateEmail(EmailCreateDto emailCreateDto)
        {
            var emailFromModel = _mapper.Map<Email>(emailCreateDto);

            _repository.AddEmail(emailFromModel);
            _repository.SaveChanges();

            var emailReadDto = _mapper.Map<EmailReadDto>(emailFromModel);
            return CreatedAtRoute(nameof(GetEmaillByID), new { ID = emailReadDto.ID }, emailReadDto);
        }

        // PUT api/emails/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEmail(Guid id, EmailUpdateDto emailUpdateDto)
        {
            var emailFromRepo = _repository.GetEmailByID(id);
            if (emailFromRepo == null)
            {
                return NotFound();
            }

            emailUpdateDto.DateReplied = DateTime.Now.ToString();

            _mapper.Map(emailUpdateDto, emailFromRepo);

            _repository.UpdateEmail(emailFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }

        // DELETE api/emails/{id}
        [HttpDelete]
        public ActionResult DeleteEmail(Guid id)
        {
            var emailFromRepo = _repository.GetEmailByID(id);
            if (emailFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteEmail(emailFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}