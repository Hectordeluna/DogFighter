using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	private float time = 0.2f;
	public GameObject Bullet;

	void Start () {
		ObjectPool.CreatePool(Bullet,10);
	}

    void Update()
    {

    	time -= Time.deltaTime;

		if(time < 0 && Input.GetMouseButton(0)){
			ObjectPool.Spawn(Bullet,transform.position, transform.rotation);
			time = 0.2f;
		}

        var pos = Camera.main.WorldToScreenPoint(transform.position);
     var dir = Input.mousePosition - pos;
     var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
     transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
    }

   
}
