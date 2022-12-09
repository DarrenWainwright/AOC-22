// AOC '22 Day 2

// Part 1 Mapping
//      theirPlay        : Shape they threw
//      strategyToPlay   : Shape I have to throw. X=Rock, Y=Paper, Z=Scissors
//      shapePoints      : Points awarded based on shape I threw. Rock=1, Paper=2, Scissors=3
//      roundPoints      : Points awarded based on result. Win=6, Draw=3, Lose=0
var scores = new (string theirPlay, string strategyToPlay, int shapePoints, int roundPoints)[]
{
    ("A", "X", 1, 3),
    ("B", "X", 1,0),
    ("C", "X", 1, 6),

    ("A", "Y",2, 6),
    ("B", "Y",2, 3),
    ("C", "Y",2, 0),

    ("A",  "Z",3, 0),
    ("B",  "Z",3, 6),
    ("C",  "Z",3, 3),

};

Console.WriteLine($"Part 1: Total score calculated {CalculateScore(scores)} ");

// Part 2 Mapping
//      theirPlay        : Shape they threw
//      strategyToPlay   : Result I have to achieve: X=Lose, Y=Draw, Z=Win
//      shapePoints      : Points awarded based on shape I have to throw to achieve the result. Rock=1, Paper=2, Scissors=3
//      roundPoints      : Points awarded based on result. Win=6, Draw=3, Lose=0
scores = new (string theirPlay, string strategyToPlay, int shapePoints, int roundPoints)[] {

    ( "A", "X",3,0),// 1, 0 ), //threw rock. o have to lose. i throw sciz, 6 and 0
    ( "A", "Y", 1,3 ),
    ( "A", "Z", 2,6 ),

    ( "B", "X", 1,0),
    ( "B", "Y", 2, 3 ),
    ( "B", "Z",3,6 ),

    ( "C",  "X",2,0 ),
    ( "C",  "Y",3,3 ),
    ( "C",  "Z",1,6 )

};

Console.WriteLine($"Part 2: Total score was actually {CalculateScore(scores)} ");




/// <summary>
/// Calculates the score using the provided mapping data
/// </summary>
/// <returns></returns>
int CalculateScore((string theirPlay, string strategyToPlay, int shapePoints, int roundPoints)[] map)
{
    int totalScore = 0;
    File.ReadAllLines("input.txt")
                        .Select((line) => new { them = line.Substring(0, 1), me = line.Substring(2, 1) })
                        .ToList()
                        .ForEach(play =>
                        {
                            var roundScore = scores.First(s => s.strategyToPlay == play.me && s.theirPlay == play.them);
                            totalScore += (roundScore.shapePoints + roundScore.roundPoints);
                        });
    return totalScore;
}

