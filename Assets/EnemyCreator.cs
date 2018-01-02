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
		if(EnemyCopy == null){ // 當敵人死亡，創造一個新的
			EnemyCopy = GameObject.Instantiate (EnemyObj, new Vector3(12, Random.Range(-9f,9f), 0), EnemyObj.transform.rotation);
		}
	}
}
