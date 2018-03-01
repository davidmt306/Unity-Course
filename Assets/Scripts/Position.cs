using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {
	// Funcion para dibujar los gizmos en el editor
	void OnDrawGizmos () {
		Gizmos.DrawWireSphere (transform.position, 1);
	}
}
