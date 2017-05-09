using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColor : MonoBehaviour {

    //色
    public Material[] _material;
    public int ColorNumber;

	// Use this for initialization
	void Start () {
        ColorNumber = 1;
        gameObject.GetComponent<Renderer>().material = _material[ColorNumber];
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
