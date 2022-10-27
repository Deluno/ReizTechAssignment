Dictionary<Error, string> errors = new();

int hours, minutes;

do
{
    errors.Clear();

    Console.Write("Enter hours: ");
    hours = ParseInput(
        Console.ReadLine() ?? "",
        parsedValue => parsedValue <= 12,
        () => errors.Add(Error.ParseFiled, "Hours number should be an integer."),
        () => errors.Add(Error.NumberOutOfRange, "Hours should be in range from 0 to 12")
    );
    if (errors.Count > 0) ShowErrors(errors);
} while (errors.Count > 0);

do
{
    errors.Clear();

    Console.Write("Enter minutes: ");
    minutes = ParseInput(
        Console.ReadLine() ?? "",
        parsedValue => parsedValue <= 60,
        () => errors.Add(Error.ParseFiled, "Minutes number should be an integer."),
        () => errors.Add(Error.NumberOutOfRange, "Minutes should be in range from 0 to 60.")
    );
    if (errors.Count > 0) ShowErrors(errors);
} while (errors.Count > 0);

var hoursAngle = 360.0 / 12 * hours;
var minutesAngle = 360.0 / 60 * minutes;
var angleDifference = Math.Abs(hoursAngle - minutesAngle);

var lesserAngle = angleDifference > 180 ? 360 - angleDifference : angleDifference;
Console.WriteLine("Lesser angle between hours arrow and minutes arrow: {0}", lesserAngle);


int ParseInput(string input, Func<int, bool> condition, Action onParseError, Action onConditionError)
{
    if (int.TryParse(input, out var result))
    {
        if (!condition(result)) onConditionError();
        return result;
    }

    onParseError();

    return 0;
}

void ShowErrors(Dictionary<Error, string> dict)
{
    foreach (var message in dict.Values) Console.WriteLine(message);
}

internal enum Error
{
    ParseFiled,
    NumberOutOfRange
}