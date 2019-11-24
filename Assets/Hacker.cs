using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Terminal.WriteLine("Hello hacker");
        Terminal.WriteLine("What are you gonna hack today?");
        Terminal.WriteLine("1. Local Library");
        Terminal.WriteLine("2. Police Station");
        Terminal.WriteLine("3. NASA");
        Terminal.WriteLine("Enter your selection: ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
