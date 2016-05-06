using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour 
{

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            Game.instance.camera.GetComponent<Shaker>().Shake();
        }
    }
}
