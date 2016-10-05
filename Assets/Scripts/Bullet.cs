using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	public Rigidbody2D rigidbody2d;
	public float time = 2f;

	// Use this for initialization
	void Update () {
	time -= Time.deltaTime;
	if(time < 0){
		ObjectPool.Recycle(gameObject);
		time = 2f;
	}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		rigidbody2d.AddRelativeForce(new Vector3(0,speed,0),ForceMode2D.Impulse);
	
	}
}
