using InterfaceAdapters.Types;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace InterfaceAdapters.DataBases
{
    internal class DBConnectionFactory(IConfiguration configuration)
    {
        public SqlConnection CreateConnection(DataBasesConnectionTypes con) =>
            new(configuration.GetConnectionString(con.ToString()));

        public SqlConnection SaleEFE { get => CreateConnection(DataBasesConnectionTypes.SaleEFE); }
    }
}
