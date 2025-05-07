using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TotalPointsUI : MonoBehaviour
{
    public TextMeshProUGUI totalPointsText;
    public GameUI gameUI;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        totalPointsText.text = GameManager.instance.score.ToString();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("TotalPoints", GameManager.instance.score);
    }

    public void LoadScore()
    {
        if (PlayerPrefs.HasKey("TotalPoints"))
        {
            GameManager.instance.score = PlayerPrefs.GetInt("TotalPoints");
        }
        else
        { 
            GameManager.instance.score = 0;
        }
    }
}
