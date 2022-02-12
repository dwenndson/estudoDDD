using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaibaMais.API.Estoque.Domain.Entities
{
    public class FiltroDetailedInventory
    {
        public FiltroDetailedInventory(int[] fKNI_011SALEDEALCD, int[] fKNI_051ECONOMCODE,
            int[] fKSF_011SALEDISTCD, int[] fKNI_011SALECITYCD, int[] fKNI_051SATELITE,
            string[] fKSF_011SALESTATCD, string[] fKSF_011MODCD, string[] fKSF_011MODEDNO, int page = 1)
        {
            FKNI_011SALEDEALCD = fKNI_011SALEDEALCD;
            FKNI_051ECONOMCODE = fKNI_051ECONOMCODE;
            FKSF_011SALEDISTCD = fKSF_011SALEDISTCD;
            FKNI_011SALECITYCD = fKNI_011SALECITYCD;
            FKNI_051SATELITE = fKNI_051SATELITE;
            FKSF_011SALESTATCD = fKSF_011SALESTATCD;
            FKSF_011MODCD = fKSF_011MODCD;
            FKSF_011MODEDNO = fKSF_011MODEDNO;
            Page = page;
        }

        public FiltroDetailedInventory() { }

        public int[] FKNI_011SALEDEALCD { get; set; }
        public int[] FKNI_051ECONOMCODE { get; set; }
        public int[] FKSF_011SALEDISTCD { get; set; }
        public int[] FKNI_011SALECITYCD { get; set; }
        public int[] FKNI_051SATELITE { get; set; }
        public string[] FKSF_011SALESTATCD { get; set; }
        [Required]
        public string[] FKSF_011MODCD { get; set; }
        [Required]
        public string[] FKSF_011MODEDNO { get; set; }
        public int Page { get; set; }

    }
}
