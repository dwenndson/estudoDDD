namespace SaibaMais.API.Estoque.Data.Repository
{
    using Microsoft.Extensions.Configuration;

    public abstract class RepositoryBase<T> 
    {
        //protected string LEADSMKTADM_DB { get; }
        protected string REPDB2_DB { get; }
        
        public RepositoryBase(IConfiguration configuration)
        {
            //LEADSMKTADM_DB = configuration.GetConnectionString("LEADSMKTADM_DB");
            REPDB2_DB = configuration.GetConnectionString("REPDB2_DB");
        }
    }
}
