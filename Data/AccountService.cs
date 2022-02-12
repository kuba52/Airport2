using System.Data;
using Dapper;

namespace Conference.Data;

public class AccountService
{
    private readonly IDbConnection _dbConnection;

    public AccountService(IDbConnection dbConnection) => 
        _dbConnection = dbConnection;

    public IReadOnlyList<Account> GetAccounts() =>
        _dbConnection.Query<Account>("SELECT id AS aaccountId, name, surname FROM account").ToList();

    
    public int TryLogin(CreateAccount model) =>
        _dbConnection.Query<int>($"SELECT COALESCE(id, 0) FROM account WHERE name = @n AND surname = @s", new {n = model.Name, s = model.Surname}).First(); 

    public UserInfo GetAccount(int id) =>
        _dbConnection.Query<UserInfo>($"SELECT id AS userId, name, surname, is_staff AS isStaff FROM account WHERE id = @i", new {i = id}).First();

    public void CreateAccount(CreateAccount model)
    {
        if (model.Name is null || model.Surname is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        _dbConnection.Execute(
            $"INSERT INTO account (name, surname, is_staff) VALUES (@Name, @Surname, @isStaff);",
            new { model.Name, model.Surname, model.isStaff });
       
    }
} 