using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 15.0f;
	public float padding = 1f;
	public float projectileSpeed;
	public float firingRate;
	public float health;

	public GameObject projectile;
	float xmin;
	float xmax;

	void Start () {
		// Obtiene las coordenadas de las esquinas de la pantalla de juego.
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector2 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));

		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}

	void Fire () {
		Vector3 startPosition = transform.position + new Vector3 (0, 1, 0);
		GameObject beam = Instantiate (projectile, startPosition, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
	}

	void Update () {
		// Crear el laser en la posicion del jugador cuando presiono espacio y darle direccion
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.000001f, firingRate);
		} 

		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			//transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow) ){
			//transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		// Restrcit the player to the game space
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
				Destroy (gameObject);
			}
			//Debug.Log ("Hit by a projectile");
		}
	}
}
