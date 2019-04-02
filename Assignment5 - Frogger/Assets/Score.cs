using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int CurrentScore = 0;
    public static int HighScore = 0;

	public Text scoreText;
    public Text highScoreText;

	void Start ()
	{
		
	}
    private void Update()
    {
        scoreText.text = "Distance traveled: " + CurrentScore.ToString() + "km";
        AddScore();
        highScoreText.text = "High Score: " + HighScore.ToString() +"km";
    }

    private void AddScore()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            CurrentScore += 5;
        }
    }
}
