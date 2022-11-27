using Checker.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace Checker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly TableManager tableManager;

        public ApiController(TableManager tableManager)
        {
            this.tableManager = tableManager;
        }

        [HttpGet("GetTables")]
        public IEnumerable<string> GetTables()
        {
            return tableManager.Tables.Where(t => t.Value < 2).Select(x=>x.Key);
        }
    }
}