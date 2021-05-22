﻿using IntraTasks.BusinessLogic.Repository;
using IntraTasks.DataAccess.Domain;
using Microsoft.AspNetCore.Mvc;

namespace IntraTasks.UserInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembroController : GenericController<Membro>
    {
        public MembroController(IUnitOfWork uow) : base(uow, uow.MembroRepository)
        { }
    }
}
