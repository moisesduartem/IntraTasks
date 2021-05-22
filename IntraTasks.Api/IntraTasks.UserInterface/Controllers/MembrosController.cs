using IntraTasks.BusinessLogic.Repository;
using IntraTasks.DataAccess.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
