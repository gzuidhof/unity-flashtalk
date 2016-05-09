using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour
{

    void Start()
    {

        StartCoroutine(BlinkLoop());
    }

    private IEnumerator BlinkLoop()
    {
        while (true)
        {
            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }
            yield return new WaitForSeconds(0.15f);
            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = true;
            }
            yield return new WaitForSeconds(Random.Range(1.5f, 3f));
        }
    }
}
