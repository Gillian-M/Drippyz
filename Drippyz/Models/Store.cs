﻿using System.ComponentModel.DataAnnotations;

namespace Drippyz.Models
{
    public class Store
    {  
        [Key]
        public int Id { get; set; }
        public string Glyph { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }



    }
}
