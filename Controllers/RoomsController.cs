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
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _repository;
        private readonly IMapper _mapper;

        public RoomsController(IRoom repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/Rooms
        [HttpGet]
        public ActionResult<IEnumerable<RoomReadDto>> GetAllRooms()
        {
            var roomsFromRepo = _repository.GetAllRooms();
            return Ok(_mapper.Map<IEnumerable<RoomReadDto>>(roomsFromRepo));
        }

        // GET api/Rooms/{id}
        [HttpGet("{id}", Name = "GetRoomByID")]
        public ActionResult<RoomReadDto> GetRoomByID(Guid id)
        {
            var roomFromRepo = _repository.GetRoomByID(id);
            if (roomFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RoomReadDto>(roomFromRepo));
        }

        // GET api/Rooms/GetBySystemConfigID/{id}
        [HttpGet("GetBySystemConfigID/{id}")]
        public ActionResult<IEnumerable<RoomReadDto>> GetRoomsBySystemConfigID(Guid id)
        {
            var roomsFromRepo = _repository.GetAllRoomsBySystemConfigID(id);
            if (roomsFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<RoomReadDto>>(roomsFromRepo));
        }

        // POST api/Rooms
        [HttpPost]
        public ActionResult<RoomReadDto> CreateRoom(RoomCreateDto roomCreateDto)
        {
            var roomFromModel = _mapper.Map<Room>(roomCreateDto);
            _repository.AddRoom(roomFromModel);
            _repository.SaveChanges();

            var roomReadDto = _mapper.Map<RoomReadDto>(roomFromModel);

            return CreatedAtRoute(nameof(GetRoomByID), new { ID = roomReadDto.ID }, roomReadDto);
        }

        // PUT api/Rooms/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateRoom(Guid id, RoomUpdateDto roomUpdateDto)
        {
            var roomFromRepo = _repository.GetRoomByID(id);
            if (roomFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(roomUpdateDto, roomFromRepo);

            _repository.UpdateRoom(roomFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/Rooms/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteRoom(Guid id)
        {
            var roomFromRepo = _repository.GetRoomByID(id);
            if (roomFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteRoom(roomFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}