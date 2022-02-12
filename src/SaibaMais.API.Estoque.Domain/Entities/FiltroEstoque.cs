using System;
using System.Collections.Generic;
using System.Text;

namespace SaibaMais.API.Estoque.Domain.Entities
{
    public class FiltroEstoque
    {
        public FiltroEstoque() { }
        public FiltroEstoque(int[] fKNI_011SALEDEALCD = null, int[] fKNI_051ECONOMCODE = null,
            int[] fKSF_011SALEDISTCD = null, int[] fKNI_011SALECITYCD = null,
            int[] fKNI_051SATELITE = null, string[] fKSF_011SALESTATCD = null)
        {
            FKNI_011SALEDEALCD = fKNI_011SALEDEALCD;
            FKNI_051ECONOMCODE = fKNI_051ECONOMCODE;
            FKSF_011SALEDISTCD = fKSF_011SALEDISTCD;
            FKNI_011SALECITYCD = fKNI_011SALECITYCD;
            FKNI_051SATELITE = fKNI_051SATELITE;
            FKSF_011SALESTATCD = fKSF_011SALESTATCD;
        }

        public int[] FKNI_011SALEDEALCD { get; set; }
        public int[] FKNI_051ECONOMCODE { get; set; }
        public int[] FKSF_011SALEDISTCD { get; set; }
        public int[] FKNI_011SALECITYCD { get; set; }
        public int[] FKNI_051SATELITE { get; set; }
        public string[] FKSF_011SALESTATCD { get; set; }
    }
}
