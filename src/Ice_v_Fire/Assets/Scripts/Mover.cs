using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	//Jonathan Champion
	public float speed;
	void Start (){
		//move bolt forward
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
