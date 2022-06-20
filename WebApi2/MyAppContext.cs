using Microsoft.EntityFrameworkCore;
using WebApi2.Modelos;

namespace WebApi2
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options)
           : base(options)
        {

        }
        //public AppContext(DbContextOptions options) : base(options)
        //{

        //}
        //public MyAppContext(DbContextOptions options) : base(options: options)
        //{

        //}
        public DbSet<Autor>? autors { get; set; }


    }
}
