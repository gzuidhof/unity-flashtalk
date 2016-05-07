using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BallBounceSound : MonoBehaviour {

    private static int playerLayer = LayerMask.NameToLayer("Players");
    private Rigidbody2D rb;

    public float volume = 0.7f;
    public float playerVolume = 0.4f;

    public AudioClip bounceSound;
    public AudioClip playerBounceSound;
    new private AudioSource audio;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        audio = this.GetComponent<AudioSource>();
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        //Is player or (other) ball (and not goal post)
        if (coll.gameObject.CompareTag("Ball")) return;

        float velocity = rb.velocity.magnitude;
        if (velocity < 2.5f) return;

        float intensity = velocity / 20f;

        

        //Is player
        if (coll.gameObject.layer == playerLayer && !coll.gameObject.name.StartsWith("goal"))
        {
            audio.pitch = Mathf.Clamp(0.75f + intensity * 0.3f, 0.75f, 1.3f) * 0.95f;
            audio.PlayOneShot(playerBounceSound, playerVolume * intensity);
        }
        else
        {
            audio.pitch = Mathf.Clamp(0.9f + intensity * 0.2f, 0.9f, 1.3f);
            audio.PlayOneShot(bounceSound, volume * intensity);
        }


    }
}
