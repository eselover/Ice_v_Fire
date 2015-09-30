using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
	//Jonathan Champion

	//destroy objects if they leave box
	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}
}
