using UnityEngine;
using System.Collections;

public class Mouth : MonoBehaviour {

    private Transform ball;
    public float maxHeight = 7.25f;
    public float minHeight = 4.5f;
    public float maxYScale = 0.35f;


    public bool isRightPlayer = false;

	// Use this for initialization
	void Start () {
        this.isRightPlayer = (transform.root.position.x > 0f);
        {
            ball = GameObject.FindGameObjectWithTag("Ball").transform;
        };
    }
	
	// Update is called once per frame
	void Update () {

        if (!ball) //Somehow lost the ball
            ball = GameObject.FindGameObjectWithTag("Ball").transform;

        float ballHeight = ball.position.y;
        float scaredFactor = (ballHeight - minHeight) / maxHeight;

        float heightScare = Mathf.Lerp(0f, maxYScale, scaredFactor);

        float goalExcited = 0f;
        float goalScare = 0f;

        if (ball.position.y < 2.75f)
        {
            goalExcited = Mathf.Lerp(0f, maxYScale, (ball.position.x - 6.75f) / 2f);
            goalScare = Mathf.Lerp(0f, maxYScale, (ball.position.x + 6.75f) / -2f);

            if (!isRightPlayer)
            {
                float t = goalExcited;
                goalExcited = goalScare;
                goalScare = t;
            }
        }

        float yScale = Mathf.Clamp(heightScare + goalExcited - goalScare, -maxYScale*0.85f, maxYScale);
        this.transform.localScale = new Vector3(this.transform.localScale.x, yScale, this.transform.localScale.z);
	}
}
