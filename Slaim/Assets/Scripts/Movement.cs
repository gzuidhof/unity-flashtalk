using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode jumpKey = KeyCode.UpArrow;

    public float movementSpeed = 16f;
    public float jumpSpeed = 5f;

    public float maxJumpEnergy = 0.1f;
    private float jumpEnergy = 0f;

    public float snappiness = 7.5f;

    new private Rigidbody2D rigidbody;
    

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
    void MoveUpdate()
    {
        float currentSpeed = rigidbody.velocity.x;
        float desiredSpeed = 0f;

        if (Input.GetKey(moveRightKey))
        {
            desiredSpeed += movementSpeed;
        }

        if (Input.GetKey(moveLeftKey))
        {
            desiredSpeed += -movementSpeed;
        }

        float newSpeed = Mathf.Lerp(currentSpeed, desiredSpeed, snappiness * Time.deltaTime);
        rigidbody.velocity = new Vector2(newSpeed, rigidbody.velocity.y);

    }

    void JumpUpdate()
    {
        if (jumpEnergy > 0 && Input.GetKey(jumpKey))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
            jumpEnergy -= Time.deltaTime;
        }
        else
        {
            jumpEnergy = 0f;
        }

        if (transform.position.y <= 0.1f)
        {
            jumpEnergy = maxJumpEnergy;
        }

    }


	// Update is called once per frame
	void Update () {
        MoveUpdate();
        JumpUpdate();
    }
}
