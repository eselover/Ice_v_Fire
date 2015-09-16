using UnityEngine;
using System.Collections;

public class gameBehavior : MonoBehaviour {
	public GameObject enemyPrefab;
	float timeUntilNextSpawn = 0;
	
	
	void Start () {

		StartCoroutine ("SpawnEnemies");
	}
	
	
	void Update () {	
		
	}
	IEnumerator SpawnEnemies(){
		while (true) {
			Instantiate(enemyPrefab);
			yield return new WaitForSeconds(0.5f);
		}
	}
}
