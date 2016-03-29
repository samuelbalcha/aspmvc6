using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using demo.models;
using demo.orm;
using demo.repository;
using demo.infrastructure;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace demo.apis
{
    [Route("api/[controller]")]
    public class SuperHerosController : Controller
    {
        
        private IRepository<SuperHero> _repository { get; set; }
        
        public SuperHerosController(IRepository<SuperHero> repo)
        {
            _repository = repo;
        }

        // GET: api/superhero
        [HttpGet]
        public IEnumerable<SuperHero> Get()
        {
            return _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public SuperHero Get(int id)
        {
            return _repository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]SuperHero hero)
        {
           
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
