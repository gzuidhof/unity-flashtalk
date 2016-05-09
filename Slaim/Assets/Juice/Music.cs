using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour {

    public bool randomStartPitch = false;
    public float pitchIncreasePerMinute = 0f;
    private AudioSource source;

    public float volume = 0.4f;
    public float startVolume = 0.15f;

	void Start () {
        this.source = GetComponent<AudioSource>();
        this.source.loop = true;
        this.source.volume = volume;
        Game.instance.OnGameStart += () =>
        {
            float startPitch = this.randomStartPitch ? source.pitch = Random.Range(0.94f, 1.03f) : 1f;
            this.source.pitch = startPitch;

            this.source.time = Random.Range(0f, 60f);
            this.source.volume = startVolume;

        };
    }
	
	// Update is called once per frame
	void Update () {
        this.source.pitch += (pitchIncreasePerMinute / 60f) * Time.deltaTime;
        this.source.volume = Mathf.Lerp(this.source.volume, this.volume, 0.6f * Time.deltaTime);
        
	}
}
