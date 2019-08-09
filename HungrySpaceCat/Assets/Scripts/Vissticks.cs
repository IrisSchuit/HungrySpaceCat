using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vissticks : MonoBehaviour
{
	public Player player;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			player.lives++;
			Destroy(this.gameObject);
		}
	}
}
