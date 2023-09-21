using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text currentScore;
    [SerializeField] private TMP_Text bestScore;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text currentLevel;
    [SerializeField] private TMP_Text nextLevel;
    [SerializeField] private Transform topTransform;
    [SerializeField] private Transform goalTransform;
    [SerializeField] private Transform ball;

    // Update is called once per frame
    void Update()
    {
        currentScore.text = GameManager.singleton.currentScore.ToString();
        bestScore.text = "High Score: " + GameManager.singleton.bestScore;
        ChangeSliderLevelandProgress();
    }

    public void ChangeSliderLevelandProgress()
    {
        currentLevel.text = "" + (GameManager.singleton.currentLevel + 1);
        nextLevel.text = "" + (GameManager.singleton.currentLevel + 2);
        float totalDistance = (topTransform.position.y - goalTransform.position.y);
        float distanceLeft = totalDistance - (ball.position.y - goalTransform.position.y);
        float value = (distanceLeft / totalDistance);
        slider.value = Mathf.Lerp(slider.value, value, 5);
    }
}
