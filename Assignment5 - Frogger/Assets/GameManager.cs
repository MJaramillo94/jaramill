using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        count++;
        scoreText.text = "Distance: " + count.ToString() + " meters."; 
    }
}
