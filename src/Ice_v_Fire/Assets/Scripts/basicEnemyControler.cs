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


	void Start () {
		Reset ();
	}

	void Update () {
		
		MoveUpdate ();

		BulletUpdate ();
		

	}
	/// <summary>
	/// Move enemy according to fallspeed
	/// </summary>
	private void MoveUpdate(){
		//position
		Vector3 pos = transform.position;
		pos.y -= fallspeed * Time.deltaTime;
		transform.position = pos;

		//check if below cam & reset
		if (transform.position.y <= -8)
			Destroy(gameObject);
	}
	/// <summary>
	/// Check if shooting, instantiate bullets, update cooldown
	/// </summary>
	private void BulletUpdate(){
		if (firing) {
			//check to see if it is time to fire
			if (timeUntilNextBullet < 0) {
				Instantiate (bullet, transform.position + new Vector3(0,-.5f,0), Quaternion.identity);
				timeUntilNextBullet = bulletDelay;
			} else {
				//subtract from countdown timer
				timeUntilNextBullet -= Time.deltaTime;
			}
		} else {
			//if not firing set waittime to 0
			timeUntilNextBullet = 0;
		}
	}
	/// <summary>
	/// reset position to top UNUSED FUNCTION
	/// </summary>
	void Reset(){
		transform.position = new Vector3 (Random.Range (-10, 10), Random.Range (8, 12), 0);
		fallspeed = Random.Range (fallSpeedMin, fallspeedMax);
	}
	
}
