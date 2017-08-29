using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	private GameObject smokePuff;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		if (isBreakable) {
			HandleHits();	
		}	
	}
	
	// TODO Remove the method when we can win
	
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
	
	void HandleHits () {
		timesHit ++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(smokePuff, 1f);
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint (crack, transform.position);
		} else {
			LoadSprites();
		}
	}
	
	void PuffSmoke() {
		smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Brick sprite missing!");
		}	
	}
}
