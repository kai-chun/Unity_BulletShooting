using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {

	float speed;
	 
	// Use this for initialization
	void Start () {
		speed = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.up * speed * Time.deltaTime, Space.Self); // 控制子彈移動速度、方向
	}

	void OnTriggerEnter (Collider other){
		if (other.name != "Deadline" && other.name != this.name) { // 判斷子彈打到的對象
			if (other.tag != this.tag) {
				switch (other.tag){
				case "Player":
					PlayerCtrl pCtrl = other.GetComponent<PlayerCtrl> ();
					pCtrl.OnHit ();
					GameObject.Destroy (this.gameObject);
					break;
				case "Enemy":
					EnemyCtrl eCtrl = other.GetComponent<EnemyCtrl> ();
					eCtrl.OnHit ();
					GameObject.Destroy (this.gameObject);
					break;
				}
			}
		}
	}
}
