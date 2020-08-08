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
    public class HotelFeaturesController : ControllerBase
    {
        private readonly IHotelFeature _repository;
        private readonly IMapper _mapper;

        // Dependency Injection
        public HotelFeaturesController(IHotelFeature repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/HotelFeature
        [HttpGet]
        public ActionResult<IEnumerable<HotelFeatureReadDto>> GetAllHotelFeatures()
        {
            var hotelFeaturesFromRepo = _repository.GetAllHotelFeatures();

            return Ok(_mapper.Map<IEnumerable<HotelFeatureReadDto>>(hotelFeaturesFromRepo));
        }

        // GET api/HotelFeature/{id}
        [HttpGet("{id}", Name = "GetHotelFeatureByID")]
        public ActionResult<HotelFeatureReadDto> GetHotelFeatureByID(Guid id)
        {
            var hotelFeatureFromRepo = _repository.GetHotelFeatureID(id);

            return Ok(_mapper.Map<HotelFeatureReadDto>(hotelFeatureFromRepo));
        }

        [HttpGet("GetBySystemConfigID/{id}")]
        public ActionResult<IEnumerable<HotelFeatureReadDto>> GetHotelFeaturesBySystemConfigID(Guid id)
        {
            var hotelFeatureFromRepo = _repository.GetAllHotelFeaturesByConfigID(id);

            return Ok(_mapper.Map<IEnumerable<HotelFeatureReadDto>>(hotelFeatureFromRepo));
        }

        // POST api/HotelFeature
        [HttpPost]
        public ActionResult<HotelFeatureReadDto> CreateHotelFeature(HotelFeatureCreateDto hotelFeatureCreateDto)
        {
            var hotelFeatureModel = _mapper.Map<HotelFeature>(hotelFeatureCreateDto);

            _repository.AddHotelFeature(hotelFeatureModel);
            _repository.SaveChanges();

            var hotelFeatureReadDto = _mapper.Map<HotelFeatureReadDto>(hotelFeatureModel);

            return CreatedAtRoute(nameof(GetHotelFeatureByID), new { ID = hotelFeatureReadDto.ID }, hotelFeatureReadDto);
        }

        // PUT api/HotelFeature/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateHotelFeature(Guid id, HotelFeatureUpdateDto hotelFeatureUpdateDto)
        {
            var hotelFeatureFromRepo = _repository.GetHotelFeatureID(id);
            if (hotelFeatureFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(hotelFeatureUpdateDto, hotelFeatureFromRepo);

            _repository.UpdateHotelFeature(hotelFeatureFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/HotelFeature/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteHotelFeature(Guid id)
        {
            var hotelFeatureFromRepo = _repository.GetHotelFeatureID(id);
            if (hotelFeatureFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteHotelFeature(hotelFeatureFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}