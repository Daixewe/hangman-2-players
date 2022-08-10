string[] words = new string[]{"teemo"};
char[] guesses;
string[] fails;
string secretword;
bool won, lost;

Random random = new Random();
int index = random.Next(words.Length);
secretword = words[index];
guesses = new char[secretword.Length];
Array.Fill(guesses, '*');
fails = new string[0];
won = false;
lost = false;

Console.WriteLine("Bienvenido a ahorcado! \n\n");


Console.WriteLine("Inserte nombre de jugador 1: ");
string Jug1 = Console.ReadLine();
Console.WriteLine("Inserte nombre de jugador 2: ");
string Jug2 = Console.ReadLine();
gameCicle1();


void gameCicle1()
{
    
    Console.WriteLine($"La palabra secreta es {new String(guesses)}. ");

    printHangMan();
    if (lost)
    {
        Console.WriteLine("Perdiste :c");

    }
    else if (won)
    {
        Console.WriteLine("Gana:"+ Jug2);
    }
    else
    {
        Console.WriteLine("Turno de:" + Jug1);
        Player1Turn();
        

    }

}
void gameCicle2()
{
    
    Console.WriteLine($"La palabra secreta es {new String(guesses)}. ");

    printHangMan();
    if (lost)
    {
        Console.WriteLine("Perdiste :c");

    }
    else if (won)
    {
        Console.WriteLine("Gana:"+ Jug1);
    }
    else
    {
        Console.WriteLine("Turno de:"+ Jug2);
        Player2Turn();
        

    }

}
void Player1Turn()
{
    Console.WriteLine("Ingrese una letra o adivine una palabra: ");
    string attempt = Console.ReadLine() ?? "";
    if (attempt.Length == 0)
    {
        Console.WriteLine("Intente denuevo");

    }
    else if (attempt.Length ==1)
    {
       lookForLetter1(attempt[0]);
    }
    else
    {
        TryToGuess1(attempt);
    }

}
void Player2Turn()
{
    Console.WriteLine("Ingrese una letra o adivine una palabra: ");
    string attempt = Console.ReadLine() ?? "";
    if (attempt.Length == 0)
    {
        Console.WriteLine("Intente denuevo");

    }
    else if (attempt.Length ==1)
    {
       lookForLetter2(attempt[0]);
    }
    else
    {
        TryToGuess2(attempt);
    }

}
void lookForLetter1(char letter)
{
    Console.WriteLine("Buscando letra...");
    if (secretword.IndexOf(letter) > -1)
    {
        Console.WriteLine($"La letra ¨{letter} si esta ");
        for (int i = 0; i < secretword.Length; i++)
        {
            if (secretword[i] == letter)
            {
                guesses[i] = letter;
            }
        }
        won = (Array.IndexOf(guesses, '*') == -1);
        gameCicle1();

    }
    else 
    {
        Console.WriteLine($"La letra {letter} no está");
        Array.Resize(ref fails, fails.Length +1);
        fails.SetValue(letter.ToString(), fails.Length -1);
        gameCicle2();
    }
}

void TryToGuess1(string word)
{
    if (secretword == word)
    {
      Console.WriteLine($"La palabra {word} si es  ");
      guesses = secretword.ToCharArray();
      won = true;
      gameCicle2();

    }
    else
    {
        Console.WriteLine($"La palabra {word} no es ");
         Array.Resize(ref fails, fails.Length +1);
         fails.SetValue(word, fails.Length -1);
         gameCicle2();
    }
}
void TryToGuess2(string word)
{
    if (secretword == word)
    {
      Console.WriteLine($"La palabra {word} si es  ");
      guesses = secretword.ToCharArray();
      won = true;
      gameCicle1();

    }
    else
    {
        Console.WriteLine($"La palabra {word} no es ");
         Array.Resize(ref fails, fails.Length +1);
         fails.SetValue(word, fails.Length -1);
         gameCicle1();
    }
}
void lookForLetter2(char letter)
{
    Console.WriteLine("Buscando letra...");
    if (secretword.IndexOf(letter) > -1)
    {
        Console.WriteLine($"La letra ¨{letter} si esta ");
        for (int i = 0; i < secretword.Length; i++)
        {
            if (secretword[i] == letter)
            {
                guesses[i] = letter;
            }
        }
        won = (Array.IndexOf(guesses, '*') == -1);
        gameCicle2();

    }
    else 
    {
        Console.WriteLine($"La letra {letter} no está");
        Array.Resize(ref fails, fails.Length +1);
        fails.SetValue(letter.ToString(), fails.Length -1);
        gameCicle1();
    }
}









void printHangMan()
{
    Console.WriteLine("Intentas fallidos: ");
    for (int i=0; i < fails.Length; i++)
    {
        Console.Write(fails[i] + ' ');
    }

    int f = fails.Length;
    Console.WriteLine();
    Console.WriteLine("|---");
    Console.WriteLine($"|    {(f > 0 ? 'o' : ' ')}");
    Console.WriteLine($"|   {(f > 2 ? '/' : ' ' )}{(f > 1 ? '|' : ' ')}{(f > 3 ? '\\'  : ' ')}");
    Console.WriteLine("|");
    Console.WriteLine("/---------------\\");
    if (f == 6)
    {
        lost = true;
    }
}