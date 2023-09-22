using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource winAudio;
    [HideInInspector] public TMP_Text onePointText;
    [HideInInspector] public int bestScore;
    [HideInInspector] public int currentScore;
    [HideInInspector] public int currentLevel = 0;
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
        winAudio.Play();
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
        onePointText.GetComponent<Animation>().Play();

        currentScore += scoreToAdd;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }
}
