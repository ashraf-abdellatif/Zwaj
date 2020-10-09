using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZwajApp.API.Data;

namespace ZwajApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        DataContext _datacontext;
        public ValuesController(DataContext datacontext )
        {
            _datacontext = datacontext;
        }
        // GET api/values
        [HttpGet]
        [Authorize] 
        public async Task<ActionResult> GetValues()
        {
            var Values = await  _datacontext.Values.ToListAsync();
            return Ok(Values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetValue(int id)
        {
            var Value = await  _datacontext.Values.FirstOrDefaultAsync(x=>x.id ==id);
            return Ok(Value); 
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
