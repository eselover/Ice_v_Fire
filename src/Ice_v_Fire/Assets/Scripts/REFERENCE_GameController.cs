using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	//Jonathan Champion

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	private int score;

	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;

	//spawn enemy waves
	void Start () {

		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	//check if restart
	void Update() {
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	//waves enumerator
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		//loop
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				//pause between spawn
				yield return new WaitForSeconds (spawnWait);
			}
			//pause between waves
			yield return new WaitForSeconds (waveWait);

			//check if game over
			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	//public function to add score from other objects
	public void AddScore (int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}
	//update score
	void UpdateScore (){
		scoreText.text = "Score: " + score;
	}

	public void GameOver () {
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}