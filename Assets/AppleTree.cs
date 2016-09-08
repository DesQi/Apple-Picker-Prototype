using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	public GameObject applePrefab;

	public float speed = 10f;

	public float leftAndRightEdge = 20f;

	public float chanceToChangeDirections = 0.02f;

	public float secondsBetweenAppleDrops = 1f;

	// Use this for initialization
	void Start () {
		// Dropping apples every second
		InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
	}

	void DropApple() {
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Basic Movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		// Changing Direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed);
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed);
		} 
	}

	void FixedUpdate() {
		if (Random.value < chanceToChangeDirections) {
			speed *= -1; 
		}
	}
}
