using System;
using System.Collections.Generic;
using AutoMapper;
using Hotel.API.Data;
using Hotel.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomFeaturesController : ControllerBase
    {
        private readonly IRoomFeature _repository;
        private readonly IMapper _mapper;

        public RoomFeaturesController(IRoomFeature repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/Rooms
        [HttpGet]
        public ActionResult<IEnumerable<RoomFeatureReadDto>> GetAllRoomsFeatures()
        {
            var roomFeaturesFromRepo = _repository.GetAllRoomFeatures();
            return Ok(_mapper.Map<IEnumerable<RoomFeatureReadDto>>(roomFeaturesFromRepo));
        }

        // GET api/Rooms/{id}
        [HttpGet("{id}", Name = "GetRoomFeatureByID")]
        public ActionResult<RoomFeatureReadDto> GetRoomFeatureByID(Guid id)
        {
            var roomFeatureFromRepo = _repository.GetRoomFeatureByID(id);
            if (roomFeatureFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RoomFeatureReadDto>(roomFeatureFromRepo));
        }

        // GET api/Rooms/GetByRoomID/{id}
        [HttpGet("GetByRoomID/{id}")]
        public ActionResult<IEnumerable<RoomFeatureReadDto>> GetRoomFeaturesByRoomID(Guid id)
        {
            var roomFeaturesFromRepo = _repository.GetRoomFeaturesByRoomID(id);
            if (roomFeaturesFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<RoomFeatureReadDto>>(roomFeaturesFromRepo));
        }

        // POST api/Rooms
        [HttpPost]
        public ActionResult<RoomFeatureReadDto> CreateRoomFeature(RoomFeatureCreateDto RoomFeatureCreateDto)
        {
            var RoomFeatureFromModel = _mapper.Map<RoomFeature>(RoomFeatureCreateDto);
            _repository.AddRoomFeature(RoomFeatureFromModel);
            _repository.SaveChanges();

            var RoomFeatureReadDto = _mapper.Map<RoomFeatureReadDto>(RoomFeatureFromModel);

            return CreatedAtRoute(nameof(GetRoomFeatureByID), new { ID = RoomFeatureReadDto.ID }, RoomFeatureReadDto);
        }

        // PUT api/Rooms/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateRoomFeature(Guid id, RoomFeatureUpdateDto RoomFeatureUpdateDto)
        {
            var roomFeatureFromRepo = _repository.GetRoomFeatureByID(id);
            if (roomFeatureFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(RoomFeatureUpdateDto, roomFeatureFromRepo);

            _repository.UpdateRoomFeature(roomFeatureFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/Rooms/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteRoomFeature(Guid id)
        {
            var roomFromRepo = _repository.GetRoomFeatureByID(id);
            if (roomFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteRoomFeature(roomFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}