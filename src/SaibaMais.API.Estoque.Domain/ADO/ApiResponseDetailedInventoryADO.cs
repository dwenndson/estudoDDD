using System;
using System.Collections.Generic;
using System.Text;

namespace SaibaMais.API.Estoque.Domain.ADO
{
    public class ApiResponseDetailedInventoryADO
    {
        public string ATSV_001CHASSI { get; set; }
        public string ATDT_001DATANF { get; set; }
        public string ATDT_011DATAFABRICACAO { get; set; }
        public string ATSV_001MODELCODE { get; set; }
        public string ATSV_001MODEDNO { get; set; }
        public string ATSV_001COR { get; set; }
        public string ATNI_001TPCOMBUSTIVEL { get; set; }
        public string QTD_PAGINAS { get; set; }
        public int DIAS_ESTOQUE { get; set; }
        public string ATNI_001MODELYEAR { get; set; }
    }
}
