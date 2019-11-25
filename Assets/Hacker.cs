using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;

    enum Screen { MainMenu, Password, Win };
    Screen state;

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
        if (input == "menu") {
            ShowMainMenu("Welcome back hacker!");
        }
        else if (state == Screen.MainMenu) {
            HandleMainMenu(input);
        }
    }

    void HandleMainMenu(string input) {
        if (input == "1") {
            level = 1;
            StartGame();
        }
        else if (input == "2") {
            level = 2;
            StartGame();
        }
        else if (input == "3") {
            level = 3;
            StartGame();
        }
        else {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void ShowMainMenu(string greeting) {
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
        Terminal.WriteLine("Please enter your password");
    }
}
