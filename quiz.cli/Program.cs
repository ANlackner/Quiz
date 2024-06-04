using Quiz.Core;
using System.Text;

Game testGame = new Game("Testspiel zum Testen");

Player player1 = new Player(1,"Herbert");
Player player2 = new Player(2, "Manfred");
Player player3 = new Player(3, "Rene");
Player player4 = new Player(4, "Thomas");


IQuestionProvider staticProvider = new StaticQuestions();
IQuestionProvider NatureQuestionProvider = new NatureQuestionProvider();

testGame.AddRound(NatureQuestionProvider, true, 5);

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


public class NatureQuestionProvider : IQuestionProvider
{
    public List<Question> GetQuestions(int num)
    {
        Random _random = new Random();
        _random.Next(0, 4);

        List<Question> _questions = new List<Question>();

        Question q1 = new("Was ist das größte Landtier?");
        q1.AddAnswer(new Answer("Elefant", true));
        q1.AddAnswer(new Answer("Löwe"));
        q1.AddAnswer(new Answer("Giraffe"));
        q1.AddAnswer(new Answer("Nilpferd"));

        Question q2 = new("Welcher Baum ist der höchste der Welt?");
        q2.AddAnswer(new Answer("Küstenmammutbaum", true));
        q2.AddAnswer(new Answer("Eiche"));
        q2.AddAnswer(new Answer("Tanne"));
        q2.AddAnswer(new Answer("Ahorn"));

        Question q3 = new("Wie viele Kontinente gibt es?");
        q3.AddAnswer(new Answer("7", true));
        q3.AddAnswer(new Answer("5"));
        q3.AddAnswer(new Answer("6"));
        q3.AddAnswer(new Answer("8"));

        Question q4 = new("Welcher Planet ist der größte in unserem Sonnensystem?");
        q4.AddAnswer(new Answer("Jupiter", true));
        q4.AddAnswer(new Answer("Saturn"));
        q4.AddAnswer(new Answer("Neptun"));
        q4.AddAnswer(new Answer("Mars"));

        Question q5 = new("Wie nennt man das Studium von Pflanzen?");
        q5.AddAnswer(new Answer("Botanik", true));
        q5.AddAnswer(new Answer("Zoologie"));
        q5.AddAnswer(new Answer("Geologie"));
        q5.AddAnswer(new Answer("Astronomie"));

        Question q6 = new("Welche Meerestierart ist das größte?");
        q6.AddAnswer(new Answer("Blauwal", true));
        q6.AddAnswer(new Answer("Weißer Hai"));
        q6.AddAnswer(new Answer("Krake"));
        q6.AddAnswer(new Answer("Delfin"));

        Question q7 = new("Welche Pflanze wird als 'Lunge der Erde' bezeichnet?");
        q7.AddAnswer(new Answer("Amazonas-Regenwald", true));
        q7.AddAnswer(new Answer("Tropischer Regenwald"));
        q7.AddAnswer(new Answer("Borealer Wald"));
        q7.AddAnswer(new Answer("Savanne"));

        Question q8 = new("Welches ist das schnellste Landtier?");
        q8.AddAnswer(new Answer("Gepard", true));
        q8.AddAnswer(new Answer("Leopard"));
        q8.AddAnswer(new Answer("Tiger"));
        q8.AddAnswer(new Answer("Antilope"));

        Question q9 = new("Welches ist das kleinste Vogel der Welt?");
        q9.AddAnswer(new Answer("Bienenelfe", true));
        q9.AddAnswer(new Answer("Spatz"));
        q9.AddAnswer(new Answer("Kolibri"));
        q9.AddAnswer(new Answer("Finken"));

        Question q10 = new("Wie viele Planeten hat unser Sonnensystem?");
        q10.AddAnswer(new Answer("8", true));
        q10.AddAnswer(new Answer("9"));
        q10.AddAnswer(new Answer("7"));
        q10.AddAnswer(new Answer("10"));

        Question q11 = new("Welche Tiergruppe hat die meisten Arten?");
        q11.AddAnswer(new Answer("Insekten", true));
        q11.AddAnswer(new Answer("Vögel"));
        q11.AddAnswer(new Answer("Fische"));
        q11.AddAnswer(new Answer("Säugetiere"));

        Question q12 = new("Welcher Fluss ist der längste der Welt?");
        q12.AddAnswer(new Answer("Nil", true));
        q12.AddAnswer(new Answer("Amazonas"));
        q12.AddAnswer(new Answer("Yangtze"));
        q12.AddAnswer(new Answer("Mississippi"));

        Question q13 = new("Welcher Vogel kann rückwärts fliegen?");
        q13.AddAnswer(new Answer("Kolibri", true));
        q13.AddAnswer(new Answer("Adler"));
        q13.AddAnswer(new Answer("Spatz"));
        q13.AddAnswer(new Answer("Papagei"));

        Question q14 = new("Wie viele Erdsatelliten gibt es?");
        q14.AddAnswer(new Answer("1", true));
        q14.AddAnswer(new Answer("2"));
        q14.AddAnswer(new Answer("0"));
        q14.AddAnswer(new Answer("3"));

        Question q15 = new("Welches Tier ist bekannt für seine Tarnung?");
        q15.AddAnswer(new Answer("Chamäleon", true));
        q15.AddAnswer(new Answer("Zebra"));
        q15.AddAnswer(new Answer("Eisbär"));
        q15.AddAnswer(new Answer("Elefant"));

        Question q16 = new("Wie hoch ist der Mount Everest?");
        q16.AddAnswer(new Answer("8.848 Meter", true));
        q16.AddAnswer(new Answer("7.848 Meter"));
        q16.AddAnswer(new Answer("9.848 Meter"));
        q16.AddAnswer(new Answer("6.848 Meter"));

        Question q17 = new("Welche Substanz ist die häufigste in der Erdkruste?");
        q17.AddAnswer(new Answer("Sauerstoff", true));
        q17.AddAnswer(new Answer("Wasserstoff"));
        q17.AddAnswer(new Answer("Kohlenstoff"));
        q17.AddAnswer(new Answer("Stickstoff"));

        Question q18 = new("Welches Säugetier kann fliegen?");
        q18.AddAnswer(new Answer("Fledermaus", true));
        q18.AddAnswer(new Answer("Flughörnchen"));
        q18.AddAnswer(new Answer("Känguru"));
        q18.AddAnswer(new Answer("Koala"));

        Question q19 = new("Welche Tierart legt die größten Eier?");
        q19.AddAnswer(new Answer("Strauß", true));
        q19.AddAnswer(new Answer("Adler"));
        q19.AddAnswer(new Answer("Pinguin"));
        q19.AddAnswer(new Answer("Schildkröte"));

        Question q20 = new("Welches ist das tiefste bekannte Teil des Ozeans?");
        q20.AddAnswer(new Answer("Marianengraben", true));
        q20.AddAnswer(new Answer("Java-Graben"));
        q20.AddAnswer(new Answer("Puerto-Rico-Graben"));
        q20.AddAnswer(new Answer("Peru-Chile-Graben"));


        Question q21 = new("Wie lange dauert ein Jahr auf dem Planeten Jupiter?");
        q21.AddAnswer(new Answer("12 Erdjahre", true));
        q21.AddAnswer(new Answer("1 Erdjahr"));
        q21.AddAnswer(new Answer("5 Erdjahre"));
        q21.AddAnswer(new Answer("20 Erdjahre"));

        Question q22 = new("Welches Element hat das chemische Symbol 'O'?");
        q22.AddAnswer(new Answer("Sauerstoff", true));
        q22.AddAnswer(new Answer("Gold"));
        q22.AddAnswer(new Answer("Silber"));
        q22.AddAnswer(new Answer("Osmium"));

        Question q23 = new("Wie viele Beine hat ein Insekt?");
        q23.AddAnswer(new Answer("6", true));
        q23.AddAnswer(new Answer("8"));
        q23.AddAnswer(new Answer("4"));
        q23.AddAnswer(new Answer("10"));

        Question q24 = new("Welche Energiequelle ist erneuerbar?");
        q24.AddAnswer(new Answer("Sonnenenergie", true));
        q24.AddAnswer(new Answer("Kohle"));
        q24.AddAnswer(new Answer("Erdöl"));
        q24.AddAnswer(new Answer("Erdgas"));

        Question q25 = new("Welches Tier ist bekannt für seine Fähigkeit, Netze zu spinnen?");
        q25.AddAnswer(new Answer("Spinne", true));
        q25.AddAnswer(new Answer("Schmetterling"));
        q25.AddAnswer(new Answer("Biene"));
        q25.AddAnswer(new Answer("Ameise"));

        Question q26 = new("Welcher Planet ist der sonnennächste?");
        q26.AddAnswer(new Answer("Merkur", true));
        q26.AddAnswer(new Answer("Venus"));
        q26.AddAnswer(new Answer("Erde"));
        q26.AddAnswer(new Answer("Mars"));

        Question q27 = new("Was ist das kleinste Knochen im menschlichen Körper?");
        q27.AddAnswer(new Answer("Steigbügel", true));
        q27.AddAnswer(new Answer("Schlüsselbein"));
        q27.AddAnswer(new Answer("Oberschenkelknochen"));
        q27.AddAnswer(new Answer("Elle"));

        Question q28 = new("Welches Gas macht den größten Teil der Erdatmosphäre aus?");
        q28.AddAnswer(new Answer("Stickstoff", true));
        q28.AddAnswer(new Answer("Sauerstoff"));
        q28.AddAnswer(new Answer("Kohlendioxid"));
        q28.AddAnswer(new Answer("Argon"));

        Question q29 = new("Welches ist das einzige Säugetier, das fliegen kann?");
        q29.AddAnswer(new Answer("Fledermaus", true));
        q29.AddAnswer(new Answer("Flughörnchen"));
        q29.AddAnswer(new Answer("Kolibri"));
        q29.AddAnswer(new Answer("Papagei"));

        Question q30 = new("Wie nennt man das Phänomen, wenn die Erde die Sonne umkreist?");
        q30.AddAnswer(new Answer("Revolution", true));
        q30.AddAnswer(new Answer("Rotation"));
        q30.AddAnswer(new Answer("Kreation"));
        q30.AddAnswer(new Answer("Konvektion"));

        Question q31 = new("Welcher Vogel hat die größte Flügelspannweite?");
        q31.AddAnswer(new Answer("Wand albatros", true));
        q31.AddAnswer(new Answer("Kondor"));
        q31.AddAnswer(new Answer("Adler"));
        q31.AddAnswer(new Answer("Geier"));

        Question q32 = new("Was ist die Hauptquelle des Sauerstoffs auf der Erde?");
        q32.AddAnswer(new Answer("Pflanzen", true));
        q32.AddAnswer(new Answer("Tiere"));
        q32.AddAnswer(new Answer("Menschen"));
        q32.AddAnswer(new Answer("Ozeane"));

        Question q33 = new("Welche Pflanze ist bekannt für ihre fleischfressenden Eigenschaften?");
        q33.AddAnswer(new Answer("Venusfliegenfalle", true));
        q33.AddAnswer(new Answer("Löwenzahn"));
        q33.AddAnswer(new Answer("Gänseblümchen"));
        q33.AddAnswer(new Answer("Tulpe"));

        Question q34 = new("Welcher Planet ist für seine Ringe bekannt?");
        q34.AddAnswer(new Answer("Saturn", true));
        q34.AddAnswer(new Answer("Jupiter"));
        q34.AddAnswer(new Answer("Neptun"));
        q34.AddAnswer(new Answer("Uranus"));

        Question q35 = new("Wie viele Herzen hat ein Oktopus?");
        q35.AddAnswer(new Answer("3", true));
        q35.AddAnswer(new Answer("1"));
        q35.AddAnswer(new Answer("2"));
        q35.AddAnswer(new Answer("4"));

        Question q36 = new("Welches Säugetier hat die meisten Zähne?");
        q36.AddAnswer(new Answer("Delfin", true));
        q36.AddAnswer(new Answer("Hund"));
        q36.AddAnswer(new Answer("Elefant"));
        q36.AddAnswer(new Answer("Nilpferd"));

        Question q37 = new("Wie viele Planeten hat unser Sonnensystem?");
        q37.AddAnswer(new Answer("8", true));
        q37.AddAnswer(new Answer("7"));
        q37.AddAnswer(new Answer("9"));
        q37.AddAnswer(new Answer("10"));

        Question q38 = new("Welche Wüstenpflanze speichert Wasser in ihren Blättern?");
        q38.AddAnswer(new Answer("Kaktus", true));
        q38.AddAnswer(new Answer("Rosmarin"));
        q38.AddAnswer(new Answer("Lavendel"));
        q38.AddAnswer(new Answer("Minze"));

        Question q39 = new("Welche Gattung gehört zu den größten Meeresbewohnern?");
        q39.AddAnswer(new Answer("Wal", true));
        q39.AddAnswer(new Answer("Hai"));
        q39.AddAnswer(new Answer("Oktopus"));
        q39.AddAnswer(new Answer("Krake"));

        Question q40 = new("Welches Tier wird als 'König der Tiere' bezeichnet?");
        q40.AddAnswer(new Answer("Löwe", true));
        q40.AddAnswer(new Answer("Tiger"));
        q40.AddAnswer(new Answer("Elefant"));
        q40.AddAnswer(new Answer("Adler"));

        Question q41 = new("Wie viele Zähne hat ein erwachsener Mensch normalerweise?");
        q41.AddAnswer(new Answer("32", true));
        q41.AddAnswer(new Answer("30"));
        q41.AddAnswer(new Answer("28"));
        q41.AddAnswer(new Answer("34"));

        Question q42 = new("Welcher Planet wird als 'Roter Planet' bezeichnet?");
        q42.AddAnswer(new Answer("Mars", true));
        q42.AddAnswer(new Answer("Venus"));
        q42.AddAnswer(new Answer("Jupiter"));
        q42.AddAnswer(new Answer("Saturn"));

        Question q43 = new("Welche Pflanze wird für die Herstellung von Papier verwendet?");
        q43.AddAnswer(new Answer("Bambus", true));
        q43.AddAnswer(new Answer("Ahorn"));
        q43.AddAnswer(new Answer("Buche"));
        q43.AddAnswer(new Answer("Kiefer"));

        Question q44 = new("Welcher Vogel kann am längsten ohne Pause fliegen?");
        q44.AddAnswer(new Answer("Alpenstrandläufer", true));
        q44.AddAnswer(new Answer("Mauersegler"));
        q44.AddAnswer(new Answer("Storch"));
        q44.AddAnswer(new Answer("Schwalbe"));

        Question q45 = new("Wie viele Zeitzonen gibt es auf der Erde?");
        q45.AddAnswer(new Answer("24", true));
        q45.AddAnswer(new Answer("12"));
        q45.AddAnswer(new Answer("18"));
        q45.AddAnswer(new Answer("36"));

        Question q46 = new("Welches ist das giftigste Tier der Welt?");
        q46.AddAnswer(new Answer("Schreckliche Seewespe", true));
        q46.AddAnswer(new Answer("Königskobra"));
        q46.AddAnswer(new Answer("Pfeilgiftfrosch"));
        q46.AddAnswer(new Answer("Schwarze Witwe"));

        Question q47 = new("Welcher ist der höchste aktive Vulkan der Welt?");
        q47.AddAnswer(new Answer("Ojos del Salado", true));
        q47.AddAnswer(new Answer("Mount Etna"));
        q47.AddAnswer(new Answer("Kilauea"));
        q47.AddAnswer(new Answer("Mount St. Helens"));

        Question q48 = new("Welcher Kontinent hat die größte Wüste der Welt?");
        q48.AddAnswer(new Answer("Antarktika", true));
        q48.AddAnswer(new Answer("Afrika"));
        q48.AddAnswer(new Answer("Asien"));
        q48.AddAnswer(new Answer("Australien"));

        Question q49 = new("Welches Säugetier hat den längsten Lebenszyklus?");
        q49.AddAnswer(new Answer("Grönlandwal", true));
        q49.AddAnswer(new Answer("Elefant"));
        q49.AddAnswer(new Answer("Mensch"));
        q49.AddAnswer(new Answer("Orang-Utan"));

        Question q50 = new("Welche Art von Wal hat einen markanten weißen Bauch?");
        q50.AddAnswer(new Answer("Schwertwal", true));
        q50.AddAnswer(new Answer("Blauwal"));
        q50.AddAnswer(new Answer("Buckelwal"));
        q50.AddAnswer(new Answer("Grauwal"));

        Question q51 = new("Wie viele Flossen hat ein Fisch normalerweise?");
        q51.AddAnswer(new Answer("6", true));
        q51.AddAnswer(new Answer("4"));
        q51.AddAnswer(new Answer("2"));
        q51.AddAnswer(new Answer("8"));

        Question q52 = new("Welche Pflanze wird als Heilpflanze gegen Verbrennungen eingesetzt?");
        q52.AddAnswer(new Answer("Aloe Vera", true));
        q52.AddAnswer(new Answer("Lavendel"));
        q52.AddAnswer(new Answer("Kamille"));
        q52.AddAnswer(new Answer("Salbei"));

        Question q53 = new("Welcher Vogel hat die Fähigkeit, menschliche Sprache zu imitieren?");
        q53.AddAnswer(new Answer("Papagei", true));
        q53.AddAnswer(new Answer("Adler"));
        q53.AddAnswer(new Answer("Taube"));
        q53.AddAnswer(new Answer("Krähe"));

        Question q54 = new("Welche Farbe hat das Blut von Hummern?");
        q54.AddAnswer(new Answer("Blau", true));
        q54.AddAnswer(new Answer("Rot"));
        q54.AddAnswer(new Answer("Grün"));
        q54.AddAnswer(new Answer("Gelb"));

        Question q55 = new("Welcher Kontinent hat die meisten aktiven Vulkane?");
        q55.AddAnswer(new Answer("Asien", true));
        q55.AddAnswer(new Answer("Afrika"));
        q55.AddAnswer(new Answer("Südamerika"));
        q55.AddAnswer(new Answer("Nordamerika"));

        Question q56 = new("Welches Tier wird als 'Mensch des Waldes' bezeichnet?");
        q56.AddAnswer(new Answer("Orang-Utan", true));
        q56.AddAnswer(new Answer("Gorilla"));
        q56.AddAnswer(new Answer("Schimpanse"));
        q56.AddAnswer(new Answer("Pavian"));

        Question q57 = new("Welches Metall ist flüssig bei Raumtemperatur?");
        q57.AddAnswer(new Answer("Quecksilber", true));
        q57.AddAnswer(new Answer("Eisen"));
        q57.AddAnswer(new Answer("Kupfer"));
        q57.AddAnswer(new Answer("Zink"));

        Question q58 = new("Welche Farbe hat das Gefieder eines Flamingos?");
        q58.AddAnswer(new Answer("Rosa", true));
        q58.AddAnswer(new Answer("Blau"));
        q58.AddAnswer(new Answer("Gelb"));
        q58.AddAnswer(new Answer("Grün"));

        Question q59 = new("Welcher Kontinent ist der kälteste?");
        q59.AddAnswer(new Answer("Antarktika", true));
        q59.AddAnswer(new Answer("Asien"));
        q59.AddAnswer(new Answer("Europa"));
        q59.AddAnswer(new Answer("Nordamerika"));

        Question q60 = new("Welche Säugetierart hat den größten Nachwuchs?");
        q60.AddAnswer(new Answer("Fledermaus", true));
        q60.AddAnswer(new Answer("Elefant"));
        q60.AddAnswer(new Answer("Giraffe"));
        q60.AddAnswer(new Answer("Nashorn"));

        Question q61 = new("Welches Insekt kann seine Farbe ändern, um sich zu tarnen?");
        q61.AddAnswer(new Answer("Heuschrecke", true));
        q61.AddAnswer(new Answer("Biene"));
        q61.AddAnswer(new Answer("Marienkäfer"));
        q61.AddAnswer(new Answer("Libelle"));

        Question q62 = new("Welcher Planet ist der kleinste in unserem Sonnensystem?");
        q62.AddAnswer(new Answer("Merkur", true));
        q62.AddAnswer(new Answer("Mars"));
        q62.AddAnswer(new Answer("Venus"));
        q62.AddAnswer(new Answer("Neptun"));

        Question q63 = new("Welches Tier ist bekannt für seine langen Wanderungen?");
        q63.AddAnswer(new Answer("Gnu", true));
        q63.AddAnswer(new Answer("Elefant"));
        q63.AddAnswer(new Answer("Tiger"));
        q63.AddAnswer(new Answer("Wolf"));

        Question q64 = new("Welche Substanz gibt Pflanzen ihre grüne Farbe?");
        q64.AddAnswer(new Answer("Chlorophyll", true));
        q64.AddAnswer(new Answer("Carotin"));
        q64.AddAnswer(new Answer("Xanthophyll"));
        q64.AddAnswer(new Answer("Anthocyanin"));

        Question q65 = new("Welches Tier kann am längsten ohne Wasser überleben?");
        q65.AddAnswer(new Answer("Kamel", true));
        q65.AddAnswer(new Answer("Elefant"));
        q65.AddAnswer(new Answer("Pferd"));
        q65.AddAnswer(new Answer("Löwe"));

        Question q66 = new("Welcher Vogel legt die kleinsten Eier?");
        q66.AddAnswer(new Answer("Kolibri", true));
        q66.AddAnswer(new Answer("Spatz"));
        q66.AddAnswer(new Answer("Taube"));
        q66.AddAnswer(new Answer("Elster"));

        Question q67 = new("Welcher Vogel ist für seinen melodischen Gesang bekannt?");
        q67.AddAnswer(new Answer("Nachtigall", true));
        q67.AddAnswer(new Answer("Adler"));
        q67.AddAnswer(new Answer("Rabe"));
        q67.AddAnswer(new Answer("Krähe"));

        Question q68 = new("Welches Säugetier lebt am längsten?");
        q68.AddAnswer(new Answer("Grönlandwal", true));
        q68.AddAnswer(new Answer("Elefant"));
        q68.AddAnswer(new Answer("Mensch"));
        q68.AddAnswer(new Answer("Gorilla"));

        Question q69 = new("Welche Pflanze wird oft als Weihnachtsbaum verwendet?");
        q69.AddAnswer(new Answer("Tanne", true));
        q69.AddAnswer(new Answer("Ahorn"));
        q69.AddAnswer(new Answer("Buche"));
        q69.AddAnswer(new Answer("Kiefer"));

        Question q70 = new("Welche Pflanze produziert die meisten der weltweit konsumierten Früchte?");
        q70.AddAnswer(new Answer("Banane", true));
        q70.AddAnswer(new Answer("Apfel"));
        q70.AddAnswer(new Answer("Orange"));
        q70.AddAnswer(new Answer("Mango"));

        Question q71 = new("Welcher Planet hat den größten Mond?");
        q71.AddAnswer(new Answer("Jupiter", true));
        q71.AddAnswer(new Answer("Saturn"));
        q71.AddAnswer(new Answer("Neptun"));
        q71.AddAnswer(new Answer("Uranus"));

        Question q72 = new("Welches Tier ist für seine Streifen bekannt?");
        q72.AddAnswer(new Answer("Zebra", true));
        q72.AddAnswer(new Answer("Leopard"));
        q72.AddAnswer(new Answer("Giraffe"));
        q72.AddAnswer(new Answer("Tiger"));

        Question q73 = new("Welche Pflanze ist als Basis für Aspirin bekannt?");
        q73.AddAnswer(new Answer("Weidenrinde", true));
        q73.AddAnswer(new Answer("Lavendel"));
        q73.AddAnswer(new Answer("Kamille"));
        q73.AddAnswer(new Answer("Minze"));

        Question q74 = new("Welches ist das größte Lebewesen der Erde?");
        q74.AddAnswer(new Answer("Blauer Wal", true));
        q74.AddAnswer(new Answer("Elefant"));
        q74.AddAnswer(new Answer("Giraffe"));
        q74.AddAnswer(new Answer("Krokodil"));

        Question q75 = new("Welcher Planet wird als 'Abendstern' bezeichnet?");
        q75.AddAnswer(new Answer("Venus", true));
        q75.AddAnswer(new Answer("Merkur"));
        q75.AddAnswer(new Answer("Mars"));
        q75.AddAnswer(new Answer("Jupiter"));

        Question q76 = new("Welches ist das schnellste Meereslebewesen?");
        q76.AddAnswer(new Answer("Schwarzer Marlin", true));
        q76.AddAnswer(new Answer("Weißer Hai"));
        q76.AddAnswer(new Answer("Delfin"));
        q76.AddAnswer(new Answer("Schwertfisch"));

        Question q77 = new("Welcher Planet ist am weitesten von der Sonne entfernt?");
        q77.AddAnswer(new Answer("Neptun", true));
        q77.AddAnswer(new Answer("Uranus"));
        q77.AddAnswer(new Answer("Saturn"));
        q77.AddAnswer(new Answer("Jupiter"));

        Question q78 = new("Welche Pflanze ist bekannt für ihre Heilwirkung bei Magenbeschwerden?");
        q78.AddAnswer(new Answer("Kamille", true));
        q78.AddAnswer(new Answer("Lavendel"));
        q78.AddAnswer(new Answer("Pfefferminze"));
        q78.AddAnswer(new Answer("Rosmarin"));

        Question q79 = new("Welcher Vogel ist das Symbol für Frieden?");
        q79.AddAnswer(new Answer("Taube", true));
        q79.AddAnswer(new Answer("Adler"));
        q79.AddAnswer(new Answer("Kranich"));
        q79.AddAnswer(new Answer("Schwan"));

        Question q80 = new("Welches Tier hat die meisten Arten?");
        q80.AddAnswer(new Answer("Käfer", true));
        q80.AddAnswer(new Answer("Vögel"));
        q80.AddAnswer(new Answer("Fische"));
        q80.AddAnswer(new Answer("Säugetiere"));

        Question q81 = new("Welches Tier wird als 'Wüstenschiff' bezeichnet?");
        q81.AddAnswer(new Answer("Kamel", true));
        q81.AddAnswer(new Answer("Elefant"));
        q81.AddAnswer(new Answer("Esel"));
        q81.AddAnswer(new Answer("Ziege"));

        Question q82 = new("Welches Tier ist der größte Feind des Löwen?");
        q82.AddAnswer(new Answer("Hyäne", true));
        q82.AddAnswer(new Answer("Elefant"));
        q82.AddAnswer(new Answer("Gepard"));
        q82.AddAnswer(new Answer("Krokodil"));

        Question q83 = new("Welches Insekt hat die längste Lebensdauer?");
        q83.AddAnswer(new Answer("Zikade", true));
        q83.AddAnswer(new Answer("Ameise"));
        q83.AddAnswer(new Answer("Schmetterling"));
        q83.AddAnswer(new Answer("Biene"));

        Question q84 = new("Welche Pflanze wird zur Herstellung von Tequila verwendet?");
        q84.AddAnswer(new Answer("Agave", true));
        q84.AddAnswer(new Answer("Aloe Vera"));
        q84.AddAnswer(new Answer("Yucca"));
        q84.AddAnswer(new Answer("Lavendel"));

        Question q85 = new("Welche Pflanze ist bekannt für ihre beruhigende Wirkung?");
        q85.AddAnswer(new Answer("Lavendel", true));
        q85.AddAnswer(new Answer("Kamille"));
        q85.AddAnswer(new Answer("Minze"));
        q85.AddAnswer(new Answer("Rosmarin"));

        Question q86 = new("Welcher Vogel legt seine Eier in die Nester anderer Vögel?");
        q86.AddAnswer(new Answer("Kuckuck", true));
        q86.AddAnswer(new Answer("Specht"));
        q86.AddAnswer(new Answer("Rabe"));
        q86.AddAnswer(new Answer("Spatz"));

        Question q87 = new("Welcher Planet hat die meisten Monde?");
        q87.AddAnswer(new Answer("Jupiter", true));
        q87.AddAnswer(new Answer("Saturn"));
        q87.AddAnswer(new Answer("Uranus"));
        q87.AddAnswer(new Answer("Neptun"));

        Question q88 = new("Welches Säugetier kann den längsten Winterschlaf halten?");
        q88.AddAnswer(new Answer("Fledermaus", true));
        q88.AddAnswer(new Answer("Bär"));
        q88.AddAnswer(new Answer("Igel"));
        q88.AddAnswer(new Answer("Murmeltier"));

        Question q89 = new("Welcher Baum ist der älteste der Welt?");
        q89.AddAnswer(new Answer("Methuselah-Baum", true));
        q89.AddAnswer(new Answer("Küstenmammutbaum"));
        q89.AddAnswer(new Answer("Eiche"));
        q89.AddAnswer(new Answer("Tanne"));

        Question q90 = new("Welcher Kontinent hat die meisten Tierarten?");
        q90.AddAnswer(new Answer("Afrika", true));
        q90.AddAnswer(new Answer("Asien"));
        q90.AddAnswer(new Answer("Südamerika"));
        q90.AddAnswer(new Answer("Australien"));

        Question q91 = new("Welches Tier wird als 'Menschenscheuche' bezeichnet?");
        q91.AddAnswer(new Answer("Storch", true));
        q91.AddAnswer(new Answer("Adler"));
        q91.AddAnswer(new Answer("Rabe"));
        q91.AddAnswer(new Answer("Geier"));

        Question q92 = new("Welche Pflanze wird zur Herstellung von Seide verwendet?");
        q92.AddAnswer(new Answer("Maulbeerbaum", true));
        q92.AddAnswer(new Answer("Eiche"));
        q92.AddAnswer(new Answer("Weide"));
        q92.AddAnswer(new Answer("Ahorn"));

        Question q93 = new("Welcher Kontinent hat die größte Fläche?");
        q93.AddAnswer(new Answer("Asien", true));
        q93.AddAnswer(new Answer("Afrika"));
        q93.AddAnswer(new Answer("Nordamerika"));
        q93.AddAnswer(new Answer("Südamerika"));

        Question q94 = new("Welches Insekt lebt in einem Bienenstock?");
        q94.AddAnswer(new Answer("Biene", true));
        q94.AddAnswer(new Answer("Ameise"));
        q94.AddAnswer(new Answer("Käfer"));
        q94.AddAnswer(new Answer("Schmetterling"));

        Question q95 = new("Welches Tier wird als 'Waldpfleger' bezeichnet?");
        q95.AddAnswer(new Answer("Specht", true));
        q95.AddAnswer(new Answer("Eichhörnchen"));
        q95.AddAnswer(new Answer("Reh"));
        q95.AddAnswer(new Answer("Wildschwein"));

        Question q96 = new("Welches Tier hat die dickste Haut?");
        q96.AddAnswer(new Answer("Nashorn", true));
        q96.AddAnswer(new Answer("Elefant"));
        q96.AddAnswer(new Answer("Wal"));
        q96.AddAnswer(new Answer("Krokodil"));

        Question q97 = new("Welches Tier ist bekannt für seine Fähigkeit, Baumstämme zu fällen?");
        q97.AddAnswer(new Answer("Biber", true));
        q97.AddAnswer(new Answer("Eichhörnchen"));
        q97.AddAnswer(new Answer("Specht"));
        q97.AddAnswer(new Answer("Igel"));

        Question q98 = new("Welcher Planet hat die schnellste Rotation?");
        q98.AddAnswer(new Answer("Jupiter", true));
        q98.AddAnswer(new Answer("Saturn"));
        q98.AddAnswer(new Answer("Neptun"));
        q98.AddAnswer(new Answer("Uranus"));

        Question q99 = new("Welcher Vogel ist für seine Migrationsfähigkeiten bekannt?");
        q99.AddAnswer(new Answer("Storch", true));
        q99.AddAnswer(new Answer("Spatz"));
        q99.AddAnswer(new Answer("Taube"));
        q99.AddAnswer(new Answer("Adler"));

        List<Question> list = new List<Question>();

        for(int i =0; i < num; i++)
        {
            Random random = new Random();
            int gen = random.Next(0, _questions.Count());
            list.Add(_questions[gen]);
        }


        return list;
    }
}