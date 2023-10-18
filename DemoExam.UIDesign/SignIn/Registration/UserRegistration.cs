using AccessingDatabase;
using AccessingDatabase.EnumerationOfDatabases;
using DemoExam.ModelClasses.User;
using DemoExam.UIDesign.SQLQueries;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DemoExam.UIDesign.SignIn.Registration;

internal class UserRegistration
{
    private const int NUMBER_OF_CHANGES_IN_DATABASE = 1;
    private const string DEFAULT_ROLE = "User";
    private const string DEFAULT_DESCRIPTION = "Buys goods";

    internal UserModel NewUser { get; private set; }
    internal bool Registered { get; private set; } = false;
    internal Exception? RegistrationException { get; private set; }

    internal UserRegistration() { }

    internal async Task RegistrationAsync(string name, string login, string password)
    {
        try
        {
            int result = await Databases
                                   .SelectRelationalDatabase(CurrentRelationalDatabase.MSSQLDatabase)
                                   .ExecuteNonQueryAsync(
                                            StoredProcedure.InsertUser,
                                            NewUser = new UserModel()
                                            {
                                                Name = name,
                                                Role = DEFAULT_ROLE,
                                                Login = login,
                                                Password = password,
                                                Description = DEFAULT_DESCRIPTION
                                            },
                                            CommandType.StoredProcedure);

            if (result == NUMBER_OF_CHANGES_IN_DATABASE)
                Registered = true;
            else
                NewUser = new UserModel();
        }
        catch (SqlException ex)
        {
            RegistrationException = ex;
        }
    }
}