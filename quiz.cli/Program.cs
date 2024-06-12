using Quiz.Core;
using System.Text;

Game testGame = new Game("Testspiel zum Testen");

Player player1 = new Player(1,"Herbert");
Player player2 = new Player(2, "Manfred");
Player player3 = new Player(3, "Rene");
Player player4 = new Player(4, "Thomas");


IQuestionProvider staticProvider = new StaticQuestions();
IQuestionProvider NatureQuestionProvider = new NatureQuestionProvider();

testGame.AddRound(NatureQuestionProvider    , true, 5);

testGame.AddPlayerToLatestRound(player1);
testGame.AddPlayerToLatestRound(player2);
testGame.AddPlayerToLatestRound(player3);
testGame.AddPlayerToLatestRound(player4);


GameRound runde = testGame.GetLatestRound();
runde.Start();

Console.WriteLine("All players in this round:");
foreach (Player p in runde.Players)
{
    Console.WriteLine(p.Name);
}



while (runde.MoveNext())
{
    // start game for this player

    // get current play
    Play currentPlay = runde.Current;

    // start play
    currentPlay.Start();


    Console.WriteLine($"Spieler: {currentPlay.Player.Name}");

    while (runde.MoveNext())
    {
        // start game for this player

        // get current play
        Play currentPlaying = (Play)runde.Current;

        // start play
        currentPlay.Start();


        Console.WriteLine($"Spieler: {currentPlay.Player.Name}");

        while (currentPlay.IsActive)
        {

            while (currentPlay.MoveNext())
            {

                Question question = currentPlay.Current;


                Console.WriteLine("Frage: " + question.Text);

                int num = 0;
                foreach (IAnswer a in question.Answers)
                {
                    Console.WriteLine($"{num}. {a.Text}");
                    num++;
                }

                Console.Write("Auswahl: ");
                int input = Convert.ToInt32(Console.ReadLine());

                question.Answers[input].IsChecked = true;

                var res = currentPlay.ValidateCurrentQuestion();

                if (!res)
                {
                    Console.WriteLine("Leider war das eine falsche Antwort");
                }
                else
                {
                    Console.WriteLine("Gratulation!");
                }

                Console.WriteLine();
            }

        }

    }
}


