using UnityEngine;
using System.Collections;

public class BallShake : MonoBehaviour {

    private static int playerLayer = LayerMask.NameToLayer("Players");
    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        //Is player or (other) ball (and not goal post)
        if (coll.gameObject.CompareTag("Ball")) return;
        if (coll.gameObject.layer == playerLayer && !coll.gameObject.name.StartsWith("goal")) return;


        float velocity = rb.velocity.magnitude;
        if (velocity < 3f) return;

        float shakeIntensity = velocity / 15f;
        Debug.Log(velocity + "" + shakeIntensity);

        Game.instance.camera.GetComponent<Shaker>().Shake(shakeIntensity);
    }
}
