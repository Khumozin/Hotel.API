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
    public class RoomImagesController : ControllerBase
    {
        private readonly IRoomImage _repository;
        private readonly IMapper _mapper;

        public RoomImagesController(IRoomImage repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/Rooms
        [HttpGet]
        public ActionResult<IEnumerable<RoomImageReadDto>> GetAllRoomsImages()
        {
            var roomImagesFromRepo = _repository.GetAllRoomImages();
            return Ok(_mapper.Map<IEnumerable<RoomImageReadDto>>(roomImagesFromRepo));
        }

        // GET api/Rooms/{id}
        [HttpGet("{id}", Name = "GetRoomImageByID")]
        public ActionResult<RoomImageReadDto> GetRoomImageByID(Guid id)
        {
            var roomImageFromRepo = _repository.GetRoomImagesByID(id);
            if (roomImageFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RoomImageReadDto>(roomImageFromRepo));
        }

        // GET api/Rooms/GetByRoomID/{id}
        [HttpGet("GetByRoomID/{id}")]
        public ActionResult<IEnumerable<RoomImageReadDto>> GetRoomImagesByRoomID(Guid id)
        {
            var roomImagesFromRepo = _repository.GetRoomImagesByRoomID(id);
            if (roomImagesFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<RoomImageReadDto>>(roomImagesFromRepo));
        }

        // POST api/Rooms
        [HttpPost]
        public ActionResult<RoomImageReadDto> CreateRoomImage(RoomImageCreateDto roomImageCreateDto)
        {
            var roomImageFromModel = _mapper.Map<RoomImage>(roomImageCreateDto);
            _repository.AddRoomImage(roomImageFromModel);
            _repository.SaveChanges();

            var RoomImageReadDto = _mapper.Map<RoomImageReadDto>(roomImageFromModel);

            return CreatedAtRoute(nameof(GetRoomImageByID), new { ID = RoomImageReadDto.ID }, RoomImageReadDto);
        }

        // PUT api/Rooms/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateRoomImage(Guid id, RoomImageUpdateDto roomImageUpdateDto)
        {
            var roomImageFromRepo = _repository.GetRoomImagesByID(id);
            if (roomImageFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(roomImageUpdateDto, roomImageFromRepo);

            _repository.UpdateRoomImage(roomImageFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/Rooms/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteRoomImage(Guid id)
        {
            var roomFromRepo = _repository.GetRoomImagesByID(id);
            if (roomFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteRoomImage(roomFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}