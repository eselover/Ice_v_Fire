using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	//Jonathan Champion

	public float tumble;

	void Start(){
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble; 
	}
}
