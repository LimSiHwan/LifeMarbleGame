using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class D_UIClass : MonoBehaviour {

    Button DiceStart;
    DiceClass diceClass;

	void Start () {
        DiceStart = GameObject.Find("DiceButton").gameObject.GetComponent<Button>();
        DiceStart.onClick.AddListener(() => { DiceGo(); });
        diceClass = GameObject.Find("dice").GetComponent<DiceClass>();
    }
    void DiceGo() //주사위 클릭하면 주사위 발사
    {
        if (D_Manager.Instance.DiceStart)
        {
            diceClass.DiceFire();
        }
    }
}
