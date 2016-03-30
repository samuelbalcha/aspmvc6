using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using demo.models;
using demo.orm;
using demo.infrastructure;

namespace demo.apis
{
    public class SuperPowersController
    {
        private readonly IRepository<SuperPower> _repository;
        private IUnitOfWork _unitOfWork;

        public SuperPowersController(IRepository<SuperPower> repo, IUnitOfWork unitOfWork)
        {
            _repository = repo;
            _unitOfWork = unitOfWork;
        }

        // GET: api/superheros
        [HttpGet]
        public IEnumerable<SuperPower> Get()
        {
            return _repository.GetAll();
        }

        // GET api/superheros/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var power = _repository.Get(id);
            if (power != null)
                return new ObjectResult(power);

            return new HttpNotFoundResult();
        }

        // POST api/superheros
        [HttpPost]
        public IActionResult Post([FromBody]SuperPower power)
        {
            var exists = _repository.Find(x => x.Name == power.Name).FirstOrDefault();

            if (exists == null || power.Id == 0)
            {
                _repository.Add(power);
            }
            else
            {
                exists.Name = power.Name;
            }
            _unitOfWork.Complete();
            return new ObjectResult(power);
        }

        // PUT api/superheros/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SuperPower power)
        {
            var exists = _repository.Get(id);
            if (exists != null)
            {
                exists.Name = power.Name;
            }
            else
            {
                _repository.Add(power);
            }
            _unitOfWork.Complete();
            return new ObjectResult(power);
        }

        // DELETE api/superheros/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var exists = _repository.Get(id);
            if (exists != null)
            {
                _repository.Remove(exists);
                _unitOfWork.Complete();
                return new HttpStatusCodeResult(200);
            }

            return new HttpStatusCodeResult(404);
        }


    }
}
