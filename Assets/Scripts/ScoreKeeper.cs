﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public static int score;
	private Text myText;

	void Start () {
		myText = GetComponent<Text> ();
		Reset ();
	}

	public void Score (int points) {
		score += points;
		myText.text = score.ToString();
	}

	public static void Reset () {
		score = 0;
	}
}
