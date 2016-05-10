using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Game : MonoBehaviour {

    public GameObject ballPrefab;
    public GameObject player1, player2;

    private Vector2 ballSpawn, player1Spawn, player2Spawn;

    public int player1Score = 0, player2Score = 0;

    public static Game instance;

    private bool hasScored = false;

    public delegate void EventHandler();

    public event EventHandler OnGameStart;
    public event EventHandler OnGoal;

    public float afterGoalTime = 0.115f;

    void Awake()
    {
        ballSpawn = GameObject.FindGameObjectWithTag("Ball").transform.position;
        player1Spawn = player1.transform.position;
        player2Spawn = player2.transform.position;
        instance = this;
    }

	// Use this for initialization
	void Start()
    {
        Reset();
	}


    public void Goal(int team)
    {
        if (hasScored)
        {
            return;
        }
        if (team == 1)
        {
            player2Score++;
        }
        else
        {
            player1Score++;
        }
        Invoke("Reset", afterGoalTime);
        hasScored = true;

        if (OnGoal != null)
            OnGoal.Invoke();
        
    }

    private void Reset()
    {
        ResetBall();
        ResetGameObject(player1, player1Spawn);
        ResetGameObject(player2, player2Spawn);
        hasScored = false;

        if (OnGameStart != null)
            OnGameStart.Invoke();
    }

    private void ResetBall()
    {
        foreach (var b in GameObject.FindGameObjectsWithTag("Ball"))
        {
            DestroyImmediate(b);
        }

        var ball = Instantiate(ballPrefab, ballSpawn, Quaternion.identity) as GameObject;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.down * Random.Range(10f, 30f);
    }

    private void ResetGameObject(GameObject go, Vector2 pos)
    {
        go.transform.position = pos;
        go.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }


}
