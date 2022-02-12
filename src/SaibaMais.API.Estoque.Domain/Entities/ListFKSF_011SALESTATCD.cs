using System.Collections.Generic;

namespace SaibaMais.API.Estoque.Domain.Entities
{
    public class ListFKSF_011SALESTATCD
    {
        public ListFKSF_011SALESTATCD() { }
        public string FKSF_011SALESTATCD { get; set; }

        public List<listFKNI_011SALECITYCD> listFKNI_011SALECITYCD { get; set; }
    }
}