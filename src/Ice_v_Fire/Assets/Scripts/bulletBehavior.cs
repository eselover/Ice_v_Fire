using UnityEngine;
using System.Collections;

public class bulletBehavior : MonoBehaviour {
	public float speed = 10f;
	public int damage = 1;
	public bool isEnemyShot = false;
	
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 15);

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.y += speed * Time.deltaTime;
		transform.position = pos;
		
		if (pos.y > 8) Destroy (gameObject);
		
		
	}

	
}
