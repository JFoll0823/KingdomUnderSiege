using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    public static GameState Instance;

    public bool _isGameStarted = false;
    public bool _isGameOver = false;

    [SerializeField] GameObject _gameStartText;
    [SerializeField] GameObject _gameOverText;
    [SerializeField] GameObject _healthText;

    public float _playerHealthCurrent;

    public float statStrength;
    public float statSpeed;
    public float statHealth;

    void Awake()
    {
        Instance = this;
        _gameStartText.SetActive(true);
        statHealth = 3f;
        statSpeed = 2f;
        statStrength = 1f;
        Time.timeScale = 0;
        _playerHealthCurrent = statHealth;
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
            _isGameStarted = true;
            Time.timeScale = 1;
        }
    }

    public void InitiateGameOver()
    {
        _isGameOver = true;
        _gameOverText.SetActive(true);
        Time.timeScale = 0;
    }

    public float getPlayerHealthCurrent()
    {
        return _playerHealthCurrent;
    }

    public void playerHit()
    {
        _playerHealthCurrent -= 1;
        _healthText.GetComponent<Text>().text = "Health: " + _playerHealthCurrent;
    }
}
