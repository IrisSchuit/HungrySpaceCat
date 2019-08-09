using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
	public void PlayGame(string levelnaam)
	{
		SceneManager.LoadScene(levelnaam);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}