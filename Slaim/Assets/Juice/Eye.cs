using UnityEngine;
using System.Collections;

public class Eye : MonoBehaviour {

    public Transform ball;

    public Transform pupil;
    public float pupilOffset = 0.1f;

	// Use this for initialization
	void Start ()
	{
        Game.instance.OnGameStart += () =>
        {
            ball = GameObject.FindGameObjectWithTag("Ball").transform;
        };
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = (ball.position - transform.position).normalized * pupilOffset;
        pupil.transform.position = transform.position + offset;
	}


}
