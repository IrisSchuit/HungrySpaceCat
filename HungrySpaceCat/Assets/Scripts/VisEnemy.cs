using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisEnemy : MonoBehaviour
{
	public bool CanAttack { get { return shootCooldown <= 0f; } }
	public GameObject player;
	public Collider2D thisCollider;
	public Collider2D otherCollider;
	public GameObject geweer;
	public Rigidbody2D bal;
	public float shootingRate = 1f;
	public float minDistance = 10f;
	public float movementSpeed = 2f;

	private bool died = false;
	private float shootCooldown;
	private float distance;

	public Transform point1, point2;
	private bool inRange = false;
	private Animator anim;
	private GameUI gameUI;
	private AudioManager audioManager;

	private void Start()
	{
		audioManager = FindObjectOfType<AudioManager>();
		gameUI = FindObjectOfType<GameUI>();
		anim = GetComponent<Animator>();
		shootCooldown = 0f;
		gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * movementSpeed;
	}

	private void Update()
	{
		CalculateDistance();

		if (thisCollider.IsTouching(otherCollider))
		{
			player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
			audioManager.PlayAudio(0);
			died = true;
		}

		if (died == true)
		{
			shootingRate = 20f;
			anim.SetBool("dead", true);
			StartCoroutine("DeadVis");
		}	
	}

	IEnumerator DeadVis()
	{
		gameUI.enemiesUI.Remove(this.gameObject);
		yield return new WaitForSeconds(2f);
		Destroy(this.gameObject);
	}

	private void FixedUpdate()
	{	
		if(inRange)
		{
			movementSpeed = 0;
			gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * movementSpeed;
		}
		if(!inRange && movementSpeed == 0)
		{
			movementSpeed = 2f;
			FlipEnemy(false);
			gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * movementSpeed;
		}

		if (!inRange)
		{
			if (gameObject.transform.position.x <= point1.position.x)
			{
				gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * movementSpeed;
				FlipEnemy(false);
			}
			if (gameObject.transform.position.x >= point2.position.x)
			{
				gameObject.GetComponent<Rigidbody2D>().velocity = -transform.right * movementSpeed;
				FlipEnemy(true);
			}
		}
	}

	private void FlipEnemy(bool flip)
	{
		if(flip)
		{
			transform.localScale = new Vector3(-0.5f, 0.5f, 1);  //face left
		}
		else
		{
			transform.localScale = new Vector3(0.5f, 0.5f, 1);  //face right
		}
	}

	private void CalculateDistance()
	{
		distance = Vector3.Distance(transform.position, player.transform.position);
		if (distance < minDistance)
		{
			if (player.transform.position.x > transform.position.x)
			{
				inRange = true;
				FlipEnemy(false);
				Attack(false);
			}
			else if (player.transform.position.x < transform.position.x)
			{
				inRange = true;
				FlipEnemy(true);
				Attack(true);
			}

			if (shootCooldown > 0)
			{
				shootCooldown -= Time.deltaTime;
			}
		}
		else
		{
			inRange = false;
		}
	}

	private void Attack(bool flip)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			audioManager.PlayAudio(3);
			if (flip)
			{
				Rigidbody2D bulletInstance = Instantiate(bal, geweer.transform.position, Quaternion.identity) as Rigidbody2D;
				bulletInstance.GetComponent<Rigidbody2D>().velocity = -transform.right * 10;
				Destroy(bulletInstance, 5f);
			}	
			else
			{
				Rigidbody2D bulletInstance = Instantiate(bal, geweer.transform.position, Quaternion.identity) as Rigidbody2D;
				bulletInstance.GetComponent<Rigidbody2D>().velocity = transform.right * 10;
				Destroy(bulletInstance, 5f);
			}
		}
	}
}