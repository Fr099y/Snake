using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed = 0;
	
	private GameManager gameManager;

	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate ()
	{
		if (gameManager.getIsGameRunning()) {
			if (Input.touches.Length > 0) {
					Touch touch = Input.GetTouch (0);
					float moveHorizontal = touch.position.x > Screen.width / 2 ? 1 : -1;
					Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0);
					rigidbody2D.velocity = movement * speed;
	
					if (gameObject.transform.position.x <= -24 || gameObject.transform.position.x >= 24)
							collideWithWall ();
			} else {
					stopHorizontalMoving ();
			}
		} else {
			if (Input.touches.Length > 0) {
				gameManager.startGame();
			}
		}
			
	}

	private void stopHorizontalMoving(){
		Vector3 movement = new Vector3 (0, 0.0f, 0);
		rigidbody2D.velocity = movement * speed;
	}

	private void collideWithWall(){
		gameManager.endGame ();
		stopHorizontalMoving ();
	}


	void OnCollisionEnter2D(Collision2D coll) {
		gameManager.endGame ();
	}
}
