using System.Collections.Generic;

namespace SaibaMais.API.Estoque.Domain.Entities
{
    public class ListFKNI_051ECONOMCODE
    {
        public ListFKNI_051ECONOMCODE(int fKNI_051ECONOMCODE, string aTSF_066ECONOMDESC, 
            List<LstFKNI_011SALEDEALCD> lstFKNI_011SALEDEALCD)
        {
            FKNI_051ECONOMCODE = fKNI_051ECONOMCODE;
            ATSF_066ECONOMDESC = aTSF_066ECONOMDESC;
            LstFKNI_011SALEDEALCD = lstFKNI_011SALEDEALCD;
        }

        public ListFKNI_051ECONOMCODE() { }

        public int FKNI_051ECONOMCODE { get; set; }
        public string ATSF_066ECONOMDESC { get; set; }
        public List<LstFKNI_011SALEDEALCD> LstFKNI_011SALEDEALCD { get; set; }
    }
}