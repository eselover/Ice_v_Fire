using UnityEngine;
using System.Collections;

public class gameBehavior : MonoBehaviour {
	public GameObject enemyPrefab;

	
	
	void Start () {

		StartCoroutine ("SpawnEnemies");
	}
	
	
	void Update () {	
		
	}
	/// <summary>
	/// Spawn Enemies continuously 
	/// </summary>
	IEnumerator SpawnEnemies(){
		while (true) { //loop
			for (int i = 0; i < 15; i++) {
				//spawn enemies
				Instantiate(enemyPrefab);
				yield return new WaitForSeconds(0.5f);

			}
			yield return new WaitForSeconds (4);
		}
	}
}
