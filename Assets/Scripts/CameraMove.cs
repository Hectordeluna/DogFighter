using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
private float rightBound;
 private float leftBound;
 private float topBound;
 private float bottomBound;
 private Vector3 pos;
 private Transform target;
 private SpriteRenderer spriteBounds;
 private Transform SpriteTrans;

 public float OffsetX;
 public float OffsetY;
 
 // Use this for initialization
 void Start () 
 {
     float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;  
     float horzExtent = vertExtent * Screen.width / Screen.height;
     spriteBounds = GameObject.Find("1 - Background").GetComponent<SpriteRenderer>();
     SpriteTrans = GameObject.Find("1 - Background").GetComponent<Transform>();
     target = GameObject.FindWithTag("Player").transform;
     leftBound = (float)(horzExtent - (spriteBounds.sprite.bounds.size.x * SpriteTrans.localScale.x) / 2.0f + SpriteTrans.position.x);
     rightBound = (float)((spriteBounds.sprite.bounds.size.x * SpriteTrans.localScale.x)  / 2.0f - horzExtent + SpriteTrans.position.x);
     bottomBound = (float)(vertExtent - (spriteBounds.sprite.bounds.size.y * SpriteTrans.localScale.y)  / 2.0f + SpriteTrans.position.y);
     topBound = (float)((spriteBounds.sprite.bounds.size.y * SpriteTrans.localScale.y)  / 2.0f - vertExtent + SpriteTrans.position.y);
 }
 
 // Update is called once per frame
 void Update () 
 {
     //Debug.Log();
     var pos = new Vector3(target.position.x, target.position.y, transform.position.z);
     pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
     pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
     transform.position = new Vector3(pos.x + OffsetX, pos.y + OffsetY,-30);
 }
 void OnLevelWasLoaded()
 {
     Start();
 }
}
