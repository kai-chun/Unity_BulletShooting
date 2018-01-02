using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

	public GameObject bullet;
	public int HP;

	// Use this for initialization
	void Start () {
		HP = 4;
	}

	public void OnHit () {
		HP--;
		if (HP <= 0) { // 若 player 的 HP 小於 0 則摧毀 player
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)){			
			this.transform.Translate (Vector3.up*Time.deltaTime*5); //move right for 5 times/per second
		}
		if (Input.GetKey(KeyCode.S)){			
			this.transform.Translate (Vector3.down*Time.deltaTime*5); //move right for 5 times/per second
		}
		if (Input.GetKey(KeyCode.A)){			
			this.transform.Translate (Vector3.left*Time.deltaTime*5); //move right for 5 times/per second
		}
		if (Input.GetKey(KeyCode.D)){			
			this.transform.Translate (Vector3.right*Time.deltaTime*5); //move right for 5 times/per second
		}
		if (Input.GetKeyDown(KeyCode.Space)){ // 空白鍵發射子彈
			GameObject copyObj = GameObject.Instantiate (bullet, this.transform.position, bullet.transform.rotation);
			copyObj.transform.Rotate (0, 0, -90);
			copyObj.tag = this.tag;
		}
		// 避免 player 跑出視窗
		if (this.transform.position.x >= Camera.main.aspect * Camera.main.orthographicSize) { //orthographicSize為Camera的尺寸，因x較寬 所以須乘上aspect(Camera的長寬比，長:寬=1:?)
			Vector3 pos=this.transform.position;
			pos.x = Camera.main.aspect * Camera.main.orthographicSize;
			this.transform.position = pos;
		}
		if (this.transform.position.x <= Camera.main.aspect * -Camera.main.orthographicSize) {
			Vector3 pos = this.transform.position;
			pos.x = Camera.main.aspect * -Camera.main.orthographicSize;
			this.transform.position = pos;
		}
		if (this.transform.position.y >= Camera.main.orthographicSize) {
			Vector3 pos = this.transform.position;
			pos.y = Camera.main.orthographicSize;
			this.transform.position = pos;
		}
		if (this.transform.position.y <= -Camera.main.orthographicSize) {
			Vector3 pos = this.transform.position;
			pos.y = -Camera.main.orthographicSize;
			this.transform.position = pos;
		}
	}
}
