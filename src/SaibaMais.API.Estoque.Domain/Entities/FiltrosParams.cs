using System.Collections.Generic;

namespace SaibaMais.API.Estoque.Domain.Entities
{
    public class FiltrosParams
    {
        public List<ListFKSF_011SALEDISTCD> ListFKSF_011SALEDISTCD { get; set; }
        public List<ListFKNI_051ECONOMCODE> ListFKNI_051ECONOMCODE { get; set; }
        public List<ListFKSF_011SALESTATCD> ListFKSF_011SALESTATCD { get; set; }
        public List<ListFKNI_051SATELITE> ListFKNI_051SATELITE { get; set; }
    }
}
