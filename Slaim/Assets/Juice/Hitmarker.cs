using UnityEngine;
using System.Collections;

public class Hitmarker : MonoBehaviour {

    public GameObject hitmarkerPrefab;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("Ball")) {
            Vector2 position = coll.contacts[0].point;
            var go = GameObject.Instantiate(hitmarkerPrefab, position, Quaternion.identity);
            Destroy(go, 0.235f);
        }
    }
}
