using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyLibroController : ControllerBase
    {
        [HttpGet(Name = "FindBook")]
        public async Task<List<Libro>> FindList(string? Name)
        {
            using (bookContext db = new bookContext())
            {
                if (!string.IsNullOrEmpty(Name))
                    return await db.Libros.Where(p => p.Titulo == Name).Select(s => s).ToListAsync();
                else
                    return await db.Libros.ToListAsync();
            }

            }
        [HttpPost(Name = "CreateBook")]
        public async Task<OkResult> Createlibro(Libro libro)
        {
            using (bookContext db = new bookContext())
            {
                db.Libros.Add(libro);
                await db.SaveChangesAsync();
                return Ok();
            }

        }

        [HttpPut(Name = "UpdateBook")]
        public async Task<ActionResult> Updatelibro([FromBody] Libro libro)
        {
            using (bookContext db = new bookContext())
            {
                var aut1 = db.Libros.FirstOrDefault(aut => aut.Id == libro.Id);
                if (aut1 != null)
                {
                    aut1.Titulo = libro.Titulo;
                    aut1.IdAutor = libro.IdAutor;
                }
                await db.SaveChangesAsync();
                return Ok();


            }

        }

        [HttpDelete(Name = "DeleteBook")]
        public async Task<ActionResult> deletelibro(int id)
        {
            using (bookContext db = new bookContext())
            {
                var aut1 = db.Libros.FirstOrDefault(aut => aut.Id == id);
                if (aut1 != null) db.Remove<Libro>(aut1);

                await db.SaveChangesAsync();
                return Ok();


            }

        }


    }
}
