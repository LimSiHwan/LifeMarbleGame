using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStartBtnClass : MonoBehaviour {

    Button GameStartBtn;
	void Start ()
    {
        GameStartBtn = GameObject.Find("GameStart").GetComponent<Button>();
        GameStartBtn.onClick.AddListener(() => { GameStartGo(); });
    }
	void GameStartGo()
    {
        AllMarbleData._instance.MainUICanvasOBj.SetActive(false);
    }
}
