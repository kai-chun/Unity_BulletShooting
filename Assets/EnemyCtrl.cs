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

	public void OnHit () {
		HP--;
		if (HP <= 0) {
			UIObj.GetComponent<UICtrl> ().killed++;
			Destroy (this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		if (MoveIn) { // 若創造一個新的敵人，它會從畫面外出現，並在 x = 7 時停下
			this.transform.Translate (Vector3.left * Time.deltaTime * speed * dir, Space.World); 
			if (this.transform.position.x <= 7) {
				MoveIn = false;
			}
		} else { // 敵人在 x = 7 處上下移動
			this.transform.Translate (Vector3.up * Time.deltaTime * speed * dir, Space.World); // 絕對位置
			if (this.transform.position.y >= 10) {
				dir = dir * -1;
				this.transform.position = new Vector3 (this.transform.position.x, 10, this.transform.position.z); // 避免敵人跑出畫面卡住
				speed = Random.Range (10, 30);
			}
			if (this.transform.position.y <= -10) {
				dir = dir * -1;
				this.transform.position = new Vector3 (this.transform.position.x, -10, this.transform.position.z);
				speed = Random.Range (10, 30);
			}
			count -= Time.deltaTime;
			if (count <= 0) { // 隨機敵人射擊子彈方式
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
	
	void Shooting1 () { // 發散式射擊
		int maxBullet = 11; // 子彈數
		int setoff = 10; // 子彈發散角度
		for (int i = 0; i < maxBullet; i++) {
			GameObject copyObj = GameObject.Instantiate (bullet, this.transform.position, bullet.transform.rotation);
			copyObj.transform.Rotate (0, 0, 90 - Mathf.Floor(maxBullet / 2) * setoff + i * setoff);
			copyObj.tag = this.tag;
		}
	}

	void Shooting2(){ // 瞄準player的射擊模式
		if (player != null) { // 判斷 player 存在
			float deltaX = player.transform.position.x - this.transform.position.x;
			float deltaY = player.transform.position.y - this.transform.position.y;
			float theta = Mathf.Atan2(deltaY , deltaX);

			GameObject copyObj = GameObject.Instantiate (bullet, this.transform.position, bullet.transform.rotation);
			copyObj.transform.Rotate (0, 0, -90 + theta * Mathf.Rad2Deg); // 瞄準 player 的射擊角度
			copyObj.tag = this.tag;
		}
	}
}
