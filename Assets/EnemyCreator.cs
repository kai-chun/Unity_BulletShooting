using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour {


	public GameObject EnemyObj;
	public GameObject EnemyCopy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(EnemyCopy ==null){
			EnemyCopy = GameObject.Instantiate (EnemyObj, new Vector3(12,Random.Range(-9f,9f),0), EnemyObj.transform.rotation);
		}
	}
}
