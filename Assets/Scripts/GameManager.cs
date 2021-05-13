using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject _pausePanelGO;
    private GameObject _scoreGO;
    private Text _scoreText;
    private int _scoreToDisplay = 0;
    private int _totalScore = 0;
    private bool isPause;
    
    private void Start()
    {
        _pausePanelGO = GameObject.Find("Pause_Panel");
        _pausePanelGO.SetActive(false);
        _scoreGO = GameObject.Find("ScoreText");
        _scoreText = _scoreGO.GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (isPause)
        {
            isPause = false;
            _pausePanelGO.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            isPause = true;
            _pausePanelGO.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    private void OnEnable()
    {
        DestructibleObjects.OnBlockDestroyed += OnOnBlockDestroyed;
        DestructibleObjects.OnBlockCreated += OnOnBlockCreated;
    }

    private void OnDisable()
    {
        DestructibleObjects.OnBlockDestroyed -= OnOnBlockDestroyed;
        DestructibleObjects.OnBlockCreated -= OnOnBlockCreated;
    }
    
    private void OnOnBlockCreated(int scoreForBlock)
    {
        _totalScore += scoreForBlock;
    }

    private void OnOnBlockDestroyed(int scoreForBlock)
    {
        _scoreToDisplay += scoreForBlock;
        _scoreText.text = $"Score: {_scoreToDisplay}";
        CheckForWin();
    }

    private void CheckForWin()
    {
        if (_totalScore == _scoreToDisplay)
        {
            SceneLoader.SceneNumber++;
            SceneManager.LoadScene(SceneLoader.SceneNumber);
        }
    }
    
}
