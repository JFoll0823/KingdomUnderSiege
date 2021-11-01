using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
	public static GameplayManager Instance;

	[SerializeField] GameObject _skeletonPrefab;
	[SerializeField] GameObject _statUpgradeScreen;
	[SerializeField] GameObject _healthText;
	[SerializeField] GameObject _speedText;
	[SerializeField] GameObject _strengthText;

	int _numEnemiesKilled = 0;
	int _currentEnemies = 0;
	bool _isUpgrading = false;

	private void Awake()
	{
		Instance = this;
	}
	// Start is called before the first frame update
	void Start()
	{
		_speedText.GetComponent<Text>().text = "Speed: " + GameState.Instance.statSpeed;
		_strengthText.GetComponent<Text>().text = "Strength: " + GameState.Instance.statStrength;
	}

	// Update is called once per frame
	void Update()
	{
		if (_numEnemiesKilled < 10 && _currentEnemies == 0 && !_isUpgrading)
		{
			SpawnEnemies();
		}
		if (_isUpgrading)
		{
			InitializeStatUpgrade();
		}
	}

	void SpawnEnemies()
	{
		if (GameState.Instance._isGameStarted)
		{
			Debug.Log("Spawn Enemies");
			Instantiate(_skeletonPrefab);
			_currentEnemies += 1;
		}
	}

	void InitializeStatUpgrade()
	{
		_statUpgradeScreen.SetActive(true);

		//speed
		if (Input.GetKeyDown(KeyCode.J))
		{
			Debug.Log("J Pressed");
			GameState.Instance.statSpeed += 0.5f;
			_speedText.GetComponent<Text>().text = "Speed: " + GameState.Instance.statSpeed;
			_statUpgradeScreen.SetActive(false);
			_isUpgrading = false;
		}

		//strength
		if (Input.GetKeyDown(KeyCode.K))
		{
			Debug.Log("K Pressed");
			GameState.Instance.statStrength += 0.5f;
			_strengthText.GetComponent<Text>().text = "Strength: " + GameState.Instance.statStrength;
			_statUpgradeScreen.SetActive(false);
			_isUpgrading = false; 
		}

		//health
		if (Input.GetKeyDown(KeyCode.L))
		{
			Debug.Log("L Pressed");
			GameState.Instance.statHealth += 0.5f;
			_statUpgradeScreen.SetActive(false);
			_isUpgrading = false;
		}
		GameState.Instance._playerHealthCurrent = GameState.Instance.statHealth;
		_healthText.GetComponent<Text>().text = "Health: " + GameState.Instance._playerHealthCurrent;
	}

	public void EnemyKilled()
	{
		_currentEnemies -= 1;
		_numEnemiesKilled += 1;
		if(_numEnemiesKilled >= 10)
		{
			GameState.Instance.InitiateGameOver();
		}
		if(_currentEnemies == 0)
		{
			_isUpgrading = true;
			InitializeStatUpgrade();
		}
	}
}
