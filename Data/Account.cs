namespace Conference.Data;

public class Account
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string Surname { get; init; }

    public string DisplayName => $"{Surname}, {Name.First()}.";

    public Account(int accountId, string name, string surname) =>
        (Id, Name, Surname) = (accountId, name, surname);
}