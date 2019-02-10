﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour
{
    private RoundData[] allRoundData;

    private PlayerProgress playerProgress;
    private string gameDataFileName = "data.json";

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        LoadGameData();
        LoadPlayerProgress();

        SceneManager.LoadScene("MenuScreen");
	}
	
    public RoundData getCurrentRoundData()
    {
        return allRoundData[0];
    }


    public void SubmitNewPlayerScore(int newScore)
    {
        if (newScore > playerProgress.highestScore)
        {
            playerProgress.highestScore = newScore;
            SavePlayeProgress();
        }
    }

    public int GetHighestPlayerScore()
    {
        return playerProgress.highestScore;
    }
	private void LoadPlayerProgress()
    {
        playerProgress = new PlayerProgress();

        if ( PlayerPrefs.HasKey("highestScore"))
        {
            playerProgress.highestScore = PlayerPrefs.GetInt("highestScore");
        }
    }

    private void SavePlayeProgress ()
    {
        PlayerPrefs.SetInt("highestScore", playerProgress.highestScore);
    }


    private void LoadGameData()
    {
        string filepath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        if (File.Exists (filepath))
        {
            string dataAsJson = File.ReadAllText(filepath);
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

            allRoundData = loadedData.allRoundData;

        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }


}
