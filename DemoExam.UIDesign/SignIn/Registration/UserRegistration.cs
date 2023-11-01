using AccessingDatabase;
using AccessingDatabase.EnumerationOfDatabases;
using DemoExam.ModelClasses.User;
using DemoExam.UIDesign.SignIn.Registration.CreateId;
using DemoExam.UIDesign.SQLQueries;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DemoExam.UIDesign.SignIn.Registration;

internal class UserRegistration
{
    private const int NUMBER_OF_CHANGES_IN_DATABASE = 1;
    private const int DEFAULT_ROLE = 1;
    private const string DEFAULT_DESCRIPTION = "Buys goods";

    internal UserRegistration() { }

    internal async Task<bool> RegistrationAsync(string name, string login, string password)
    {
        int result = 0;

        try
        {
            result = await Databases
                                   .SelectRelationalDatabase(CurrentRelationalDatabase.MSSQLDatabase)
                                   .ExecuteNonQueryAsync(
                                            StoredProcedure.InsertUser,
                                            new UserModel()
                                            {
                                                Id = ID.Create(),
                                                DateOfRegistartion = DateTime.Now,
                                                FirstName = name,
                                                Role = DEFAULT_ROLE,
                                                Login = login,
                                                Password = password,
                                                Description = DEFAULT_DESCRIPTION
                                            },
                                            CommandType.StoredProcedure);
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.ToString());
        }

        return result == NUMBER_OF_CHANGES_IN_DATABASE;
    }
}