using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Transform Player;
	public Rigidbody2D rigidbody2d;
	public float speed;
	public GameObject Bullet;
	public float time;
	private float timeb;
	public Transform Gun;

	private bool Spotted = false;

	// Use this for initialization
	void Start () {
	Player = GameObject.FindWithTag("Player").transform;
	time = Random.Range(0.4f,2f);
	timeb = time;
	ObjectPool.CreatePool(Bullet,20);
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;

		if(time < 0){
			ObjectPool.Spawn(Bullet,Gun.position,Gun.rotation);
			time = timeb;
		}
		

		  //rotate to look at the player
         transform.LookAt(Player.position);
         transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation
	
          if (Vector3.Distance(transform.position,Player.position)>1f && transform.position.y < Player.position.y){//move if distance from target is greater than 1
             transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
             rigidbody2d.gravityScale = 0;
         } else {
         	rigidbody2d.gravityScale = 1;
         }

	}

	// void FixedUpdate(){
	// 	if(transform.position.y < Player.position.y){
	// 		rigidbody2d.AddRelativeForce(new Vector2(speed,0));
	// 	}

	// 	if(rigidbody2d.velocity.magnitude > 40)
 //         {
 //                rigidbody2d.velocity = rigidbody2d.velocity.normalized * 40;
 //         }

	// }
}
