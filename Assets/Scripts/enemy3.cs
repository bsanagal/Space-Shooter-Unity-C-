using UnityEngine;
using System.Collections;

public class enemy3 : MonoBehaviour {

	private Vector3 temp;
	private float verticalspeed = 1f;
	private float horispeed = 1f;
	private float horidirection = 1f;
	public GameObject ebullet;
	private float bulletdelay = 0.75f; //to handle the flow of bullets from enemy 
	private float bullettimer = 0f;
    public GameObject blast;

    // Use this for initialization
    void Start () {
		startpoint (4);
	}
	
	// Update is called once per frame
	void Update () {
		if (Player_shooting.health <= 0) {
			
			Destroy (this);
		} else {
			temp.y -= verticalspeed * Time.deltaTime;
			//if(temp
			if (horidirection == -1) {
				temp.x += horispeed * Time.deltaTime;
			} else if (horidirection == 1) {
				temp.x -= horispeed * Time.deltaTime;
			}
			//Debug.Log ("x value: " + temp.x);
			//Debug.Log ("deltatime: " + Time.deltaTime);
			//Debug.Log ("y Value: " + temp.y);
			transform.position = temp;
			if (transform.position.y < - (Camera.main.orthographicSize + transform.localScale.y / 2)) {
				startpoint (0);
			}
			//enemy ship left-right and right-left control
			float aspectratio = (float)Screen.width / (float)Screen.height;
			float widthlimit = aspectratio * Camera.main.orthographicSize;
			float leftlimit = (-widthlimit + (transform.localScale.x / 2));
		
			if (transform.position.x < leftlimit) {
				horidirection = -1;
			}
		
			float rightlimit = (widthlimit - (transform.localScale.x / 2));
			if (transform.position.x > rightlimit) {
				horidirection = 1;
			}

			//enemy bullet
			Vector3 tempbullet = transform.position;
			tempbullet.y = transform.position.y - transform.localScale.y / 2;
			bullettimer -= Time.deltaTime;
			if (bullettimer <= 0) {
				Instantiate (ebullet, tempbullet, transform.rotation);
				bullettimer = bulletdelay;
			}
		}
	}
	void startpoint(float t){
		temp = transform.position;
		
		float aspectratio = (float)Screen.width / (float)Screen.height;
		float widthlimit = aspectratio * Camera.main.orthographicSize;
		
		temp.x = Random.Range (-widthlimit, widthlimit);
		temp.y = Camera.main.orthographicSize + t;
		transform.position = temp;
		if (temp.x >= 0) {
			horidirection *= 1;
		} else {
			horidirection *= -1;
		}
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "bullet") {
			Player_shooting.score++;
			GetComponent<AudioSource>().Play();
            Instantiate(blast, transform.position, transform.rotation);
            startpoint (0);
			Debug.Log ("bullet");
          
		}
		if (target.tag == "player") {
			Player_shooting.health--;
			Instantiate(blast, transform.position,transform.rotation);
			startpoint (0);
			
		}
	}
}
