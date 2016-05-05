using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject ballPrefab;
    public GameObject player1, player2;
    public bool slowMo;

    private Vector2 ballSpawn, player1Spawn, player2Spawn;

    public int player1Score = 0, player2Score = 0;

    public static Game instance;

    private bool hasScored = false;

    void Awake()
    {
        ballSpawn = GameObject.FindGameObjectWithTag("Ball").transform.position;
        player1Spawn = player1.transform.position;
        player2Spawn = player2.transform.position;
        instance = this;
    }

	// Use this for initialization
	void Start () {
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
	
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

        if (slowMo)
        {
            Time.timeScale = 0.1f;
        }
        Invoke("Reset", 0.1f);
        hasScored = true;

        
    }

    private void Reset()
    {
        ResetBall();
        ResetGameObject(player1, player1Spawn);
        ResetGameObject(player2, player2Spawn);

        Time.timeScale = 1f;
        hasScored = false;
    }

    private void ResetBall()
    {
        foreach (var b in GameObject.FindGameObjectsWithTag("Ball"))
        {
            Destroy(b);
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
