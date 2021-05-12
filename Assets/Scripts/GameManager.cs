using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int _scoreToDisplay = 0;
    
    private void Awake()
    {
        DestructibleObjects.OnBlockDestroyed += OnOnBlockDestroyed;
    }

    private void OnOnBlockDestroyed(int scoreForBlock)
    {
        _scoreToDisplay += scoreForBlock;
        scoreText.text = $"Score: {_scoreToDisplay}";
    }
}
