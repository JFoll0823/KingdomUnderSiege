using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	bool canMove = true;
	bool canAttack = true;
	bool isSwiping = false;
	[SerializeField] GameObject pivot;

	
	float cTime = 0; //used in Movement()
	Vector3 verticalMovementVector;
	Vector3 sidewaysMovementVector;
	Vector3 containerPos;
	Quaternion containerRot;
	float timeSinceAttack = 0;
	float timeSwiping = 0;

	// Start is called before the first frame update
	void Start()
	{

	}


	// Update is called once per frame
	void Update()
	{
		Movement();
		Combat();

		if (((Time.time - timeSinceAttack) >= .5) && !canAttack)
		{
			//transform.Find("Spear Container").Find("Spear").gameObject.transform.rotation = spearRot;
			transform.Find("Spear Container").gameObject.transform.position = containerPos;
			if (!Pivot.followMouse && !isSwiping)
			{
				Pivot.followMouse = true;
				transform.Find("Spear Container").Find("Spear").GetComponent<PolygonCollider2D>().enabled = false;
			}
			if ((Time.time - timeSinceAttack) >= .7)
			{
				canMove = true;
				canAttack = true;
			}

		}

		if (isSwiping && !Pivot.followMouse)
        {
			transform.Find("Spear Container").gameObject.transform.Rotate(new Vector3(0, 0, 240*Time.deltaTime), Space.Self);
			if(Time.time - timeSwiping >= .4)
            {
				isSwiping = false;
            }
		}

		if (GameState.Instance.getPlayerHealthCurrent() <= 0)
		{
			GameState.Instance.InitiateGameOver();
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
				transform.position += sidewaysMovementVector * GameState.Instance.statSpeed * Time.deltaTime;
			}

			if (Input.GetButton("Vertical"))
			{
				transform.position += verticalMovementVector * GameState.Instance.statSpeed * Time.deltaTime;
			}

			if (Input.GetButtonDown("Jump") && ((Time.time - cTime) >= 3))
			{
				transform.position += (verticalMovementVector + sidewaysMovementVector) * GameState.Instance.statSpeed * Time.deltaTime * 20;
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
		if (canAttack)
		{
			//poke
			if (Input.GetButtonDown("Fire1"))
			{
				containerPos = transform.Find("Spear Container").gameObject.transform.position;
				canMove = false;
				canAttack = false;
				Pivot.followMouse = false;
				//Debug.Log("Poke");
				transform.Find("Spear Container").gameObject.transform.position = transform.Find("Spear Container").Find("SpearPokePosition").gameObject.transform.position;
				transform.Find("Spear Container").Find("Spear").GetComponent<PolygonCollider2D>().enabled = true;
				timeSinceAttack = Time.time;
			}

			
			if (Input.GetButtonDown("Fire2"))
			{
				canMove = false;
				canAttack = false;
				Pivot.followMouse = false;
				//Debug.Log("Swipe");
				containerPos = transform.Find("Spear Container").gameObject.transform.position;
				containerRot = transform.Find("Spear Container").gameObject.transform.rotation;
				transform.Find("Spear Container").gameObject.transform.Rotate(0, 0, -60f);
				transform.Find("Spear Container").Find("Spear").GetComponent<PolygonCollider2D>().enabled = true;
				isSwiping = true;
				timeSinceAttack = Time.time;
				timeSwiping = Time.time;
			}
		}
	}

/*
 * not used
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
