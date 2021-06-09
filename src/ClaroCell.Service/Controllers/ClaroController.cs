using ClaroCell.Application.InterfacesService;
using ClaroCell.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClaroCell.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClaroController : ControllerBase
    {
        private readonly ICellAppService _cellAppService;
        private readonly IHostingEnvironment _hostingEnv;
        public ClaroController(ICellAppService cellAppService, IHostingEnvironment hostingEnv)
        {
            _cellAppService = cellAppService;
            _hostingEnv = hostingEnv;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var cells = await _cellAppService.GetAll();
            if (cells == null) return NotFound();

            return Ok(cells);
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<ActionResult> Get(string code)
        {
            var cell = await _cellAppService.Get(code);
            if (cell == null) return null;

            return Ok(cell);
            
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cell cell)
        {

            var result = await _cellAppService.Add(cell);
            if (!result) return BadRequest();

            return Ok();
        }


        [HttpPut("{code}")]
        [Authorize]
        public async Task<ActionResult> Put(string code, [FromBody] Cell cell)
        {
            var result = await _cellAppService.UpdateByCode(code, cell);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> Delete(string code)
        {
            var result = await _cellAppService.DeleteByCode(code);
            if (!result) return BadRequest();

            return Ok();
        }
    }
}
