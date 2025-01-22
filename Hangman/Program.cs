namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ___________Hangman variable/constants______________________


            string HANGMAN_LOGO = @"
   _                                             
  | |                                            
  | |__   __ _ _ __   __ _ _ __ ___   __ _ _ __  
  | '_ \ / _` | '_ \ / _` | '_ ` _ \ / _` | '_ \ 
  | | | | (_| | | | | (_| | | | | | | (_| | | | |
  |_| |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_| 
                      __/ |                       
                     |___/    ";

            const int ZERO = 0;
            const int EXTRA_SPACE = 2;
            const int MAX_LIVES = 6
            List<string> HANGMAN_STAGES = new List<string>
            {
                @"
              +---+
              |   |
              O   |
             /|\  |
             / \  |
                  |
            =========
            ",
                @"
              +---+
              |   |
              O   |
             /|\  |
             /    |
                  |
            =========
            ",
                @"
              +---+
              |   |
              O   |
             /|\  |
                  |
                  |
            =========
            ",
                @"
              +---+
              |   |
              O   |
             /|   |
                  |
                  |
            =========
            ",
                @"
              +---+
              |   |
              O   |
              |   |
                  |
                  |
            =========
            ",
                @"
              +---+
              |   |
              O   |
                  |
                  |
                  |
            =========
            ",
                @"
              +---+
              |   |
                  |
                  |
                  |
                  |
            =========
            "
            };

            string placeHolder = "";
            List<string> correctLetters = new List<string>();
            int numberOfGuesses = 6;
            bool gameActive = true;
            bool gameWon = true;
            List<string> HANGMAN_WORDS = new List<string>
            {
                "abruptly",
                "absurd",
                "abyss",
                "affix",
                "askew",
                "avenue",
                "awkward",
                "awkward",
                "axiom",
                "azure",
                "bagpipes",
                "bandwagon",
                "banjo",
                "bayou",
                "beekeeper",
                "bikini",
                "blitz",
                "blizzard",
                "boggle",
                "bookworm",
                "boxcar",
                "boxful",
                "buckaroo",
                "buffalo",
                "buffoon",
                "buxom",
                "buzzard",
                "buzzing",
                "buzzwords",
                "caliph",
                "cobweb",
                "cockiness",
                "croquet",
                "crypt",
                "curacao",
                "cycle",
                "daiquiri",
                "dirndl",
                "disavow",
                "dizzying",
                "duplex",
                "dwarves",
                "embezzle",
                "equip",
                "espionage",
                "euouae",
                "exodus",
                "faking",
                "fishhook",
                "fixable",
                "fjord",
                "flapjack",
                "flopping",
                "fluffiness",
                "flyby",
                "foxglove",
                "frazzled",
                "frizzled",
                "fuchsia",
                "funny",
                "gabby",
                "galaxy",
                "galvanize",
                "gazebo",
                "giaour",
                "gizmo",
                "glowworm",
                "glyph",
                "gnarly",
                "gnostic",
                "gossip",
                "grogginess",
                "haiku",
                "haphazard",
                "hyphen",
                "iatrogenic",
                "icebox",
                "injury",
                "ivory",
                "ivy",
                "jackpot",
                "jaundice",
                "jawbreaker",
                "jaywalk",
                "jazziest",
                "jazzy",
                "jelly",
                "jigsaw",
                "jinx",
                "jiujitsu",
                "jockey",
                "jogging",
                "joking",
                "jovial",
                "joyful",
                "juicy",
                "jukebox",
                "jumbo",
                "kayak",
                "kazoo",
                "keyhole",
                "khaki",
                "kilobyte",
                "kiosk",
                "kitsch",
                "kiwifruit",
                "klutz",
                "knapsack",
                "larynx",
                "lengths",
                "lucky",
                "luxury",
                "lymph",
                "marquis",
                "matrix",
                "megahertz",
                "microwave",
                "mnemonic",
                "mystify",
                "naphtha",
                "nightclub",
                "nowadays",
                "numbskull",
                "nymph",
                "onyx",
                "ovary",
                "oxidize",
                "oxygen",
                "pajama",
                "peekaboo",
                "phlegm",
                "pixel",
                "pizazz",
                "pneumonia",
                "polka",
                "pshaw",
                "psyche",
                "puppy",
                "puzzling",
                "quartz",
                "queue",
                "quips",
                "quixotic",
                "quiz",
                "quizzes",
                "quorum",
                "razzmatazz",
                "rhubarb",
                "rhythm",
                "rickshaw",
                "schnapps",
                "scratch",
                "shiv",
                "snazzy",
                "sphinx",
                "spritz",
                "squawk",
                "staff",
                "strength",
                "strengths",
                "stretch",
                "stronghold",
                "stymied",
                "subway",
                "swivel",
                "syndrome",
                "thriftless",
                "thumbscrew",
                "topaz",
                "transcript",
                "transgress",
                "transplant",
                "triphthong",
                "twelfth",
                "twelfths",
                "unknown",
                "unworthy",
                "unzip",
                "uptown",
                "vaporize",
                "vixen",
                "vodka",
                "voodoo",
                "vortex",
                "voyeurism",
                "walkway",
                "waltz",
                "wave",
                "wavy",
                "waxy",
                "wellspring",
                "wheezy",
                "whiskey",
                "whizzing",
                "whomever",
                "wimpy",
                "witchcraft",
                "wizard",
                "woozy",
                "wristwatch",
                "wyvern",
                "xylophone",
                "yachtsman",
                "yippee",
                "yoked",
                "youthful",
                "yummy",
                "zephyr",
                "zigzag",
                "zigzagging",
                "zilch",
                "zipper",
                "zodiac",
                "zombie"
            };

            //________________Welcome messages_________________________
            Console.WriteLine(HANGMAN_LOGO);
            Console.WriteLine("Welcome to hangman!");

            //________________Word choice________________________
            Random random = new Random();
            int index = random.Next(HANGMAN_WORDS.Count);
            string randomWord = HANGMAN_WORDS[index];
            int wordLength = randomWord.Length;
            foreach (char letter in randomWord)
            {
                placeHolder += "_ ";
            }

            //_______________GAME LOGIC_______________________
            while (gameActive)
            {
                Console.WriteLine($"*************************************************{numberOfGuesses}/{MAX_LIVES} lives left*************************************************");
                Console.WriteLine($"The word to guess is {placeHolder}");
                Console.WriteLine("Please guess a letter.");
                string playerGuess = Console.ReadLine().ToLower();


                if (correctLetters.Contains(playerGuess))
                {
                    Console.WriteLine($"You have already guessed {playerGuess}");
                }
                else
                {

                    bool correctGuess = false;


                    char[] placeHolderArray = placeHolder.ToCharArray();
                    for (int i = ZERO; i < randomWord.Length; i++)
                    {
                        if (randomWord[i].ToString() == playerGuess)
                        {
                            placeHolderArray[i * EXTRA_SPACE] = randomWord[i];
                            correctGuess = true;
                        }
                    }

                    placeHolder = new string(placeHolderArray);


                    if (correctGuess)
                    {
                        correctLetters.Add(playerGuess);
                    }
                    else
                    {
                        Console.WriteLine($"The letter {playerGuess} is not in the word! You have lost a life.");
                        numberOfGuesses--;

                        if (numberOfGuesses == ZERO)
                        {
                            gameActive = false;
                            gameWon = false;

                        }
                    }
                }


                if (!placeHolder.Contains("_"))
                {
                    gameActive = false;

                }


                Console.WriteLine(HANGMAN_STAGES[numberOfGuesses]);
            }

            if (gameWon)
            {
                Console.WriteLine("****************************YOU WIN****************************");
            }

            else
            {
                Console.WriteLine($"***********************YOU LOSE**********************\n The correct word was {randomWord}");
                
            }
        }
    }
}
