using UnityEngine;
using System.Collections;

public class basicEnemyControler : MonoBehaviour {
	
	float fallspeed;
	public float fallSpeedMin = 3f;
	public float fallspeedMax = 6f;
	public int health = 1;
	// Use this for initialization
	void Start () {
		Reset ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//position
		Vector3 pos = transform.position;
		pos.y -= fallspeed * Time.deltaTime;
		transform.position = pos;
		
		//check if below cam & reset
		if (transform.position.y <= -8)
			Destroy(gameObject);
		//Check dead
		if (health <= 0)
			Destroy (gameObject);
	}
	void Reset(){
		transform.position = new Vector3 (Random.Range (-10, 10), Random.Range (8, 12), 0);
		fallspeed = Random.Range (fallSpeedMin, fallspeedMax);
	}
	
}
