using RPS_Oktober;

// game init
string[] title = File.ReadAllLines("../../../title.txt");
foreach (var line in title)
{
    Console.WriteLine(line);
}
Console.ReadKey();
Console.Clear();

// menu
Console.WriteLine("Do you want to play versus: ");
Console.WriteLine("1. Another player");
Console.WriteLine("2. A computer");

// player 1+2 creation
List<Player> players = new List<Player>();
string? choice = Console.ReadLine();
if (int.TryParse(choice, out int pick) && pick < 2)
{
    Console.Clear();
    if (pick == 1)
    {
        for (int i = 1; i <= 2; i++)
        {
            string name = string.Empty;
            Console.Write("Player " + i + " name: ");
            while (name.Length == 0)
            {
                name = Console.ReadLine() ?? string.Empty;
            }
            players.Add(new Player(name));
            Console.Clear();
        }

    }
}
else if (pick == 2)
{
    Console.Clear();
    addBot();
    for (int i = 1; i <= 1; i++)
    {
        //Console.Clear();
        string name = string.Empty;
        Console.Write("Player " + i + " name: ");
        while (name.Length == 0)
        {
            name = Console.ReadLine() ?? string.Empty;
        }
        players.Add(new Player(name));
    }
}

else
{
    Console.Clear();
    Console.WriteLine("Invalid input");
}
// Random Starting Player
Random random = new Random();
players.Sort((a, b) => random.Next(-1, 2));

// gamerounds
int round = 1;
bool hasWon = false;
while (!hasWon)
// for (int round = 1; round <= 3; round++)
{
    foreach (Player player in players)
    {
        if (player.name == "Bot")
        {
            Console.Clear();
            RoundInit(round);
            player.RandomHand();
        }
        else
        {
            Console.Clear();
            RoundInit(round);
            player.Hand();
        }
    }

    Console.Clear();
    RoundInit(round);

    foreach (Player player in players)
    {
        Console.WriteLine("Player " + player.name + " chose: " + player.Choice);
    }

    Console.WriteLine("Player " + players[0].name + " has ended the round with a " +
                      CalculateOutcome(players[0], players[1]));
    winnerCheck();
    Console.ReadKey();
    round++;
}

// outcome method
Outcome CalculateOutcome(Player p1, Player p2)
{
    switch (p1.Choice)
    {
        case Hands.Rock:
            switch (p2.Choice)
            {
                case Hands.Rock: return Outcome.Draw;
                case Hands.Paper: p2.score++; return Outcome.Loss;
                case Hands.Scissors:
                    p1.score++; return Outcome.Win;

            }
            break;
        case Hands.Paper:
            switch (p2.Choice)
            {
                case Hands.Rock:
                    p1.score++; return Outcome.Win;
                case Hands.Paper: return Outcome.Draw;
                case Hands.Scissors: p2.score++; return Outcome.Loss;
            }
            break;
        case Hands.Scissors:
            switch (p2.Choice)
            {
                case Hands.Rock: p2.score++; return Outcome.Loss;
                case Hands.Paper: p1.score++; return Outcome.Win;
                case Hands.Scissors: return Outcome.Draw;
            }
            break;
    }
    throw new InvalidOperationException();
}

void RoundInit(int round)
{
    Console.WriteLine("***** Round " + round+ " ***** ");
    foreach (var player in players)
    {
        Console.WriteLine(player.name + " -- " + player.score + " points");
    }
}

void winnerCheck()
{

    if (players[0].score == 2)
    {
        Console.WriteLine(players[0].name + " has won the game!");
        hasWon = true;
    }
    else if (players[1].score == 2)
    {
        Console.WriteLine(players[1].name + " has won the game!");
        hasWon = true;
    }
}
void addBot()
{
    string botName = "Bot";
    players.Add(new Player(botName));
    Console.WriteLine("Bot player added");
}
