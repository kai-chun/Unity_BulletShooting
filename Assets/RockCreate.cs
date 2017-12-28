using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCreate : MonoBehaviour {
	public GameObject rock;
	float count;
	float r;

	// Use this for initialization
	void Start () {
		count = 0;	
		r = Random.Range (0.5f,2f);
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		if (count >=r) {
			GameObject copyObj = GameObject.Instantiate (rock,new Vector3(12,Random.Range(-9f,9f),0), rock.transform.rotation);
			count = 0;
			r = Random.Range (0.5f,2f);
		}
	}

}

