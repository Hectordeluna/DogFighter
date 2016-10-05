using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public Rigidbody2D rigidbody2d;
	public float speed;
	public float RotSpeed;

	public float maxSpeed = 50f;


    void Update(){

        transform.Rotate(new Vector3(0,0,-Input.GetAxis("Horizontal") * RotSpeed * 10 * Time.deltaTime));

    }
	
	// Update is called once per frame
	void FixedUpdate () {

		rigidbody2d.AddRelativeForce(new Vector3(0,Input.GetAxis("Vertical") * speed,0),ForceMode2D.Force);
		

		if(rigidbody2d.velocity.magnitude > maxSpeed)
         {
                rigidbody2d.velocity = rigidbody2d.velocity.normalized * maxSpeed;
         }

	}
}
