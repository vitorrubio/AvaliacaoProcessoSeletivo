using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoProcessoSeletivo.Api.Domain;
using AvaliacaoProcessoSeletivo.Api.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AvaliacaoProcessoSeletivo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Contexto _contexto;

        public ContaController(ILogger<WeatherForecastController> logger, Contexto ctx)
        {
            _logger = logger;
            _contexto = ctx;
        }

        [HttpGet]
        public IEnumerable<Conta> Get()
        {
            return _contexto.Conta.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var retorno = _contexto.Conta.Find(id);
            if(retorno == null)
            {
                return NotFound();
            }
            return Ok( retorno);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var ct = _contexto.Conta.Find(id);
            _contexto.Remove(ct);
            return Ok();
        }


        [HttpPost]
        public Conta Post(Conta con)
        {

            if(con.Id == 0)
            {
                _contexto.Add(con);
                
            }
            else
            {
                _contexto.Entry(con).State = EntityState.Modified;
            }

            _contexto.SaveChanges();

            return con;
        }

        //[HttpPut]
        //public IActionResult Put(Conta con)
        //{

        //    return Ok();
        //}
    }
}
