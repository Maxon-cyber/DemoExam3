using AccessingDatabase.Internal.DatabaseManagement.NotRelationalDb.Databases;
using AccessingDatabase.EnumerationOfDatabases;
using AccessingDatabase.Internal.DatabaseManagement.NotRelationalDb;
using AccessingDatabase.Internal.DatabaseManagement.RelationalDb;
using AccessingDatabase.Internal.DatabaseManagement.RelationalDb.Databases;

namespace AccessingDatabase;

public static class Databases
{
    public static RelationalDatabase SelectRelationalDatabase(CurrentRelationalDatabase database)
        => database switch
        {
            CurrentRelationalDatabase.MSSQLDatabase => MSSQLDatabase.GetInstance()
        };
    
    public static NotRelationalDatabase SelectNotRelationalDatabase(CurrentNotRelationalDatabase database)
        => database switch
        {
            CurrentNotRelationalDatabase.MongoDatabase => new MongoDatabase()
        };
}