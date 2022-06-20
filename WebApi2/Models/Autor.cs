﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi2.Models
{
    [Table("Autor")]
    public partial class Autor
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
    }
}
