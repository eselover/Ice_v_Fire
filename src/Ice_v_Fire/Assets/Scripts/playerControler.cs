﻿using UnityEngine;
using System.Collections;

public class playerControler : MonoBehaviour {

	Vector2 velocity = new Vector2(0,0);
	public Vector2 acceleration = new Vector2(20f, 20f);
	public GameObject bullet;
	float timeUntilNextBullet = 0;
	public float bulletDelay = .25f;
	public float friction = 20f;
	public int health = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//update keys
		float dirx = Input.GetAxisRaw ("Horizontal");
		float diry = Input.GetAxisRaw ("Vertical");

		//bullet update
		BulletUpdate ();



		//Movement
		MovementUpdate (dirx, diry);

	}
	private void BulletUpdate(){
		if (Input.GetAxisRaw ("Jump") == 1) {
			if (timeUntilNextBullet < 0) {
				Instantiate (bullet, transform.position + new Vector3(0,.5f,0), Quaternion.identity);
				timeUntilNextBullet = bulletDelay;
			} else {
				timeUntilNextBullet -= Time.deltaTime;
			}
		} else {
			timeUntilNextBullet = 0;
		}
	}
	private void MovementUpdate(float dirx, float diry){
		Vector3 pos = transform.position;
		
		if (dirx == 0) { //no key pressed
			if (velocity.x > 0){
				velocity.x -= acceleration.x * Time.deltaTime * friction;
				if (velocity.x < 0) velocity.x = 0;
			}
			if (velocity.x < 0){
				velocity.x += acceleration.x * Time.deltaTime * friction;
				if (velocity.x > 0) velocity.x = 0;
			}
		} else { //left or right pressed
			velocity.x += acceleration.x * dirx * Time.deltaTime;
		}
		
		//vert movement
		
		if (diry == 0) { //no key pressed
			if (velocity.y > 0){
				velocity.y -= acceleration.y * Time.deltaTime * friction;
				if (velocity.y < 0) velocity.y = 0;
			}
			if (velocity.y < 0){
				velocity.y += acceleration.y * Time.deltaTime * friction;
				if (velocity.y > 0) velocity.y = 0;
			}
		} else { //left or right pressed
			velocity.y += acceleration.y * diry * Time.deltaTime;
		}
		
		
		pos.x += velocity.x * Time.deltaTime;
		pos.y += velocity.y * Time.deltaTime;
		
		//pos.x = Mathf.Clamp (pos.x, -8, 8);
		if (pos.x < -8) {
			pos.x = -8;
			//bounce
			velocity.x *= 0f;
		}
		if (pos.x > 8) {
			pos.x = 8;
			//bounce
			velocity.x *= 0f;
		}
		if (pos.y < -4.5f) {
			pos.y = -4.5f;
			//bounce
			velocity.y *= 0f;
		}
		if (pos.y > 4.5f) {
			pos.y = 4.5f;
			//bounce
			velocity.y *= 0f;
		}
		transform.position = pos;
	}
}