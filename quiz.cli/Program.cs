using Quiz.Core;

Game testGame = new Game("Testspiel zum Testen");

Player player1 = new Player("Herbert");
Player player2 = new Player("Manfred");
Player player3 = new Player("Rene");
Player player4 = new Player("Thomas");


IQuestionProvider staticProvider = new StaticQuestions();

testGame.AddRound(staticProvider, true, 5);
