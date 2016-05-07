using UnityEngine;
using System.Collections;

public class Shaker : MonoBehaviour {

    public float shakeTime = 0.2f;
    public float shakeAmount = 0.075f;
    private Vector3 startPos;

    private bool isShaking = false;

    public void Shake(float intensity = 1f)
    {
        StartCoroutine(DoShake(intensity));
    }

    private IEnumerator DoShake(float intensity)
    {
        if (isShaking)
            yield break;
        isShaking = true;
        startPos = transform.position;
        var time = Mathf.Max(shakeTime, shakeTime* intensity);
        while (time > 0f)
        {
            Vector2 shake = Random.insideUnitCircle * shakeAmount * intensity;
            transform.position += new Vector3(shake.x, shake.y);
            time -= Time.deltaTime;
            yield return null;
        }
        transform.position = startPos;
        isShaking = false;
    }
}
