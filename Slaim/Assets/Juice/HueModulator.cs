using UnityEngine;
using System.Collections;

public class HueModulator : MonoBehaviour {

    private Camera _camera;
    private SpriteRenderer _rend;

    private float startH;
    private float startV;
    private float startS;

    public float speed = 60f;

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


        Util.RGBToHSV(startColor, out startH, out startV, out startS);
    }
	
    Color hueShift()
    {
        startH += Time.deltaTime * speed;

        return Util.HsvToRgbColor(startH, startS, startV);
    }


	// Update is called once per frame
	void Update () {


        if (_camera)
        {
            _camera.backgroundColor = hueShift();
        }
        else if (_rend)
        {
            
            _rend.color =hueShift();// = hueShift();
        }

	}
}
