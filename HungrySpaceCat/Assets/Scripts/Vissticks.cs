using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vissticks : MonoBehaviour
{
	public Player player;
	private AudioManager audioManager;

	private void Start()
	{
		audioManager = FindObjectOfType<AudioManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			audioManager.PlayAudio(2);
			player.lives++;
			Destroy(this.gameObject);
		}
	}
}
