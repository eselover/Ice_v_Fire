using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	//Jonathan Champion

	public float lifetime;

	void Start () {
		Destroy (gameObject, lifetime);
	}

}
