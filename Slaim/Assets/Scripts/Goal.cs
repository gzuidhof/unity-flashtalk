﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class Goal : MonoBehaviour {

    public int team;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Game.instance.Goal(team);
        }
    }

    
}
