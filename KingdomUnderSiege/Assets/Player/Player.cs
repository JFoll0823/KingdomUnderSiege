using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	[SerializeField] float _moveSpeed = 1f;
	bool canMove = true;
	bool canAttack = true;
	bool followMouse = true;
	float cTime = 0; //used in Movement()
	Vector3 verticalMovementVector;
	Vector3 sidewaysMovementVector;
	Vector3 origPos; //tracks spear position before attack
	float timeSinceAttack = 0;

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
		Combat();

		if(((Time.time - timeSinceAttack) >= .5) && !canAttack)
        {
			transform.Find("Spear Container").Find("Spear").gameObject.transform.position = origPos;
			canAttack = true;
			canMove = true;
		}
		if(GameState.Instance.getPlayerHealthCurrent() == 0)
		{
			Destroy(gameObject);
		}
	}

	void Movement()
	{
		verticalMovementVector = transform.up * Input.GetAxis("Vertical");
		sidewaysMovementVector = transform.right * Input.GetAxis("Horizontal");

		if (canMove)
		{
			if (Input.GetButton("Horizontal"))
			{
				transform.position += sidewaysMovementVector * _moveSpeed * Time.deltaTime;
			}

			if (Input.GetButton("Vertical"))
			{
				transform.position += verticalMovementVector * _moveSpeed * Time.deltaTime;
			}

			if (Input.GetButtonDown("Jump") && ((Time.time - cTime) >= 3))
			{
				transform.position += (verticalMovementVector + sidewaysMovementVector) * _moveSpeed * Time.deltaTime * 30;
				cTime = Time.time;
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

	void Combat()
	{
		//poke
		if (Input.GetButtonDown("Fire1"))
		{
			origPos = transform.Find("Spear Container").Find("Spear").gameObject.transform.position;
			canMove = false;
			canAttack = false;
			//Debug.Log("Swipe");
			transform.Find("Spear Container").Find("Spear").gameObject.transform.position = transform.Find("Spear Container").Find("SpearPokePosition").gameObject.transform.position;
			timeSinceAttack = Time.time;
		}


		if (Input.GetButtonDown("Fire2"))
		{
			canMove = false;
			canAttack = false;
			//Debug.Log("Poke");


			canAttack = true;
			canMove = true;
		}
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
