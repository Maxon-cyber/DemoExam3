namespace AccessingDatabase.Internal.DatabaseManagement.DeserializeModels.ConnectionStringModels;

public class DatabaseModel
{
    public Dictionary<string, ConnectionStringModel> Database { get; internal set; }
}