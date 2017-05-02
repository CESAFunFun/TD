using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RecastBar : MonoBehaviour {

    private Image _recastBar;

    public GameObject player;

    public float num = 1.0f;

    // Use this for initialization
    void Start () {
        _recastBar = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        float recast = player.GetComponent<Character>().recastTime * num;
        _recastBar.fillAmount -= recast;
    }
}
