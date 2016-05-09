using UnityEngine;
using System.Collections;

public class Hexagon : MonoBehaviour
{
    public GameObject ball;
    private new ParticleSystem particleSystem;
    private new SpriteRenderer renderer;

    private bool hasSpawned;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasSpawned || other.tag == "Player" ) return;
        particleSystem.Play();

        var oldRot = other.transform.rotation;
        other.transform.rotation = Quaternion.Euler(0, 0, 25) * oldRot;
        Instantiate(ball, other.transform.position, Quaternion.Euler(0, 0, -25) * oldRot);

        renderer.enabled = false;
        Destroy(gameObject, 0.5f);
        hasSpawned = true;
        enabled = false;
    }
}
