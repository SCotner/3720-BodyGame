using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject enemy;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private string gameState;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText startUpText;

	private bool gameOver;
	private bool restart;
	private bool startUp;
	public int score;

	void Start()
	{
		startUp = true;
		startUpText.text = "Hit the W key to play with the keyboard or " +
			"\n click the mouse to play with the mouse.";
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
	}

	void GameStart()
	{
		startUpText.text = "";
		score = 0;
		UpdateScore();
		StartCoroutine (SpawnWaves ());

	}

	void Update()
	{
		if (startUp) {
			if (Input.GetKeyDown (KeyCode.W))
			{
				gameState = "Keys";
				startUp = false;
				GameStart ();
			}
			else if (Input.GetMouseButtonDown(0))
			{
				Debug.Log (startUp);
				gameState = "Mouse";
				startUp = false;
				GameStart ();
			}
		}
		if (restart) {
			if(Input.GetKeyDown (KeyCode.R))
			   {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			Instantiate(enemy);
			yield return new WaitForSeconds (waveWait);

			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	public string getGameState()
	{
		return gameState;
	}

	public bool getStartUp()
	{
		return startUp;
	}

}
