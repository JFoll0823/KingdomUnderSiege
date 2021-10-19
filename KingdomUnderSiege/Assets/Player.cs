using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float _moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetButton("Horizontal"))
        {
            Vector3 sidewaysMovementVector = transform.right * Input.GetAxis("Horizontal");
            transform.position += sidewaysMovementVector * _moveSpeed * Time.deltaTime;
        }

        if (Input.GetButton("Vertical"))
        {
            Vector3 verticalMovementVector = transform.up * Input.GetAxis("Vertical");
            transform.position += verticalMovementVector * _moveSpeed * Time.deltaTime;
        }

        /*
        Vector3 sidewaysMovementVector = transform.right * Input.GetAxis("Horizontal");
        Vector3 forwardBackwardMovementVector = transform.forward * Input.GetAxis("Vertical");
        Vector3 movementVector = sidewaysMovementVector + forwardBackwardMovementVector;

        GetComponent<CharacterController>().Move(movementVector * _moveSpeed * Time.deltaTime);
        */
    }
}
