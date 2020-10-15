using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WolfPack.Data;
using WolfPack.Dtos;
using WolfPack.Models;

namespace WolfPack.Controllers
{
    //api/wolves
    [Route("api/wolves")]
    [ApiController]
    public class WolvesController : ControllerBase
    {
        private readonly IWolfPackRepository _repository;

        public IMapper _mapper { get; }

        public WolvesController(IWolfPackRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockWolfPackRepository _repository=new MockWolfPackRepository();
        
        //GET api/wolves
        [HttpGet]
        public ActionResult <IEnumerable<WolfReadDto>> GetAllWolves()
        {
            var wolves = _repository.GetWolves();
            return Ok(_mapper.Map<IEnumerable<WolfReadDto>>(wolves));
        }
        //GET api/wolves/{id}
        [HttpGet("{id}",Name = "GetWolfById")]
        public ActionResult <WolfReadDto> GetWolfById(int id)
        {
            var wolf = _repository.GetWolfById(id);
            if(wolf!=null)
            {
                return Ok(_mapper.Map<WolfReadDto>(wolf));
            }
            return NotFound();
        }

        //POST api/wolves
        [HttpPost]
        public ActionResult<WolfReadDto> CreateWolf(WolfCreateDto wolfCreateDto)
        {
            var wolfModel = _mapper.Map<Wolf>(wolfCreateDto);
            _repository.CreateWolf(wolfModel);
            _repository.SaveChanges();

            var wolfReadDto=_mapper.Map<WolfReadDto>(wolfModel);

            return CreatedAtRoute(nameof(GetWolfById), new {Id = wolfReadDto.Id},wolfReadDto);
        }

        //Put api/wolves/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateWolf(int id,WolfUpdateDto wolfUpdateDto)
        {
            var wolfModelFromRepo = _repository.GetWolfById(id);
            if(wolfModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(wolfUpdateDto,wolfModelFromRepo);

            _repository.UpdateWolf(wolfModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //PATCH api/wolves/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialWolfUpdate(int id, JsonPatchDocument<WolfUpdateDto> patchDoc)
        {
            var wolfModelFromRepo = _repository.GetWolfById(id);
            if(wolfModelFromRepo == null)
            {
                return NotFound();
            }

            var wolfToPatch= _mapper.Map<WolfUpdateDto>(wolfModelFromRepo);
            patchDoc.ApplyTo(wolfToPatch, ModelState);
            if(!TryValidateModel(wolfToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(wolfToPatch,wolfModelFromRepo);
            _repository.UpdateWolf(wolfModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //DELETE api/wolves/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteWolf(int id)
        {
            var wolfModelFromRepo = _repository.GetWolfById(id);
            if(wolfModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteWolf(wolfModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}