using System.Text;

namespace DemoExam.UIDesign.SignIn.Registration.CreateId;

internal struct ID
{
    private const int COUNT_OF_NUMBERS_IN_ID = 8;

    private static readonly StringBuilder _builderId = new StringBuilder();

    internal static long Create()
    {
        for (int count = 0; count < COUNT_OF_NUMBERS_IN_ID; count++)
            _builderId.Append(new Random().Next(1, 9));

        long id = Convert.ToInt64(_builderId.ToString());

        _builderId.Clear();

        return id;
    }
}