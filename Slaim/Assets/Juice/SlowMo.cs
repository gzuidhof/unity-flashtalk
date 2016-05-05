using UnityEngine;
using System.Collections;

public class SlowMo : MonoBehaviour {

    public float timeScale = 0.1f;

	// Use this for initialization
	void Start () {
        Game.instance.OnGameStart += () => Time.timeScale = 1f;
        Game.instance.OnGoal += () => Time.timeScale = timeScale;
    }


}
