using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private int level;

    enum Screen { Start, MainMenu, Password, Win };
    private Screen state;
    
    private string password;
    private string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
    private string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    private string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    // Start is called before the first frame update
    void Start()
    {
        state = Screen.MainMenu;
        ShowMainMenu("Hello hacker!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnUserInput(string input) {
        switch(state) {
            case Screen.Start:
                Terminal.ClearScreen();
                ShowMainMenu("Welcome back hacker!");
                break;
            case Screen.MainMenu:
                HandleMainMenu(input);
                break;
            case Screen.Password:
                CheckPassword(input);
                break;
        }
    }

    void HandleMainMenu(string input) {

        bool valid_level = input == "1" || input == "2" || input == "3";
        if (valid_level) {
            level = int.Parse(input);
            string[] options = getPasswords(level);
            password = options[Random.Range(0, options.Length)];            
            StartGame();
        }
        else {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    string[] getPasswords(int level) {
        switch(level) {
            case 1:
                return level1Passwords;
            case 2:
                return level2Passwords;
            case 3:
                return level3Passwords;
        }
        return new string[0];
    }

    void ShowMainMenu(string greeting) {
        state = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What are you gonna hack today?");
        Terminal.WriteLine("1. Local Library");
        Terminal.WriteLine("2. Police Station");
        Terminal.WriteLine("3. NASA");
        Terminal.WriteLine("Enter your selection: ");
    }

    void StartGame() {
        state = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("> Enter your password, hint: " + password.Anagram());
    }

    void CheckPassword(string input) {
        if (input == password) {
            WinScreen();
        }
        else {
            Terminal.WriteLine("> Wrong password, hint: " + password.Anagram());
        }
    }

    void WinScreen() {
        state = Screen.Start;
        Terminal.ClearScreen();
        ShowLevelReward();
        WaitForInput();
    }

    void ShowLevelReward() {
        switch(level) {
            case 1:
                Level1Reward();
                break;
            case 2:
                Level2Reward();
                break;
            case 3:
                Level3Reward();
                break;
        }
    }

    void Level1Reward() {
        Terminal.WriteLine("Have a book... ");
        Terminal.WriteLine(@"
        _______
       /      //
      /      //
     /______//
    (______(/
        
        ");
    }

    void Level2Reward() {
        Terminal.WriteLine("You won a cake");
        Terminal.WriteLine("         __.......__");
        Terminal.WriteLine("    ,-\"``           ``\"-.");
        Terminal.WriteLine("    |;------.-'      _.-'\\");
        Terminal.WriteLine("    ||______|`  ' ' `    |");
        Terminal.WriteLine("    ||------|            |");
        Terminal.WriteLine("   _;|______|            |_");
        Terminal.WriteLine(" (```\"\"\"\"\"\"\"|            |``)");
        Terminal.WriteLine(" \\'._       '-.........-'_.'/");
        Terminal.WriteLine("  '._`\"\"===........===\"\"`_.'");
        Terminal.WriteLine("     ``\"\"\"==========\"\"\"``");
    }

    void Level3Reward() {
        Terminal.WriteLine("You found a strange picture....");
        Terminal.WriteLine(@"
                       .-.
        .-""""`""""-.    |(@ @)
     _/`oOoOoOoOo`\_ \ \-/
    '.-=-=-=-=-=-=-.' \/ \
      `-=.=-.-=.=-'    \ /\
         ^  ^  ^       _H_ \
        ");
    }

    void WaitForInput() {
        Terminal.WriteLine("Press any key to continue...");
    }
}
