using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemyPrefab;
	// Use this for initialization
	void Start () {
		foreach(Transform child in transform) {
			// Spawn an enemy
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			// Put the created enemies under Enemy Formation Game Object
			enemy.transform.parent = child;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
