namespace Website.Shared.Models;

public interface IDatabaseObject
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public interface IDTO
{
    public string Name { get; set; }
}