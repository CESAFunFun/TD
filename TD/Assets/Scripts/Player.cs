using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    public float moveSpeed = 1F;
    public float rotaSpeed = 1F;

    [SerializeField]
    private GameObject _bullet;

    private Rigidbody _rigidbody;
    private Vector3 _velocity;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        _velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            _velocity = Vector3.back * moveSpeed;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            _velocity = Vector3.forward * moveSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            _velocity = Vector3.left * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _velocity = Vector3.right * moveSpeed;
        }


        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * rotaSpeed);
        }
        else if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.down * rotaSpeed);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(_bullet, transform.position + transform.forward * 1.5F, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500F);
        }
    }

    private void FixedUpdate() {
        _rigidbody.MovePosition(transform.position + _velocity * Time.deltaTime);
    }
}
