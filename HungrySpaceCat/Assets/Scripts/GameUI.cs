using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
	public TextMeshProUGUI enemyText;
	public List<Image> imageLives = new List<Image>();
	public List<GameObject> enemiesUI = new List<GameObject>();
	public string nextLevelName;
	public TextMeshProUGUI timer;
	public float timeLeft = 200;
	public GameObject holder;

	private Player player;
	private int lives;
	private int min;
	private int sec;
	private bool showing;


	private void Awake()
	{
		Time.timeScale = 1;
	}

	// Start is called before the first frame update
	private void Start()
    {
		holder.SetActive(false);
		player = FindObjectOfType<Player>();

		min = Mathf.FloorToInt(timeLeft / 60);
		sec = Mathf.FloorToInt(timeLeft % 60);

		timer.text = min.ToString("00" + ":" + sec.ToString("00"));
	}

    // Update is called once per frame
    private void Update()
    {
		EnemyCount();
		Timer();
		DisplayLives();
		Holder();
	}

	private void Holder()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			showing = !showing;
			holder.SetActive(showing);

			if (showing)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}
		}

		if (holder.activeInHierarchy)
		{
			if (Input.GetKeyDown(KeyCode.X))
			{
				SceneManager.LoadScene("Menu");
			}
			if (Input.GetKeyDown(KeyCode.R))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	private void DisplayLives()
	{
		lives = player.lives;

		for (int i = 0; i < imageLives.Count; i++)
		{
			if (i < lives)
			{
				imageLives[i].enabled = true;
			}
			else
			{
				imageLives[i].enabled = false;
			}
		}
	}

	private void Timer()
	{
		min = Mathf.FloorToInt(timeLeft / 60);
		sec = Mathf.FloorToInt(timeLeft % 60);
		timer.text = min.ToString("00") + ":" + sec.ToString("00");
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0)
		{
			SceneManager.LoadScene("Lose");
		}
	}

	private void EnemyCount()
	{
		enemyText.text = "" + enemiesUI.Count + " x";

		if(enemiesUI.Count == 0)
		{
			StartCoroutine("NextScene");
		}
	}

	IEnumerator NextScene()
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(nextLevelName);
	}
}
