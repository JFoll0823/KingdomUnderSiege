using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    float _healthPoints;

    // Start is called before the first frame update
    void Start()
    {
        _healthPoints = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Spear")
        {
            _healthPoints -= 1;
        }else if(collider.gameObject.tag == "Player")
        {
            GameState.Instance.playerHit();
        }

        if (_healthPoints == 0)
        {
            Destroy(gameObject);
        }

    }
}
