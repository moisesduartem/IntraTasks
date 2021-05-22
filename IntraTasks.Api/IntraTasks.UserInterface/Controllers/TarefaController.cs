using IntraTasks.BusinessLogic.Repository;
using IntraTasks.DataAccess.Domain;
using Microsoft.AspNetCore.Mvc;

namespace IntraTasks.UserInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : GenericController<Tarefa>
    {
        public TarefaController(IUnitOfWork uow) : base(uow, uow.TarefaRepository)
        { }
    }
}
