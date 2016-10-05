using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float timer = 0.1f;
	public GameObject Bomb;
	public Transform Player;

	// Use this for initialization
	void Start () {
	ObjectPool.CreatePool(Bomb,20);
	}
	
	// Update is called once per frame
	void Update () {
	timer -= Time.deltaTime;

		if(timer < 0){
			ObjectPool.Spawn(Bomb,new Vector3(Random.Range(Player.position.x - 10,Player.position.x + 10),10,0),transform.rotation);
			timer = 0.1f;
		}
	}
}
