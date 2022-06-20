using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi2.Models
{
    [Table("Libro")]
    public partial class Libro
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Titulo { get; set; }
        [Column("Id_Autor")]
        public int? IdAutor { get; set; }
    }
}
