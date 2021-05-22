using IntraTasks.BusinessLogic.Repository;
using IntraTasks.DataAccess.Domain;
using IntraTasks.DataAccess.Repository;
using IntraTasks.DataAccess.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IntraTasks.UserInterface.Controllers
{
    public class GenericController<T> : ControllerBase where T : BaseEntity
    {
        protected readonly IUnitOfWork _uow;
        private readonly IRepository<T> _mainRepository;

        public GenericController(IUnitOfWork uow, IRepository<T> repository)
        {
            _uow = uow;
            _mainRepository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<T>> Get()
        {
            var data = _mainRepository.Get().ToList();
            if (data.Count > 0)
            {
                return Ok(ResponseFactory.Successfully<IEnumerable<T>>(data));
            }

            return NotFound(ResponseFactory.NotFound<T>());
        }

        [HttpGet("{id}")]
        public ActionResult<T> Get(int id)
        {
            var entity = _mainRepository.GetByCondition(e => e.Id == id);

            if (entity == null)
            {
                return NotFound(ResponseFactory.NotFound<T>());
            }

            return Ok(ResponseFactory.Successfully<T>(entity));
        }

        [HttpPost]
        public ActionResult Add([FromBody] T entity)
        {
            _mainRepository.Add(entity);
            _uow.Commit();

            return StatusCode(201, ResponseFactory.Created<T>(entity));
        }

        [HttpPut]
        public ActionResult Update([FromBody] T data)
        {
            var entity = _mainRepository.GetByCondition(m => m.Id == data.Id);

            if (entity == null)
            {
                return NotFound(ResponseFactory.NotFound<T>());
            }

            data.CreatedAt = entity.CreatedAt;

            _mainRepository.Update(data);
            _uow.Commit();

            return Ok(ResponseFactory.Updated<T>(data));
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var entity = _mainRepository.GetByCondition(e => e.Id == id);

            if (entity == null)
            {
                return NotFound(ResponseFactory.NotFound<T>());
            }

            _mainRepository.Delete(entity);
            _uow.Commit();

            return Ok(ResponseFactory.Deleted<T>(entity));
        }
    }
}
