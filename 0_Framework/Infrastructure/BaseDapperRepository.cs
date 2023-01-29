using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace _0_Framework.Infrastructure;

public class BaseDapperRepository
{
    private readonly IConnectionStringBuilder _connectionStringBuilder;

    public BaseDapperRepository(IConnectionStringBuilder connectionStringBuilder)
    {
        _connectionStringBuilder = connectionStringBuilder;
    }

    public T SelectFirstOrDefault<T>(string sql, object parameters = null)
    {
        using var connection = CreateConnection();
        connection.Open();
        var result = connection.QueryFirstOrDefault<T>(sql, parameters);
        connection.Close();
        return result;
    }

    public List<T> Select<T>(string sql, object parameters = null)
    {
        using var connection = CreateConnection();
        connection.Open();
        var result = connection.Query<T>(sql, parameters).ToList();
        connection.Close();
        return result;
    }

    public List<T> SelectFromSp<T>(string procedureName, object parameters = null)
    {
        using var connection = CreateConnection();
        connection.Open();
        var result = connection
            .Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure)
            .ToList();
        connection.Close();
        return result;
    }

    public (IDbConnection, SqlMapper.GridReader) SelectFromSpMultiple(string procedureName, object parameters)
    {
        var connection = CreateConnection();
        connection.Open();
        var reader = connection
            .QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure);

        return (connection, reader);
    }

    public async Task<IEnumerable<T>> SelectFromSpAsync<T>(string procedureName, object parameters = null)
    {
        using var connection = CreateConnection();
        return await connection
            .QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }

    public T SelectFromSpFirstOrDefault<T>(string procedureName, object parameters = null)
    {
        using var connection = CreateConnection();
        connection.Open();
        var result = connection
            .Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure)
            .FirstOrDefault();
        connection.Close();
        return result;
    }

    public int Execute(string sql, object parameters = null)
    {
        using var connection = CreateConnection();
        connection.Open();
        var result = connection.Execute(sql, parameters);
        connection.Close();
        return result;
    }

    public void ExecuteSp(string sql, object parameters = null)
    {
        using var connection = CreateConnection();
        connection.Open();
        connection.Query(sql, parameters, commandType: CommandType.StoredProcedure);
        connection.Close();
    }

    public int QuerySingle(string sql, object parameters = null)
    {
        using var connection = CreateConnection();
        connection.Open();
        var result = connection.QuerySingle<int>(sql, parameters);
        connection.Close();
        return result;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _connectionStringBuilder.Build();
        return new SqlConnection(connectionString);
    }
}