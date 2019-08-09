using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAction : MonoBehaviour
{
	public GameObject canvas;
	public Animator	animFG;
	public List<GameObject> flyingGrounds = new List<GameObject>();

	private Animator anim;
	private AudioManager audioManager;


	private void Start()
	{
		audioManager = FindObjectOfType<AudioManager>();
		canvas.SetActive(false);
		animFG = FindObjectOfType<Animator>();
		anim = GetComponent<Animator>();

		for (int i = 0; i < flyingGrounds.Count; i++)
		{
			flyingGrounds[i].SetActive(false);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			canvas.SetActive(true);
			if (Input.GetKeyDown(KeyCode.E))
			{
				audioManager.PlayAudio(1);
				anim.SetBool("Lever", true);
				for (int i = 0; i < flyingGrounds.Count; i++)
				{
					flyingGrounds[i].SetActive(true);
					animFG.SetBool("appear", true);
				}
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
