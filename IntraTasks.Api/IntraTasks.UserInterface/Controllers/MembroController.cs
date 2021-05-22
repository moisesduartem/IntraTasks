using IntraTasks.BusinessLogic.Repository;
using IntraTasks.DataAccess.Domain;
using Microsoft.AspNet.OData.Routing;

namespace IntraTasks.UserInterface.Controllers
{
    [ODataRoutePrefix("Membro")]
    public class MembroController : GenericController<Membro>
    {
        public MembroController(IUnitOfWork uow) : base(uow, uow.MembroRepository)
        { }
    }
}
