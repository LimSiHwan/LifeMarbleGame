using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class D_UIClass : MonoBehaviour {

    //주사위버튼
    Button DiceStart;

    //텍스트버튼
    Button Touchbutton;
    DiceClass diceClass;

    void Start ()
    {
        DiceStart = GameObject.Find("DiceButton").gameObject.GetComponent<Button>();
        DiceStart.onClick.AddListener(() => { DiceGo(); });
        Touchbutton = GameObject.Find("EventButton").transform.FindChild("touchbutton").gameObject.GetComponent<Button>();
        Touchbutton.onClick.AddListener(() => { touchTextNext(); });
        Touchbutton.gameObject.SetActive(false);
        diceClass = GameObject.Find("dice").GetComponentInChildren<DiceClass>();
    }
    void DiceGo() //주사위 클릭하면 주사위 발사
    {
        if (D_Manager.Instance.DiceStart)
        {
            AllMarbleData._instance.testImage.SetActive(false);
            diceClass.DiceFire();
        }
    }
    void touchTextNext() //터치버튼
    {
        D_Manager.Instance.UI_REsultText2(D_Manager.Instance.getTempMoveCount());
        AllMarbleData._instance.ResultTouchButton.SetActive(false); //터치버튼 비활성화
        D_Manager.Instance.ObjectSetActiveTrue(AllMarbleData._instance.DiceButton); //주사위 활성화
    }
}
