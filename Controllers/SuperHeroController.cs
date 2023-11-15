using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Nombre = "AnderMan",
                PrimerNombre = "Anderson",
                Apellido = "Llamuca",
                Ciudad = "Guayaquil",

            },

            new SuperHero
            {
                Id = 2,
                Nombre = "MegaBoy",
                PrimerNombre = "Alex",
                Apellido = "Traswe",
                Ciudad = "gresa",

            },

            new SuperHero
            {
                Id = 3,
                Nombre = "Thor",
                PrimerNombre = "Thor",
                Apellido = "Odinson",
                Ciudad = "Asgard",

            },

            new SuperHero
            {
                Id = 4,
                Nombre = "Hulk",
                PrimerNombre = "Bruce",
                Apellido = "Banner",
                Ciudad = "Nueva York",

            },

            new SuperHero
            {
                Id = 5,
                Nombre = "Deadpool",
                PrimerNombre = "Wade",
                Apellido = "Wilson",
                Ciudad = "Nueva York",

            },

            new SuperHero
            {
                Id = 6,
                Nombre = "Doctor Strange",
                PrimerNombre = "Stephen",
                Apellido = "Strange",
                Ciudad = "Nueva York",

            },

            new SuperHero
            {
                Id = 7,
                Nombre = "Iron Man",
                PrimerNombre = "Tony",
                Apellido = "Stark",
                Ciudad = "Nueva York",

            },

            new SuperHero
            {
                Id = 8,
                Nombre = "Ant-Man",
                PrimerNombre = "Scott",
                Apellido = "Lang",
                Ciudad = "San Francisco",

            },

            new SuperHero
            {
                Id = 9,
                Nombre = "Daredevil",
                PrimerNombre = "Matt",
                Apellido = "Murdock",
                Ciudad = "Nueva York",

            },

            new SuperHero
            {
                Id = 10,
                Nombre = "Groot",
                PrimerNombre = "Ramita feliz",
                Apellido = "Yo soy Groot",
                Ciudad = "Planeta X",

            },

            new SuperHero
            {
                Id = 11,
                Nombre = "Doctor Doom",
                PrimerNombre = "Victor ",
                Apellido = "Von Doom",
                Ciudad = "Latveria",

            },
        };

        [HttpGet]
        public IActionResult ObtenerTodosLosHeroes()
        {
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerHeroePorId(int id)
        {
            var heroe = superHeroes.FirstOrDefault(h => h.Id == id);
            if (heroe == null)
            {
                return NotFound($"Heroe con Id {id} no encontrado.");
            }

            return Ok(heroe);
        }

        [HttpPost]
        public IActionResult AgregarHeroe([FromBody] SuperHero nuevoHeroe)
        {
            nuevoHeroe.Id = superHeroes.Count + 1;
            superHeroes.Add(nuevoHeroe);

            return CreatedAtAction(nameof(ObtenerHeroePorId), new { id = nuevoHeroe.Id }, nuevoHeroe);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarHeroe(int id, [FromBody] SuperHero heroeActualizado)
        {
            var heroeExistente = superHeroes.FirstOrDefault(h => h.Id == id);
            if (heroeExistente == null)
            {
                return NotFound($"Heroe con Id {id} no encontrado.");
            }

            heroeExistente.Nombre = heroeActualizado.Nombre;
            heroeExistente.PrimerNombre = heroeActualizado.PrimerNombre;
            heroeExistente.Apellido = heroeActualizado.Apellido;
            heroeExistente.Ciudad = heroeActualizado.Ciudad;

            return Ok(heroeExistente);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarHeroe(int id)
        {
            var heroeAEliminar = superHeroes.FirstOrDefault(h => h.Id == id);
            if (heroeAEliminar == null)
            {
                return NotFound($"Heroe con Id {id} no encontrado.");
            }

            superHeroes.Remove(heroeAEliminar);

            return Ok(superHeroes); // Devuelve la lista actualizada después de eliminar
        }
    }
}

