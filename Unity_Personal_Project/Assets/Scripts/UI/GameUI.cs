using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    [SerializeField] public TextMeshProUGUI waveText;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public Slider hpSlider;

    private bool isFirst = true;

    private void Start()
    {
        UpdateHPSlider(1);
    }

    public void UpdateHPSlider(float percentage)
    {
        hpSlider.value = percentage;
    }

    public void UpdateWaveText(int wave)
    {
        waveText.text = wave.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}
