﻿using UnityEngine;
using System.Collections;

public class BallShake : MonoBehaviour {

    private static int playerLayer = LayerMask.NameToLayer("Players");
    private Rigidbody2D rb;
    private HueModulator cameraColor;

    public bool flashScreen = false;

    private new GameObject camera;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        camera = GameObject.Find("Main Camera");
        cameraColor = camera.GetComponent<HueModulator>();
    }


    void OnCollisionEnter2D(Collision2D coll)
    {

        float velocity = rb.velocity.magnitude;
        if (velocity < 3f) return;
        float shakeIntensity = velocity / 15f;

        if (flashScreen)
            cameraColor.Flash(shakeIntensity*0.75f);



        //Is player or (other) ball (and not goal post)
        if (coll.gameObject.CompareTag("Ball")) return;
        if (coll.gameObject.layer == playerLayer && !coll.gameObject.name.StartsWith("goal")) return;


        


        camera.GetComponent<Shaker>().Shake(shakeIntensity);
    }
}
