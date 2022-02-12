using System;
using System.Collections.Generic;
using System.Text;

namespace SaibaMais.API.Estoque.Domain.Entities
{
    public class DetailedInventory
    {
        public string page_number { get; set; }
        public List<Vehicles> Vehicles { get; set; }
    }
}
