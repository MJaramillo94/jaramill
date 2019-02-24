using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;

public class WordGenerator : MonoBehaviour
{
    
   
   
    //Set File Path
    private static string path = @"C:\Users\majar\OneDrive\Documents\GitHub\jaramill\FallingWordsGame\Assets\cppDataFile.txt";

    //Read File into array
    private static string[] wordList = File.ReadAllLines(path); 

        /* {   "sidewalk", "robin", "three", "protect", "periodic",
                                    "somber", "majestic", "jump", "pretty", "wound", "jazzy",
         //Original Code                           "memory", "join", "crack", "grade", "boot", "cloudy", "sick",
                                    "mug", "hot", "tart", "dangerous", "mother", "rustic", "economic",
                                    "weird", "cut", "parallel", "wood", "encouraging", "interrupt",
                                    "guide", "long", "chief", "mom", "signal", "rely", "abortive",
                                    "hair", "representative", "earth", "grate", "proud", "feel",
                                    "hilarious", "addition", "silent", "play", "floor", "numerous",
                                    "friend", "pizzas", "building", "organic", "past", "mute", "unusual",
                                    "mellow", "analyse", "crate", "homely", "protest", "painstaking",
                                    "society", "head", "female", "eager", "heap", "dramatic", "present",
                                    "sin", "box", "pies", "awesome", "root", "available", "sleet", "wax",
                                    "boring", "smash", "anger", "tasty", "spare", "tray", "daffy", "scarce",
                                    "account", "spot", "thought", "distinct", "nimble", "practise", "cream",
                                    "ablaze", "thoughtless", "love", "verdict", "giant"    };   */
    

    public static string GetRandomWord ()
	{

        //Trying to read in order
       /* string randomWord;

        for (int i = 0; i < wordList.Length; i++)
        {
            randomWord = wordList[i];

        }*/


		int randomIndex = Random.Range(0, wordList.Length);
		string randomWord = wordList[randomIndex];
        
		return randomWord;
        
	}

}
