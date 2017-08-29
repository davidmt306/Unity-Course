using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public AudioClip lose;
	private LevelManager levelManager;
	private Ball ball;
	
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D (Collider2D collision) {
		print ("Trigger");
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (lose, transform.position);
		levelManager.LoadLevel("Lose");	
		
	}
}
