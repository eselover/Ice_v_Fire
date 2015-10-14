using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp = 1;
	public bool isEnemy = true;


	public void Damage(int damageCount){
		hp -= damageCount;

		if (hp <= 0) {
			Destroy (gameObject);
		}
		
	}
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		Debug.Log ("hit");
		// Is this a shot?
		bulletBehavior bullet = otherCollider.gameObject.GetComponent<bulletBehavior>();
		if (bullet != null){
			// Avoid friendly fire
			if (bullet.isEnemyShot != isEnemy){
				Damage(bullet.damage);
				
				// Destroy the shot
				Destroy(bullet.gameObject); 
			}
		}
	}
}
