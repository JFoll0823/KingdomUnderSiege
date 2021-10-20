using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public static GameState Instance;

    int _playerHealthCurrent = 3;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
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
