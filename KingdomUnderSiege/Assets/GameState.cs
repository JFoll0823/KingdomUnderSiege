using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    public static GameState Instance;

    public bool _isGameStarted = false;
    public bool _isGameOver = false;

    [SerializeField] GameObject _gameStartText;

    [SerializeField] GameObject _gameOverText;

    int _playerHealthCurrent = 3;

    void Awake()
    {
        Instance = this;
        _gameStartText.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && _isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetButtonDown("Submit") && !_isGameStarted)
        {
            _gameStartText.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void InitiateGameOver()
    {
        _isGameOver = true;
        _gameOverText.SetActive(true);
        Time.timeScale = 0;
    }

    public int getPlayerHealthCurrent()
    {
        return _playerHealthCurrent;
    }

    public void playerHit()
    {
        _playerHealthCurrent -= 1;
    }
}
