using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D collision) {
		print ("Trigger");
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision");
		levelManager.LoadLevel("Win");
	}
}
