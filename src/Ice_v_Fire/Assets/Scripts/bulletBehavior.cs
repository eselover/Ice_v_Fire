using UnityEngine;
using System.Collections;

public class bulletBehavior : MonoBehaviour {
	public float speed = 10f;
	public int damage = 1;
	public bool isEnemyShot = false;
	
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5);

	}
	
	// Update is called once per frame
	void Update () {
		//if (isEnemyShot) speed *= -1;
		Vector3 pos = transform.position;
		pos.y += speed * Time.deltaTime;
		transform.position = pos;
		
		if (pos.y > 8 || pos.y < -8) Destroy (gameObject);
		
		
	}

	
}
