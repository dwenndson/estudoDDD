using System;

namespace SaibaMais.API.Estoque.Domain.Entities
{
    public class ApiResponse
    {
        public string ATDT_011INVOIDATE { get; set; }
        public string ATDT_011BUILDDATE { get; set; }
        public string FKSF_011VIN { get; set; }
        public int FKSF_011SALEDISTCD { get; set; }
        public int FKNI_011SALEDEALCD { get; set; }
        public int FKNI_011SALECITYCD { get; set; }
        public string FKSF_011SALESTATCD { get; set; }
        public string FKSF_011MODCD { get; set; }
        public string FKSF_011MODEDNO { get; set; }
        public string FKSF_011ECOLCD { get; set; }
        public int FKNI_011FUELTYPER { get; set; }
        public int FKNI_051ECONOMCODE { get; set; }
        public int FKNI_051SATELITE { get; set; }
        public int PKNI_052INCORDER { get; set; }
        public string ATSF_011ENDSALESID { get; set; }
        public string ATSF_011CANCELID { get; set; }
        public string ATSF_011RSTATUS { get; set; }
        public string ATDT_011CANCELDATE { get; set; }
        public string ATDT_011RLICSENDDT { get; set; }
        public string ATSF_011PRTP_OCCS { get; set; }
        public string ATDT_052CREATDATE { get; set; }
        public string ATSF_066ECONOMDESC { get; set; }
        public string ATNI_001MODELYEAR { get; set; }

    }
}
