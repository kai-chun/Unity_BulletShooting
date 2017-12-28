using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour {
	float speed;
	float dir;
	public GameObject bullet;
	float count;
	int HP;
	public GameObject player;
	bool MoveIn;
	public GameObject UIObj;

	// Use this for initialization
	void Start () {
		speed = 15;
		dir = 1;
		count = 0.5f;
		HP = 1;
		player = GameObject.Find ("Player");
		UIObj = GameObject.Find ("UI");
		MoveIn = true;
	}

	public void OnHit(){
		HP--;
		if (HP <= 0) {
			UIObj.GetComponent<UICtrl> ().killed++;
			Destroy (this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		if (MoveIn) {
			this.transform.Translate (Vector3.left * Time.deltaTime * speed * dir, Space.World); 
			if (this.transform.position.x <= 7) {
				MoveIn = false;
			}
		} else {
			this.transform.Translate (Vector3.up * Time.deltaTime * speed * dir, Space.World); //絕對位置
			if (this.transform.position.y >= 10) {
				dir = dir * -1;
				this.transform.position = new Vector3 (this.transform.position.x, 10, this.transform.position.z); //避免敵人跑出畫面卡住
				speed = Random.Range (10, 30);
			}
			if (this.transform.position.y <= -10) {
				dir = dir * -1;
				this.transform.position = new Vector3 (this.transform.position.x, -10, this.transform.position.z);
				speed = Random.Range (10, 30);
			}
			count -= Time.deltaTime;
			if (count <= 0) {

				int R = Random.Range (0, 2);
				switch (R) {
				case 0:
					Shooting1 ();
					break;
				case 1:
					Shooting2 ();
					break;
				}
				count = 0.5f;
			}
		}
	}
	void Shooting1(){
		int maxBullet = 11;
		int setoff = 10;
		for (int i = 0; i < maxBullet; i++) {
			GameObject copyObj = GameObject.Instantiate (bullet, this.transform.position, bullet.transform.rotation);
			copyObj.transform.Rotate (0, 0, 90-Mathf.Floor(maxBullet/2)*setoff+i*setoff);
			copyObj.tag = this.tag;
		}
	}

	void Shooting2(){
		if (player != null) {
			float deltaX = player.transform.position.x - this.transform.position.x;
			float deltaY = player.transform.position.y - this.transform.position.y;
			float theta = Mathf.Atan2(deltaY , deltaX);
			//Debug.Log(); //顯示錯誤的訊息

			GameObject copyObj = GameObject.Instantiate (bullet, this.transform.position, bullet.transform.rotation);
			copyObj.transform.Rotate (0, 0, -90 + theta * Mathf.Rad2Deg);
			copyObj.tag = this.tag;
		}
	}
}
