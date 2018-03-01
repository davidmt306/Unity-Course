using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
		Destroy (col.gameObject);
	}
}
