using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Hotel.API.Data;
using Hotel.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SystemConfigsController : ControllerBase
    {
        private readonly ISystemConfig _repository;
        private readonly IMapper _mapper;

        public SystemConfigsController(ISystemConfig repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/systemconfigs
        [HttpGet]
        public ActionResult<IEnumerable<SystemConfigReadDto>> GetAllSystemConfigs()
        {
            var systemConfigs = _repository.GetAllSystemConfigs();

            return Ok(_mapper.Map<IEnumerable<SystemConfigReadDto>>(systemConfigs));
        }

        // GET api/systemconfigs/{id}
        [HttpGet("{id}", Name = "GetSystemConfigByID")]
        public ActionResult<SystemConfigReadDto> GetSystemConfigByID(Guid id)
        {
            var systemConfig = _repository.GetSystemConfigByID(id);

            if (systemConfig == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SystemConfigReadDto>(systemConfig));
        }

        // POST api/systemconfigs
        [HttpPost]
        public ActionResult<SystemConfigReadDto> CreateSystemConfig(SystemConfigCreateDto systemConfig)
        {
            var systemConfigModel = _mapper.Map<SystemConfig>(systemConfig);

            _repository.CreateSystemConfig(systemConfigModel);
            _repository.SaveChanges();

            var systemConfigReadDto = _mapper.Map<SystemConfigReadDto>(systemConfigModel);

            return CreatedAtRoute(nameof(GetSystemConfigByID), new { ID = systemConfigReadDto.ID }, systemConfigReadDto);
        }

        // PUT api/systemconfigs/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSystemConfig(Guid id, SystemConfigUpdateDto systemConfig)
        {
            var systemConfigFromRepo = _repository.GetSystemConfigByID(id);

            if (systemConfigFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(systemConfig, systemConfigFromRepo);

            _repository.UpdateSystemConfig(systemConfigFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/systemconfigs{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSystemConfig(Guid id)
        {
            var systemConfigFromRepo = _repository.GetSystemConfigByID(id);

            if (systemConfigFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteSystemConfig(systemConfigFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}