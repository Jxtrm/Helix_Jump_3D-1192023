using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text currentScore;
    [SerializeField] private TMP_Text bestScore;

    // Update is called once per frame
    void Update()
    {
        currentScore.text = GameManager.singleton.currentScore.ToString();
        bestScore.text = "High Score: " + GameManager.singleton.bestScore;
    }
}
