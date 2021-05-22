using IntraTasks.BusinessLogic.Repository;
using IntraTasks.DataAccess.Domain;
using Microsoft.AspNet.OData.Routing;

namespace IntraTasks.UserInterface.Controllers
{
    [ODataRoutePrefix("Tarefa")]
    public class TarefaController : GenericController<Tarefa>
    {
        public TarefaController(IUnitOfWork uow) : base(uow, uow.TarefaRepository)
        { }
    }
}
