using System.Text;

namespace DemoExam.UIDesign.SignIn.Registration.CreateId;

internal struct ID
{
    private const int COUNT_OF_NUMBERS_IN_ID = 8;

    internal static long Create()
    {
        StringBuilder builderId = new StringBuilder();

        for (int count = 0; count < COUNT_OF_NUMBERS_IN_ID; count++)
            builderId.Append(new Random().Next(1, 9));

        long id = Convert.ToInt64(builderId.ToString());

        builderId.Clear();

        return id;
    }
}