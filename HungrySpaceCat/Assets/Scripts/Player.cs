using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private int totalLives = 5;
	public int lives;

	private Animator anim;
	
	private void Start()
	{
		anim = GetComponent<Animator>();
		lives = totalLives;
		anim.Play("KatBounce");
	}

	private void Update()
	{
		UpdateLives();
	}

	private void UpdateLives()
	{
		if (lives == 0)
		{
			Destroy(this.gameObject);
		}

		if(lives >= totalLives)
		{
			lives = totalLives;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Bal")
		{
			lives--;
			Destroy(other.gameObject);
		}
	}
}