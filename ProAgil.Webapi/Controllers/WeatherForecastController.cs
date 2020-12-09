using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.Webapi.Data;
using ProAgil.Webapi.Model;

namespace ProAgil.Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        public readonly DataContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Teste")]
       // public IEnumerable<Evento> Teste()
        public async Task<IActionResult> Teste()
        {
            try
            {
                 return Ok( await _context.Eventos.ToListAsync());
            }
            catch (System.Exception)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }
           
           /* return new Evento[]
            {
                new Evento(){ 
                    DataEvento = "10/01",
                    EventoId=1,
                    Local = "minha casa",
                    Lote = "233",
                    QtdPessoas = 3,
                    Tema = "foda-se"
                 },
                 new Evento { 
                    DataEvento = "12/02",
                    EventoId=2,
                    Local = "minha casa",
                    Lote = "2323233",
                    QtdPessoas = 2,
                    Tema = "foda-se2"
                 }
            };*/
        }

        [HttpGet("Teste/{EventoId}")]
        public async Task<IActionResult> TesteId( int EventoId)
        {

           /* return new Evento[]
            {
                new Evento(){ 
                    DataEvento = "10/01",
                    EventoId=1,
                    Local = "minha casa",
                    Lote = "233",
                    QtdPessoas = 3,
                    Tema = "foda-se"
                 },
                 new Evento { 
                    DataEvento = "12/02",
                    EventoId=2,
                    Local = "minha casa",
                    Lote = "2323233",
                    QtdPessoas = 2,
                    Tema = "foda-se2"
                 }
            }.FirstOrDefault(x=> x.EventoId == EventoId );*/

            try
            {
                 return Ok( await _context.Eventos.FirstOrDefaultAsync(x=> x.EventoId == EventoId ));
            }
            catch (System.Exception)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }
               //return _context.Eventos.FirstOrDefault(x=> x.EventoId == EventoId );
        }
    }
}
