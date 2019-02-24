
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuenuManager : MonoBehaviour {
    

	public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("GAME OVER");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
