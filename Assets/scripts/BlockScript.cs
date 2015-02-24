using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {


	void Start () {
		rigidbody2D.AddForce (new Vector2(0, -1000f));
	}
	
	// Update is called once per frame
	void Update () {

	}
}
