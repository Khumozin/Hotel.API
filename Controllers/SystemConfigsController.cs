using System;
using System.Collections;
using System.Collections.Generic;
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

        public SystemConfigsController(ISystemConfig repository)
        {
            _repository = repository;
        }

        // GET api/systemconfigs
        [HttpGet]
        public ActionResult<IEnumerable<SystemConfig>> GetAllSystemConfigs()
        {
            var systemConfigs = _repository.GetAllSystemConfigs();

            return Ok(systemConfigs);
        }

        // GET api/systemconfigs/{id}
        [HttpGet("{id}", Name = "GetSystemConfigByID")]
        public ActionResult<SystemConfig> GetSystemConfigByID(Guid id)
        {
            var systemConfig = _repository.GetSystemConfigByID(id);

            if (systemConfig == null)
            {
                return NotFound();
            }

            return Ok(systemConfig);
        }

        // POST api/systemconfigs
        [HttpPost]
        public ActionResult<SystemConfig> CreateSystemConfig(SystemConfig systemConfig)
        {
            _repository.CreateSystemConfig(systemConfig);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetSystemConfigByID), new { ID = systemConfig.ID }, systemConfig);
        }

        // PUT api/systemconfigs/{id}
        [HttpPut]
        public ActionResult UpdateSystemConfig(Guid id, SystemConfig systemConfig)
        {
            var systemConfigFromRepo = _repository.GetSystemConfigByID(id);

            if (systemConfigFromRepo == null)
            {
                return NotFound();
            }

            _repository.UpdateSystemConfig(systemConfig);
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