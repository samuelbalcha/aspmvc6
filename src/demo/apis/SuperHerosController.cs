using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using demo.models;
using demo.orm;
using demo.infrastructure;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace demo.apis
{
    [Route("api/[controller]")]
    public class SuperHerosController : Controller
    {
        private readonly IRepository<SuperHero> _repository;
        private IUnitOfWork _unitOfWork;

        public SuperHerosController(IRepository<SuperHero> repo, IUnitOfWork unitOfWork)
        {
            _repository = repo;
            _unitOfWork = unitOfWork;
        }

        // GET: api/superheros
        [HttpGet]
        public IEnumerable<SuperHero> Get()
        {
            return _repository.GetAll();
        }

        // GET api/superheros/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hero = _repository.Get(id);
            if (hero != null)
                return new ObjectResult(hero);
             
             return new HttpNotFoundResult();
        }

        // POST api/superheros
        [HttpPost]
        public IActionResult Post([FromBody]SuperHero hero)
        {
            var exists = _repository.Find(x => x.Name == hero.Name).FirstOrDefault();
            
            if (exists == null || hero.Id == 0)
            {
                _repository.Add(hero);
            }
            else
            {
                exists.Name = hero.Name;
            }
            _unitOfWork.Complete();
            return new ObjectResult(hero);
        }

        // PUT api/superheros/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SuperHero hero)
        {
            var exists = _repository.Get(id);
            if (exists != null)
            {
                exists.Name = hero.Name;
            }
            else
            {
                _repository.Add(hero);
            }
            _unitOfWork.Complete();
            return new ObjectResult(hero);
        }

        // DELETE api/superheros/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var exists = _repository.Get(id);
            if(exists != null)
            {
                _repository.Remove(exists);
                _unitOfWork.Complete();
                return new HttpStatusCodeResult(200);
            }

            return new HttpStatusCodeResult(404);
        }
    }
}
