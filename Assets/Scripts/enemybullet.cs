using UnityEngine;
using System.Collections;

public class enemybullet : MonoBehaviour {

	public float speed = 5.0f;
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.position;
		temp.y -= speed * Time.deltaTime;
		transform.position = temp;
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "player") {
			Destroy (gameObject);
		}
	}
}
