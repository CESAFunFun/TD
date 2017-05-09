using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootColor : MonoBehaviour {

    [SerializeField]
    PlayerColor colorNumber;

	// Use this for initialization
	void Start () {
        Image image = GetComponent<Image>();
        if (colorNumber.ColorNumber==1)
        {
            image.color = Color.green;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
