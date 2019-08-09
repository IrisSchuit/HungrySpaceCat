using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAction : MonoBehaviour
{
	public GameObject canvas;
	private Animator anim;

	private void Start()
	{
		canvas.SetActive(false);
		anim = GetComponent<Animator>();
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			canvas.SetActive(true);
			if (Input.GetKeyDown(KeyCode.E))
			{
				anim.SetBool("Lever", true);
				//OPEN IETS OF DOE IETS
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			canvas.SetActive(false);
		}
	}
}
