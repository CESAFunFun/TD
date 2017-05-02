using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float _damage = 1F;

    [HideInInspector]
    public Character.ELEMENT element = Character.ELEMENT.NONE;

    private void OnTriggerEnter(Collider other) {

        // 仮組として属性ごとの値を設定
        switch(element)
        {
            case Character.ELEMENT.FIRE:
                _damage = 5F;
                break;
            case Character.ELEMENT.WATER:
                _damage = 2F;
                break;
            case Character.ELEMENT.WIND:
                _damage = 3F;
                break;
            case Character.ELEMENT.EARTH:
                _damage = 4F;
                break;
            default:
                _damage = 1F;
                break;
        }

        if (other.gameObject.tag != "Bullet")
        {
            gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.SendMessage("TakeDamage", _damage);
        }
    }
}
