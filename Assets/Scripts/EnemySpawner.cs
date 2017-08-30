using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f; 
	public float speed = 5f;
	public float enemySpeed = 2f;
	
	private bool movingRight = true;
	private float xMax;
	private float xMin;
	
	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
		xMax = rightBoundary.x;
		xMin = leftBoundary.x;
	
		foreach(Transform child in transform) {
			// Spawn an enemy
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			// Put the created enemies under Enemy Formation Game Object
			enemy.transform.parent = child;
		}
	}
	
	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		if(movingRight) {
			//transform.position += new Vector3(speed * Time.deltaTime, 0);
			transform.position += Vector3.right * enemySpeed * Time.deltaTime;
		} else {
			
			//transform.position += new Vector3(-speed * Time.deltaTime, 0);
			transform.position += Vector3.left * enemySpeed * Time.deltaTime;
		}
		
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		if(leftEdgeOfFormation < xMin || rightEdgeOfFormation > xMax) {
			movingRight =! movingRight;
		}
	}
}
