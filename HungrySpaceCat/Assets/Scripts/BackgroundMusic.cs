using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
	private static BackgroundMusic instance;

	public AudioSource audioSource;

	void Awake()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Muziek");
		if (objs.Length > 1)
			Destroy(this.gameObject);

		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		if (SceneManager.GetActiveScene().name == "Win" || SceneManager.GetActiveScene().name == "Lose" || SceneManager.GetActiveScene().name == "Menu")
		{
			Destroy(this.gameObject);
		}
	}
}