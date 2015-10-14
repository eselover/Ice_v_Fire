using UnityEngine;
using System.Collections;

public class basicEnemyControler : MonoBehaviour {
	
	float fallspeed;
	public float fallSpeedMin = 3f;
	public float fallspeedMax = 6f;
	public GameObject bullet;
	float timeUntilNextBullet = 0;
	public float bulletDelay = .45f;

	bool firing = true;

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

		//fire
		BulletUpdate ();
		
		//check if below cam & reset
		if (transform.position.y <= -8)
			Destroy(gameObject);
	}
	private void BulletUpdate(){
		if (firing) {
			if (timeUntilNextBullet < 0) {
				Instantiate (bullet, transform.position + new Vector3(0,-.5f,0), Quaternion.identity);
				timeUntilNextBullet = bulletDelay;
			} else {
				timeUntilNextBullet -= Time.deltaTime;
			}
		} else {
			timeUntilNextBullet = 0;
		}
	}
	void Reset(){
		transform.position = new Vector3 (Random.Range (-10, 10), Random.Range (8, 12), 0);
		fallspeed = Random.Range (fallSpeedMin, fallspeedMax);
	}
	
}
