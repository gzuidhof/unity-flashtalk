using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class Goal : MonoBehaviour {

    public int team;
    public bool fireConfetti;
    private ParticleSystem[] particleSystems;

    void Start()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Game.instance.Goal(team);
            if (fireConfetti)
                FireConfetti();
        }
    }

    void FireConfetti()
    {
        foreach (var ps in particleSystems)
        {
            ps.Play();
        }
    }


}
