using UnityEngine;
using System.Collections;

public class Player_shooting : MonoBehaviour {

	public float firedelay = 0.2f;
	private float timer = 0.0f;
	public GameObject bullet;
	public GameObject blast;
	public static int score = 0;
	public static float health = 20.0f;

	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			Destroy(this);
		} else {
			timer -= Time.deltaTime;
			if (Input.GetButton ("Jump") && timer <= 0) {

				//Debug.Log("shoot---------->");
				Vector3 temp = transform.position;
				temp.y = transform.position.y + transform.localScale.y / 2;
				Instantiate (bullet, temp, transform.rotation);
				GetComponent<AudioSource>().Play();
				timer = firedelay;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "enemyBullet")
			health-=0.5f;

	}

}
