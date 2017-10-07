using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<MyCustomType> Get()
        {
            return new MyCustomType[] { new MyCustomType { Id=1, Text="foo"}, new MyCustomType { Id=2, Text="bar"} };
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public MyCustomType Get(int id)
        {
            return new MyCustomType { Id=id};
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
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

    public class MyCustomType {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
