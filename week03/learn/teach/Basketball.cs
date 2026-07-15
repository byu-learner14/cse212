using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var playerPoints = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // Skip header row

        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (playerPoints.ContainsKey(playerId))
                playerPoints[playerId] += points;
            else
                playerPoints[playerId] = points;
        }

        // Sort by points descending and take top 10
        var topPlayers = playerPoints
            .OrderByDescending(p => p.Value)
            .Take(10);

        foreach (var player in topPlayers)
        {
            Console.WriteLine($"{player.Key}: {player.Value} points");
        }
    }
}