using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject smallBlock;
	public GameObject midBlock;
	public GameObject bigBlock;
	public GameObject biggestBlock;

	private float blockStep = 1.5f;
	public bool isGameRunning = false;

	void Start () {
		startGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
	}

	private void createBlock(){
//		blockType7 ();
		int whichBlock = Random.Range (1,7);
		Invoke ("blockType"+whichBlock, 0);

//		switch (whichBlock) {
//		case 0: 
//			smallBlock.transform.position = getRandPosition(smallBlock);
//			Instantiate(smallBlock); 
//			break;
//		case 1: 
//			midBlock.transform.position = getRandPosition(midBlock);
//			Instantiate(midBlock); 
//			break;
//		case 2: 
//			bigBlock.transform.position = getRandPosition(bigBlock);
//			Instantiate(bigBlock); 
//			break;
//		case 3: 
//			biggestBlock.transform.position = getRandPosition(biggestBlock);
//			Instantiate(biggestBlock); 
//			break;
//		default: break;
//		}
	}

	private Vector3 getRandPosition(GameObject gameobject){
		Debug.Log ("X = "+gameobject.renderer.bounds.size.x);
		float randX = Random.Range (-24+gameobject.renderer.bounds.size.x, 24-gameobject.renderer.bounds.size.x);
		Vector3 randPosition = new Vector3 (randX, 50, 0);
		return randPosition;
	}

	private void blockType1(){
		biggestBlock.transform.position = new Vector3 (-21.5f, 50, 0);
		Instantiate (biggestBlock);
		bigBlock.transform.position = new Vector3 (10, 50, 0);
		Instantiate (bigBlock);
	}

	private void blockType2(){
		bigBlock.transform.position = new Vector3 (-21.5f, 50, 0);
		Instantiate (bigBlock);
		biggestBlock.transform.position = new Vector3 (5, 50, 0);
		Instantiate (biggestBlock);
	}

	private void blockType3(){
		smallBlock.transform.position = new Vector3 (-21.5f, 50, 0);
		Instantiate (smallBlock);

		smallBlock.transform.position = new Vector3 (-7, 50, 0);
		Instantiate (smallBlock);

		smallBlock.transform.position = new Vector3 (8, 50, 0);
		Instantiate (smallBlock);

		smallBlock.transform.position = new Vector3 (21.5f, 50, 0);
		Instantiate (smallBlock);
	}

	private void blockType4(){
		midBlock.transform.position = new Vector3 (-12, 50, 0);
		Instantiate (midBlock);

		midBlock.transform.position = new Vector3 (8, 50, 0);
		Instantiate (midBlock);
	}

	private void blockType5(){
		smallBlock.transform.position = new Vector3 (-21.5f, 50, 0);
		Instantiate (smallBlock);

		biggestBlock.transform.position = new Vector3 (-8.2f, 50, 0);
		Instantiate (biggestBlock);

		smallBlock.transform.position = new Vector3 (21.5f, 50, 0);
		Instantiate (smallBlock);
	}

	private void blockType6(){
		midBlock.transform.position = new Vector3 (-21.5f, 50, 0);
		Instantiate (midBlock);

		midBlock.transform.position = new Vector3 (1, 50, 0);
		Instantiate (midBlock);

		smallBlock.transform.position = new Vector3 (21.5f, 50, 0);
		Instantiate (smallBlock);
	}

	private void blockType7(){
		smallBlock.transform.position = new Vector3 (-21.5f, 50, 0);
		Instantiate (smallBlock);

		midBlock.transform.position = new Vector3 (-8, 50, 0);
		Instantiate (midBlock);

		bigBlock.transform.position = new Vector3 (10.4f, 50, 0);
		Instantiate (bigBlock);
	}

	public void startGame(){
		InvokeRepeating ("createBlock", 0, blockStep);
		isGameRunning = true;
	}

	public void endGame(){
		GameObject[] blocks = GameObject.FindGameObjectsWithTag ("Block");
		for (int i = 0; i<blocks.Length; i++) {
			Destroy(blocks[i]);
		}
		CancelInvoke();
		isGameRunning = false;
	}

	public bool getIsGameRunning(){
		return isGameRunning;
	}
}
