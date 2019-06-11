using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoryGame.Core.DAL;
using Microsoft.AspNetCore.Mvc;
using MemoryGame.BusinessLogic;

namespace MemoryGame.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    private readonly Teste blTeste;

    public ValuesController(Teste BlTeste)
    {
      blTeste = BlTeste;
    }
    // GET api/values
    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
      var a = await blTeste.Get();
      return "a.ToString()";
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
