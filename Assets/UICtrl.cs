using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour {

	public Texture heart;
	public GameObject player;
	public int killed;

	// Use this for initialization
	void Start () {
		killed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
		if (player != null){
			PlayerCtrl pCtrl = player.GetComponent<PlayerCtrl> ();
			for (int i = 0; i < pCtrl.HP; i++) {
				GUI.DrawTexture (new Rect (i * 50, 0, 50, 50), heart, ScaleMode.ScaleToFit); // 愛心
			}
		}
		GUI.Label (new Rect (200, 0, 50, 20), "Killed: " + killed); // 玩家殺死敵人的數目顯示
	}
}
