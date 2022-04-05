using System.Data;

namespace WebApiDemo2
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetDatabaseConnection();
    }
}