using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI07102026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // GET api/producto?count=10
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetAll([FromQuery] int count = 10)
        {
            var clamped = Math.Clamp(count, 1, 100);
            var rnd = new Random();

            var productos = Enumerable.Range(1, clamped)
                .Select(i => new Producto
                {
                    id = i,
                    codigo = $"PRD{rnd.Next(1000, 9999)}",
                    precio = Math.Round(((decimal)rnd.NextDouble() * 1000m) + 1m, 2),
                    stock = rnd.Next(0, 500)
                })
                .ToList();

            return Ok(productos);
        }

        // GET api/producto/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            // Use id as seed so the same id returns the same random-like product
            var rnd = new Random(id);

            var producto = new Producto
            {
                id = id,
                codigo = $"PRD{rnd.Next(1000, 9999)}",
                precio = Math.Round(((decimal)rnd.NextDouble() * 1000m) + 1m, 2),
                stock = rnd.Next(0, 500)
            };

            return Ok(producto);
        }

        // GET api/producto/random50
        [HttpGet("lista")]
        public ActionResult<IEnumerable<Producto>> GetFifty()
        {
            const int total = 50;
            var rnd = new Random();

            var productos = Enumerable.Range(1, total)
                .Select(i => new Producto
                {
                    id = i,
                    codigo = $"PRD{rnd.Next(1000, 9999)}",
                    precio = Math.Round(((decimal)rnd.NextDouble() * 1000m) + 1m, 2),
                    stock = rnd.Next(0, 500)
                })
                .ToList();

            return Ok(productos);
        }
    }
}
