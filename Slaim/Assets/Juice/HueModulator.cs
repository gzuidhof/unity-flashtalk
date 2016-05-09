using UnityEngine;
using System.Collections;

public class HueModulator : MonoBehaviour {

    private float extraV = 0f;

    private Camera _camera;
    private SpriteRenderer _rend;

    private float startH;
    private float startV;
    private float startS;

    public float speed = 90f;

	// Use this for initialization
	void Start () {

        Color startColor = new Color();

        _camera = gameObject.GetComponent<Camera>();
        
        _rend = gameObject.GetComponent<SpriteRenderer>();
        if (_rend) {
            startColor = _rend.color;
        }

        if (_camera)
        {
            startColor = _camera.backgroundColor;
        }

        bool wasWhite = Mathf.Abs(startColor.r + startColor.g + startColor.b -3f) < 0.01f;
        Util.RGBToHSV(startColor, out startH, out startV, out startS);

        if (wasWhite)
        {
            startV = 0.9f;
            startS = 0.9f;
            startH = Random.Range(0f, 360f);
        }



    }
	
    Color hueShift()
    {
        startH += Time.deltaTime * speed;

        return Util.HsvToRgbColor(startH, startS, startV + extraV);
    }


	// Update is called once per frame
	void Update()
	{
	    extraV = Mathf.Lerp(extraV, 0, 0.1f);

        if (_camera)
        {
            _camera.backgroundColor = hueShift();
        }
        else if (_rend)
        {
            
            _rend.color =hueShift();// = hueShift();
        }

	}

    public void Flash(float intensity)
    {
        extraV += Mathf.Max(0f, intensity - startV + extraV);
    }
}
