using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WolfPack.Data;
using WolfPack.Dtos;
using WolfPack.Models;

namespace WolfPack.Controllers
{
    //api/packs
    [Route("api/packs")]
    [ApiController]
    public class PacksController : ControllerBase
    {
        private readonly IWolfPackRepository _repository;

        public IMapper _mapper { get; }

        public PacksController(IWolfPackRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/wolves
        [HttpGet]
        public ActionResult <IEnumerable<PackReadDto>> GetAllPacks()
        {
            var packs = _repository.GetPacks();
            return Ok(_mapper.Map<IEnumerable<PackReadDto>>(packs));
        }
        //GET api/wolves/{id}
        [HttpGet("{id}",Name = "GetPackById")]
        public ActionResult <PackReadDto> GetPackById(int id)
        {
            var pack = _repository.GetPackById(id);
            if(pack!=null)
            {
                return Ok(_mapper.Map<PackReadDto>(pack));
            }
            return NotFound();
        }
        public ActionResult<PackReadDto> CreatePack(PackCreateDto packCreateDto)
        {
            var packModel = _mapper.Map<Pack>(packCreateDto);
            _repository.CreatePack(packModel);
            _repository.SaveChanges();

            var packReadDto=_mapper.Map<PackReadDto>(packModel);

            return CreatedAtRoute(nameof(GetPackById), new {Id = packReadDto.Id},packReadDto);
        }
        //Put api/packs/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePack(int id,PackUpdateDto packUpdateDto)
        {
            var packModelFromRepo = _repository.GetPackById(id);
            if(packModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(packUpdateDto,packModelFromRepo);

            _repository.UpdatePack(packModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
        //PATCH api/packs/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialPackUpdate(int id, JsonPatchDocument<PackUpdateDto> patchDoc)
        {
            var packModelFromRepo = _repository.GetPackById(id);
            if(packModelFromRepo == null)
            {
                return NotFound();
            }

            var packToPatch= _mapper.Map<PackUpdateDto>(packModelFromRepo);
            patchDoc.ApplyTo(packToPatch, ModelState);
            if(!TryValidateModel(packToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(packToPatch,packModelFromRepo);
            _repository.UpdatePack(packModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
        //DELETE api/packs/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePack(int id)
        {
            var packModelFromRepo = _repository.GetPackById(id);
            if(packModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeletePack(packModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}