using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public Text left;
    public Text right;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        left.text = "" + Game.instance.player1Score;
        right.text = "" + Game.instance.player2Score;
	}
}
