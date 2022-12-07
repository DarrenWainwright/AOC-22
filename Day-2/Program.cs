// AOC '22 Day 2

// Part 1 - Total score based on the strategy
// Strategy:
//  A/X = Rock = 1pt
//  B/Y = Paper = 2pt
//  C/Z = Scissors = 3pt
//  win = 6pt
//  draw = 3pt

int totalScore = 0;
var scores = new (string MyPlay, int Points, string TheirPlay, int AdditionalPoints)[] {
    ("X", 1, "A", 3),
    ("X", 1, "B", 0),
    ("X", 1, "C", 6),

    ("Y", 2, "A", 6),
    ("Y", 2, "B", 3),
    ("Y", 2, "C", 0),

    ("Z", 3, "A", 0),
    ("Z", 3, "B", 6),
    ("Z", 3, "C", 3),
};


File.ReadAllLines("input.txt")
                .Select((line) => new { them = line.Substring(0, 1), me = line.Substring(2, 1) })
                .ToList()
                .ForEach(play =>
                {
                    var roundScore = scores.First(s => s.MyPlay == play.me && s.TheirPlay == play.them);
                    totalScore += (roundScore.Points + roundScore.AdditionalPoints);
                });

Console.WriteLine($"Total points scored {totalScore}");
