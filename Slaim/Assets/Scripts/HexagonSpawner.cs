using UnityEngine;
using System.Collections;

public class HexagonSpawner : MonoBehaviour
{
    public GameObject hexagon;
    public float intervalMin;
    public float intervalMax;

	void Start()
	{
	    StartCoroutine(SpawnHexagons());
	}

    private IEnumerator SpawnHexagons()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(intervalMin, intervalMax));
            float xPos = Random.Range(-8f, 8f);
            float yPos = Random.Range(4f, 10f);
            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 90f));
            Instantiate(hexagon, new Vector2(xPos, yPos), rotation);
        }
    }
}
