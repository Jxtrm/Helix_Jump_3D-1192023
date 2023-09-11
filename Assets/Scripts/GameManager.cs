using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int bestScore;
    [SerializeField] private int currentScore;
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
    }

    // Update is called once per frame
    public void NextLevel()
    {
        
    }

    public void RestartLevel()
    {

    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
        }
    }
}
