using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float _moveSpeed = 1f;
    float cTime = 0; //used in Movement()

    public float _healthPoints;
    // Start is called before the first frame update
    void Start()
    {
        _healthPoints = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(GameState.Instance.getPlayerHealthCurrent() == 0)
        {
            Destroy(gameObject);
        }
    }

    void Movement()
    {
        Debug.Log(Time.time);
        if (Input.GetButton("Horizontal"))
        {
            
            Vector3 sidewaysMovementVector = transform.right * Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && ((Time.time - cTime) >= 3))
            {
                transform.position += sidewaysMovementVector * _moveSpeed * Time.deltaTime * 30;
                cTime = Time.time;
            }
            else
            {
                transform.position += sidewaysMovementVector * _moveSpeed * Time.deltaTime;
            }
        }

        if (Input.GetButton("Vertical"))
        {
            Vector3 verticalMovementVector = transform.up * Input.GetAxis("Vertical");
            if (Input.GetButtonDown("Jump") && ((Time.time - cTime) >= 3))
            {
                transform.position += verticalMovementVector * _moveSpeed * Time.deltaTime * 30;
                cTime = Time.time;
            }
            else
            {
                transform.position += verticalMovementVector * _moveSpeed * Time.deltaTime;
            }
            
        }

        

        /*
         * Code from 3D tutorial to use as reference
        Vector3 sidewaysMovementVector = transform.right * Input.GetAxis("Horizontal");
        Vector3 forwardBackwardMovementVector = transform.forward * Input.GetAxis("Vertical");
        Vector3 movementVector = sidewaysMovementVector + forwardBackwardMovementVector;

        GetComponent<CharacterController>().Move(movementVector * _moveSpeed * Time.deltaTime);
        */
    }

/*
     private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            _healthPoints -= 1;
        }

        if (_healthPoints == 0)
        {
            Destroy(gameObject);
        }

    }
 */
}
