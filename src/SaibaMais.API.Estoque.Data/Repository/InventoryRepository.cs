namespace SaibaMais.API.Estoque.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using Oracle.ManagedDataAccess.Client;
    using SaibaMais.API.Estoque.Domain;
    using SaibaMais.API.Estoque.Domain.ADO;
    using SaibaMais.API.Estoque.Domain.Entities;
    using SaibaMais.API.Estoque.Domain.Interfaces;

    public class InventoryRepository : RepositoryBase<ApiResponse>, IInventoryRepository
    {
        private string command = string.Empty;
        private readonly IOptions<AppSettings> _appSettings;

        public InventoryRepository(IConfiguration configuration, IOptions<AppSettings> appSettings)
                                  : base(configuration)
        {
            _appSettings = appSettings;
        }

        public async Task<ApiResponse> GetVehicleDetails(string chassiVeiculo)
        {
            List<ApiResponse> response = new List<ApiResponse>();

            command = @"SELECT
                     ATDT_001DATANF
                     , ATDT_011DATAFABRICACAO
                     , ATSV_001CHASSI
                     , ATNI_001REGIAO
                     , ATNI_001CODIGODEALER
                     , ATNI_001CIDADEDEALER
                     , ATSV_001ESTADODEALER
                     , ATSV_001MODELCODE
                     , ATSV_001MODEDNO
                     , ATSV_001COR
                     , ATNI_001TPCOMBUSTIVEL
                     , ATNI_001GRUPOECONOMICO
                     , ATNI_001SATELITE
                     , ATNI_001PEDIDO
                     , ATSV_001ATIVOESTOQUE
                     , ATSV_001CANCELADO
                     , ATSV_001STATUSVEICULO
                     , ATDT_001DATACANCELAMENTO
                     , ATDT_001DATALICENCIAMENTO
                     , ATSV_001PACOTE
                     , ATDT_001DATACRIACAO
                     , ATNI_001MODELYEAR
                     FROM SBMADM.OADC001T_SBMESTOQUEONLINE
                     WHERE ATSV_001CHASSI = '" + chassiVeiculo + "'";

            using (OracleConnection conn = new OracleConnection(this.REPDB2_DB))
            {
                try
                {
                    await conn.OpenAsync();
                    var selectReturn = await conn.QueryAsync<ApiResponseADO>(command);

                    foreach (ApiResponseADO resp in selectReturn.ToList())
                    {
                        ApiResponse temp = new ApiResponse();

                        temp.ATDT_011INVOIDATE = resp.ATDT_001DATANF;

                        temp.ATDT_011BUILDDATE = resp.ATDT_011DATAFABRICACAO;
                        temp.FKSF_011VIN = resp.ATSV_001CHASSI;
                        temp.FKSF_011SALEDISTCD = resp.ATNI_001REGIAO;
                        temp.FKNI_011SALEDEALCD = resp.ATNI_001CODIGODEALER;
                        temp.FKNI_011SALECITYCD = resp.ATNI_001CIDADEDEALER;
                        temp.FKSF_011SALESTATCD = resp.ATSV_001ESTADODEALER;
                        temp.FKSF_011MODCD = resp.ATSV_001MODELCODE;
                        temp.FKSF_011MODEDNO = resp.ATSV_001MODEDNO;
                        temp.FKSF_011ECOLCD = resp.ATSV_001COR;
                        temp.FKNI_011FUELTYPER = resp.ATNI_001TPCOMBUSTIVEL;
                        temp.FKNI_051ECONOMCODE = resp.ATNI_001GRUPOECONOMICO;
                        temp.FKNI_051SATELITE = resp.ATNI_001SATELITE;
                        temp.PKNI_052INCORDER = resp.ATNI_001PEDIDO;
                        temp.ATSF_011ENDSALESID = resp.ATSV_001ATIVOESTOQUE;
                        temp.ATSF_011CANCELID = resp.ATSV_001CANCELADO;
                        temp.ATSF_011RSTATUS = resp.ATSV_001STATUSVEICULO;
                        temp.ATDT_011CANCELDATE = resp.ATDT_001DATACANCELAMENTO;
                        temp.ATDT_011RLICSENDDT = resp.ATDT_001DATALICENCIAMENTO;
                        temp.ATSF_011PRTP_OCCS = resp.ATSV_001PACOTE;
                        temp.ATDT_052CREATDATE = resp.ATDT_001DATACRIACAO;
                        temp.ATSF_066ECONOMDESC = resp.ATSV_001DESCGRUPOECONOMICO;
                        temp.ATNI_001MODELYEAR = resp.ATNI_001MODELYEAR;

                        response.Add(temp);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return response.FirstOrDefault();
        }

        public async Task<List<Inventory>> GetInventory(FiltroEstoque filtroEstoque)
        {
            List<Inventory> response = new List<Inventory>();
            
            command = $"SELECT DISTINCT ATSV_001MODELCODE " +
                    ", ATSV_001MODEDNO, COUNT(ATSV_001MODELCODE) OVER " +
                    "(PARTITION BY ATSV_001MODEDNO, ATSV_001MODELCODE) QUANTIDADE " +
                    "FROM SBMADM.OADC001T_SBMESTOQUEONLINE ";

            if (filtroEstoque.FKNI_011SALEDEALCD != null || filtroEstoque.FKNI_051ECONOMCODE != null || filtroEstoque.FKSF_011SALEDISTCD != null || filtroEstoque.FKNI_011SALECITYCD != null || filtroEstoque.FKNI_051SATELITE != null || filtroEstoque.FKSF_011SALESTATCD != null)
            {
                command = command + " WHERE 1=1 ";

                if (filtroEstoque.FKNI_011SALEDEALCD != null && filtroEstoque.FKNI_011SALEDEALCD.Length > 0)
                    command = command + " AND ATNI_001CODIGODEALER IN (" + string.Join(",", filtroEstoque.FKNI_011SALEDEALCD) + ")";                    

                if (filtroEstoque.FKNI_051ECONOMCODE != null && filtroEstoque.FKNI_051ECONOMCODE.Length > 0)                
                    command = command + " AND ATNI_001GRUPOECONOMICO IN (" + string.Join(",", filtroEstoque.FKNI_051ECONOMCODE) + ")";

                if (filtroEstoque.FKSF_011SALEDISTCD != null && filtroEstoque.FKSF_011SALEDISTCD.Length > 0)
                    command = command + " AND ATNI_001REGIAO IN (" + string.Join(",", filtroEstoque.FKSF_011SALEDISTCD) + ")";

                if (filtroEstoque.FKNI_011SALECITYCD != null && filtroEstoque.FKNI_011SALECITYCD.Length > 0)
                    command = command + " AND ATNI_001CIDADEDEALER IN (" + string.Join(",", filtroEstoque.FKNI_011SALECITYCD) + ")";

                if (filtroEstoque.FKNI_051SATELITE != null && filtroEstoque.FKNI_051SATELITE.Length > 0)
                    command = command + " AND ATNI_001SATELITE IN (" + string.Join(",", filtroEstoque.FKNI_051SATELITE) + ")";

                if (filtroEstoque.FKSF_011SALESTATCD != null && filtroEstoque.FKSF_011SALESTATCD.Length > 0)
                    command = command + " AND ATSV_001ESTADODEALER IN ('" + string.Join("','", filtroEstoque.FKSF_011SALESTATCD) + "')";
            }

            command = command + " ORDER BY ATSV_001MODELCODE ";

            using (OracleConnection conn = new OracleConnection(this.REPDB2_DB))
            {
                try
                {
                    await conn.OpenAsync();
                    var selectReturn = await conn.QueryAsync<ApiResponseInventoryADO>(command);

                    foreach (ApiResponseInventoryADO resp in selectReturn.ToList())
                    {
                        Inventory temp = new Inventory();

                        if (response.Where(i => i.FKSF_011MODCD == resp.ATSV_001MODELCODE).Count() == 0)
                        {
                            temp.FKSF_011MODCD = resp.ATSV_001MODELCODE;

                            temp.Models = new List<Models>();

                            temp.Models.AddRange(selectReturn.ToList()
                                .Where(x => x.ATSV_001MODELCODE == resp.ATSV_001MODELCODE)
                                .Select(x => new Models() { FKSF_011MODEDNO = x.ATSV_001MODEDNO, count = x.QUANTIDADE }));

                            response.Add(temp);
                        }

                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return response;
        }

        public async Task<List<DetailedInventory>> GetDetailedInventory(FiltroDetailedInventory filtro)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

            List<DetailedInventory> response = new List<DetailedInventory>();

            if (filtro.Page < 1)
                filtro.Page = 1;

            command = $"SELECT ATSV_001CHASSI, ATDT_001DATANF, " +
                " ATDT_011DATAFABRICACAO, ATSV_001MODELCODE, ATSV_001MODEDNO, ATSV_001COR, " +
                " ATNI_001TPCOMBUSTIVEL, ROUND((count(*) over()) / 10) QTD_PAGINAS, ATNI_001MODELYEAR " +
                " FROM SBMADM.OADC001T_SBMESTOQUEONLINE ";
          
            command = command + " WHERE ";
            command = command + " ATSV_001MODELCODE IN ('" + string.Join("','", filtro.FKSF_011MODCD) + "')";
            command = command + " AND ATSV_001MODEDNO IN ('" + string.Join("','", filtro.FKSF_011MODEDNO) + "')";

            if (filtro.FKNI_011SALEDEALCD != null || filtro.FKNI_051ECONOMCODE != null || filtro.FKSF_011SALEDISTCD != null || filtro.FKNI_011SALECITYCD != null || filtro.FKNI_051SATELITE != null || filtro.FKSF_011SALESTATCD != null)
            {
                if (filtro.FKNI_011SALEDEALCD != null && filtro.FKNI_011SALEDEALCD.Length > 0)
                    command = command + " AND ATNI_001CODIGODEALER IN (" + string.Join(",", filtro.FKNI_011SALEDEALCD) + ")";

                if (filtro.FKNI_051ECONOMCODE != null && filtro.FKNI_051ECONOMCODE.Length > 0)
                    command = command + " AND ATNI_001GRUPOECONOMICO IN (" + string.Join(",", filtro.FKNI_051ECONOMCODE) + ")";

                if (filtro.FKSF_011SALEDISTCD != null && filtro.FKSF_011SALEDISTCD.Length > 0)
                    command = command + " AND ATNI_001REGIAO IN (" + string.Join(",", filtro.FKSF_011SALEDISTCD) + ")";

                if (filtro.FKNI_011SALECITYCD != null && filtro.FKNI_011SALECITYCD.Length > 0)
                    command = command + " AND ATNI_001CIDADEDEALER IN (" + string.Join(",", filtro.FKNI_011SALECITYCD) + ")";

                if (filtro.FKNI_051SATELITE != null && filtro.FKNI_051SATELITE.Length > 0)
                    command = command + " AND ATNI_001SATELITE IN (" + string.Join(",", filtro.FKNI_051SATELITE) + ")";

                if (filtro.FKSF_011SALESTATCD != null && filtro.FKSF_011SALESTATCD.Length > 0)
                    command = command + " AND ATSV_001ESTADODEALER IN ('" + string.Join("','", filtro.FKSF_011SALESTATCD) + "')";
            }

            command = command + " OFFSET nvl(" + filtro.Page + "-1,1)* 10 ROWS FETCH NEXT 10 ROWS ONLY ";

            using (OracleConnection conn = new OracleConnection(this.REPDB2_DB))
            {
                try
                {
                    await conn.OpenAsync();
                    var selectReturn = await conn.QueryAsync<ApiResponseDetailedInventoryADO>(command);

                    DetailedInventory temp = new DetailedInventory();

                    if (selectReturn != null && selectReturn.ToList().Count > 0)
                    {
                        temp.page_number = selectReturn.ToList().FirstOrDefault().QTD_PAGINAS;

                        temp.Vehicles = new List<Vehicles>();
                        temp.Vehicles.AddRange(selectReturn.ToList().Select(i =>
                           new Vehicles()
                           {
                               ATDT_011INVOIDATE = i.ATDT_001DATANF,
                               ATDT_011BUILDDATE = i.ATDT_011DATAFABRICACAO,
                               FKSF_011VIN = i.ATSV_001CHASSI,
                               FKSF_011MODCD = i.ATSV_001MODELCODE,
                               FKSF_011ECOLCD = i.ATSV_001COR,
                               FKSF_011MODEDNO = i.ATSV_001MODEDNO,
                               FKNI_011FUELTYPER = i.ATNI_001TPCOMBUSTIVEL,
                               Days_on_inventory = (int)(DateTime.Now - Convert.ToDateTime(i.ATDT_011DATAFABRICACAO)).TotalDays,
                               ATNI_001MODELYEAR = i.ATNI_001MODELYEAR
                           }));

                        response.Add(temp);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return response;
        }

        public async Task<FiltrosParams> GetFiltroParams()
        {
            FiltrosParams p = new FiltrosParams();

            command = $"SELECT DISTINCT ATNI_001REGIAO as FKSF_011SALEDISTCD " +
                " FROM SBMADM.OADC001T_SBMESTOQUEONLINE ";

            using (OracleConnection conn = new OracleConnection(this.REPDB2_DB))
            {
                try
                {
                    await conn.OpenAsync();
                    var selectReturn = await conn.QueryAsync<ListFKSF_011SALEDISTCD>(command);

                    p.ListFKSF_011SALEDISTCD = selectReturn.ToList();

                    command = $"SELECT DISTINCT ATNI_001SATELITE as FKNI_051SATELITE" +
                                " FROM SBMADM.OADC001T_SBMESTOQUEONLINE ";

                    var selectReturnSat = await conn.QueryAsync<ListFKNI_051SATELITE>(command);

                    p.ListFKNI_051SATELITE = selectReturnSat.ToList();

                    command = $"SELECT DISTINCT ATNI_001GRUPOECONOMICO " +
                                   ", ATSV_001DESCGRUPOECONOMICO, ATNI_001CODIGODEALER FROM SBMADM.OADC001T_SBMESTOQUEONLINE " +
                                    " ORDER BY ATNI_001GRUPOECONOMICO";

                    var selectReturnGru = await conn.QueryAsync<GrupoEconomicoADO>(command);

                    p.ListFKNI_051ECONOMCODE = new List<ListFKNI_051ECONOMCODE>();

                    foreach (GrupoEconomicoADO resp in selectReturnGru.ToList())
                    {
                        ListFKNI_051ECONOMCODE temp = new ListFKNI_051ECONOMCODE();

                        if (p.ListFKNI_051ECONOMCODE.Where(i => i.FKNI_051ECONOMCODE == resp.ATNI_001GRUPOECONOMICO).Count() == 0)
                        {
                            temp.FKNI_051ECONOMCODE = resp.ATNI_001GRUPOECONOMICO;
                            temp.ATSF_066ECONOMDESC = resp.ATSV_001DESCGRUPOECONOMICO;

                            temp.LstFKNI_011SALEDEALCD = new List<LstFKNI_011SALEDEALCD>();

                            temp.LstFKNI_011SALEDEALCD.AddRange(selectReturnGru.ToList()
                                .Where(x => x.ATNI_001GRUPOECONOMICO == resp.ATNI_001GRUPOECONOMICO)
                                .Select(x => new LstFKNI_011SALEDEALCD() { FKNI_011SALEDEALCD = x.ATNI_001CODIGODEALER }));

                            p.ListFKNI_051ECONOMCODE.Add(temp);
                        }
                    }

                    command = $"SELECT DISTINCT ATSV_001ESTADODEALER " +
                                ", ATNI_001CIDADEDEALER FROM SBMADM.OADC001T_SBMESTOQUEONLINE ORDER BY ATSV_001ESTADODEALER";

                    var selectReturnDealer = await conn.QueryAsync<EstadoADO>(command);

                    p.ListFKSF_011SALESTATCD = new List<ListFKSF_011SALESTATCD>();

                    foreach (EstadoADO resp in selectReturnDealer.ToList())
                    {
                        ListFKSF_011SALESTATCD temp = new ListFKSF_011SALESTATCD();

                        if (p.ListFKSF_011SALESTATCD.Where(i => i.FKSF_011SALESTATCD == resp.ATSV_001ESTADODEALER).Count() == 0)
                        {
                            temp.FKSF_011SALESTATCD = resp.ATSV_001ESTADODEALER;

                            temp.listFKNI_011SALECITYCD = new List<listFKNI_011SALECITYCD>();

                            temp.listFKNI_011SALECITYCD.AddRange(selectReturnDealer.ToList()
                                .Where(x => x.ATSV_001ESTADODEALER == resp.ATSV_001ESTADODEALER)
                                .Select(x => new listFKNI_011SALECITYCD() { FKNI_011SALECITYCD = x.ATNI_001CIDADEDEALER }));

                            p.ListFKSF_011SALESTATCD.Add(temp);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return p;
            }

        }


    }
}
