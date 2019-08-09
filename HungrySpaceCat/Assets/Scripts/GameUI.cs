using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
	public List<Image> imageLives = new List<Image>();
	private Player player;

	private int lives;

    // Start is called before the first frame update
    void Start()
    {
		player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
		lives = player.lives;

		for (int i = 0; i < imageLives.Count; i++)
		{
			if(i < lives)
			{
				imageLives[i].enabled = true;
			}
			else
			{
				imageLives[i].enabled = false;
			}
		}
    }
}
