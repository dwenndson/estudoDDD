using System;
using System.Collections.Generic;

namespace SaibaMais.API.Estoque.Domain.Entities
{
    public class Inventory
    {
        public string FKSF_011MODCD { get; set; }

        public List<Models> Models { get; set; }


    }
}
