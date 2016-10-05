using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {

	private float timer = 5f;

	// Use this for initialization
	void OnEnable () {
	timer = 5f;
	}
	
	// Update is called once per frame
	void Update () {
	timer -= Time.deltaTime;

	if(timer < 0){
		ObjectPool.Recycle(gameObject);
	}
	}

	void OnTriggerEnter2D(Collider2D Col){
		if(Col.gameObject.tag == "Bullet"){
			ObjectPool.Recycle(Col.gameObject);
			ObjectPool.Recycle(gameObject);

		}
	}
}
