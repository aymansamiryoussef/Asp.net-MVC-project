﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CatogeryName { get; set; }

        public ICollection<Proudct> proudcts { get; set; }

    }
}
