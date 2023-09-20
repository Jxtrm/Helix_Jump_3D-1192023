using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int bestScore;
    public int currentScore;
    [SerializeField] private int currentLevel = 0;
    public static GameManager singleton;
    // Start is called before the first frame update
    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }

        bestScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    public void NextLevel()
    {
        currentLevel++;
        FindObjectOfType<PlayerController>().ResetBall(); 
        FindObjectOfType<HelixController>().LoadStage(currentLevel);
        Debug.Log("Pasas de Nivel");
    }

    public void RestartLevel()
    {
        Debug.Log("Restart Nivel");
        singleton.currentScore = 0;
        FindObjectOfType<PlayerController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentLevel);
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }
}
