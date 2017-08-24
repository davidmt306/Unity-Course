using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {
	
	int min;
	int max;
	int guess;
	public int maxGuessesAllowed = 10;
	
	public Text text;

	void Start () {
		StartGame();
	}
	
	void StartGame () {
		
		min = 1;
		max = 1000;
		NextGuess();
	}
	
	public void GuessLower () {
		max = guess;
		NextGuess();
	}
	
	public void GuessHigher () {
		min = guess;
		NextGuess();
	}
	
	void NextGuess () {
		guess = Random.Range (min, max + 1);
		text.text = guess.ToString();
		maxGuessesAllowed = maxGuessesAllowed - 1;
		if (maxGuessesAllowed <= 0) {
			Application.LoadLevel("Win");
		}
		
	}
}
