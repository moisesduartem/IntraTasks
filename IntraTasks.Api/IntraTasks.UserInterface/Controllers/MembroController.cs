using IntraTasks.BusinessLogic.Repository;
using IntraTasks.DataAccess.Domain;
using IntraTasks.DataAccess.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IntraTasks.UserInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembroController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public MembroController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Membro>> Get()
        {
            var data = _uow.MembroRepository.Get().ToList();
            if (data.Count > 0)
            {
                return Ok(ResponseFactory.Successfully<IEnumerable<Membro>>(data));
            }

            return NotFound(ResponseFactory.NotFound<Membro>());
        }

        [HttpGet("{id}")]
        public ActionResult<Membro> Get([FromQuery] int id)
        {
            var membro = _uow.MembroRepository.GetById(membro => membro.Id == id);

            if (membro == null)
            {
                return NotFound(ResponseFactory.NotFound<Membro>());
            }

            return Ok(ResponseFactory.Successfully<Membro>(membro));
        }

        [HttpPost]
        public ActionResult Add([FromBody] Membro membro)
        {
            _uow.MembroRepository.Add(membro);
            _uow.Commit();

            return StatusCode(201, ResponseFactory.Created<Membro>(membro));
        }

        [HttpPut]
        public ActionResult Update([FromBody] Membro data)
        {
            var membro = _uow.MembroRepository.GetById(m => m.Id == data.Id);

            if (membro == null)
            {
                return NotFound(ResponseFactory.NotFound<Membro>());
            }

            data.CreatedAt = membro.CreatedAt;

            _uow.MembroRepository.Update(data);
            _uow.Commit();

            return Ok(ResponseFactory.Successfully<Membro>(data));
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var membro = _uow.MembroRepository.GetById(membro => membro.Id == id);

            if (membro == null)
            {
                return NotFound(ResponseFactory.NotFound<Membro>());
            }

            _uow.MembroRepository.Delete(membro);
            _uow.Commit();

            return Ok(ResponseFactory.Deleted<Membro>(membro));
        }

    }
}
