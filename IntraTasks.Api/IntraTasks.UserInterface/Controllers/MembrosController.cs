using IntraTasks.BusinessLogic.Repository;
using IntraTasks.DataAccess.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IntraTasks.UserInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembrosController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public MembrosController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Membro>> Get()
        {
            return _uow.MembroRepository.Get().ToList();
        }

        [HttpGet("{id}", Name = "GetMembroById")]
        public ActionResult<Membro> Get([FromQuery] int id)
        {
            var membro = _uow.MembroRepository.GetById(membro => membro.Id == id);

            if (membro == null)
            {
                return NotFound();
            }

            return membro;
        }

        [HttpPost]
        public ActionResult Add([FromBody] Membro membro)
        {
            _uow.MembroRepository.Add(membro);
            _uow.Commit();

            return new CreatedAtRouteResult("GetMembroById", new { id = membro.Id }, membro);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Membro membro)
        {
            var item = _uow.MembroRepository.GetById(m => m.Id == membro.Id);
            
            if (item == null)
            {
                return NotFound();
            }

            _uow.MembroRepository.Update(membro);
            _uow.Commit();

            return Ok();
        }
    }
}
