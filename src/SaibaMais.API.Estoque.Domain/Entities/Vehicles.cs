using System;
using System.Collections.Generic;
using System.Text;

namespace SaibaMais.API.Estoque.Domain.Entities
{
    public class Vehicles
    {
        public string ATDT_011INVOIDATE { get; set; }
        public string FKSF_011VIN { get; set; }
        public string ATDT_011BUILDDATE { get; set; }
        public string FKSF_011MODCD { get; set; }
        public string FKSF_011MODEDNO { get; set; }
        public string FKSF_011ECOLCD { get; set; }
        public string FKNI_011FUELTYPER { get; set; }
        public int Days_on_inventory { get; set; }
        public string ATNI_001MODELYEAR { get; set; }
    }
}
