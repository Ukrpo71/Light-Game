using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void UpdateScoreText()
    {
        _scoreText.text = "Your score: " + GameManager.Instance.Score + "\n " +
                         "Best score: " + GameManager.Instance.PlayerData.BestScore;
    }

}
