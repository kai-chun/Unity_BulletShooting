using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCtrl : MonoBehaviour {
	float speed;
	// Use this for initialization
	void Start () {
		speed = Random.Range (10f, 20f);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.left * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Destroy (other.gameObject);
		}
}
}
