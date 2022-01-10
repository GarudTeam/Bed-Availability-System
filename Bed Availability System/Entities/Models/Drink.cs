﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
  public  class Drink
    {
        public int Id { get; set; }
        [DisplayName("Drink Name")]
        public string DrinkName { get; set; }
        public int Price { get; set; }
        public string image { get; set; }
    }
}