using UnityEngine;
using System.Collections;

public class bulletBehavior : MonoBehaviour {
	public float speed = 10f;
	
	// Use this for initialization
	void Start () {
		//GameObject cannon = GameObject.Find ("Canon");
		//transform.position = cannon.transform.position;
		
		//MeshRenderer comp = GetComponent<MeshRenderer> ();
		//comp.material.color = new Color (1f, 1f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.y += speed * Time.deltaTime;
		transform.position = pos;
		
		if (pos.y > 8) Destroy (gameObject);
		
		
	}
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "enemy") {
			col.GetComponent<health>--;
			Destroy (gameObject);
		}
		
	}
	
}
