using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float Speed = 5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 temp = transform.position;
		temp.y = -Camera.main.orthographicSize + transform.localScale.y/2;

		//if player ship moves(horizontal move)
		temp.x += Input.GetAxis ("Horizontal") * Speed * Time.deltaTime;

		//Set the boundaries
		float aspectratio = (float)Screen.width / (float)Screen.height;
		float widthlimit = aspectratio * Camera.main.orthographicSize;

		//left limit
		float leftlimit = (-widthlimit + (transform.localScale.x / 2));
		//Debug.Log ("leftlimit: "+leftlimit);
		if (temp.x < leftlimit) {
			temp.x = leftlimit;
		}
		//right limitx	
		float rightlimit = (widthlimit - (transform.localScale.x / 2));
		//Debug.Log ("rightlimit: "+rightlimit);
		if (temp.x > rightlimit) {
			temp.x = rightlimit;
		}

		//Change the object position
		transform.position = temp;

	}

	void OnGUI(){
		if (Player_shooting.health > 0) {
			GUI.Label (new Rect (0, 0, 100, 100), "Score : " + Player_shooting.score);
			GUI.Label (new Rect (0, 30, 100, 100), "Health : " + Player_shooting.health);
		} else {
			GUI.Label (new Rect (150, 150, 100, 100), "Game Over");
			
		}
	}


}
