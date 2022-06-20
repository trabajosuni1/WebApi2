using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        
        [HttpGet(Name = "FindtAutor")]
        public async Task<List<Autor>> FindList(string? Name)
        {
            using (bookContext db = new bookContext())
            {
                if (!string.IsNullOrEmpty(Name))
                    return await db.Autors.Where(p => p.Name == Name).Select(s => s).ToListAsync();
                else
                    return await db.Autors.ToListAsync();
            }

        }
        [HttpPost(Name = "CreateAutor")]
        public async Task<OkResult> CreateAutor(Autor autor)
        {
            using (bookContext db = new bookContext())
            {
                db.Autors.Add(autor);
                await db.SaveChangesAsync();
                return Ok();
            }

        }

        [HttpPut(Name = "Update")]
        public async Task<ActionResult> UpdateAutor([FromBody] Autor autor)
        {
            using (bookContext db = new bookContext())
            {
                var aut1 = db.Autors.FirstOrDefault(aut => aut.Id == autor.Id);
                if(aut1 != null) aut1.Name = autor.Name;
                await db.SaveChangesAsync();
                return Ok();

                
            }

        }

        [HttpDelete(Name = "Delete")]
        public async Task<ActionResult> deleteAutor(int id)
        {
            using (bookContext db = new bookContext())
            {
                var aut1 = db.Autors.FirstOrDefault(aut => aut.Id == id);
                if (aut1 != null) db.Remove<Autor>(aut1);
                
                await db.SaveChangesAsync();
                return Ok();


            }

        }
    }
}
