using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class D_UIClass : MonoBehaviour{

    //주사위버튼
    //Button DiceStart;
    GameObject DiceStart;
    //텍스트버튼
    Button Touchbutton;
    //DiceClass diceClass;
    //Exit버튼
    Button EventExit;
    Button FailExit;
    GameObject EventBtn;
    //주사위버튼 클릭
    

    void Start ()
    {
        DiceStart = GameObject.Find("DiceBtn");
        DiceStart.AddComponent<DiceDownGageClass>();

        Touchbutton = GameObject.Find("missionBtn").transform.FindChild("M_Success").gameObject.GetComponent<Button>();
        Touchbutton.onClick.AddListener(() => { touchTextNext(); });
        Touchbutton.gameObject.SetActive(false);
     
        //diceClass = GameObject.Find("dice").GetComponentInChildren<DiceClass>();
        EventBtn = GameObject.Find("EventButton");
        EventExit = GameObject.Find("Exit").GetComponent<Button>();
        EventExit.onClick.AddListener(() => { EventExitFunction(); });
        FailExit = GameObject.Find("M_Fail").GetComponent<Button>();
        FailExit.onClick.AddListener(() => { EventExitFunction(); });
        AllMarbleData._instance.M_Fail.SetActive(false);
        //게이지
    }
    void touchTextNext() //터치버튼
    {
        D_Manager.Instance.UI_REsultText2(D_Manager.Instance.getTempMoveCount());
        AllMarbleData._instance.M_Success.SetActive(false);//미션수행, 무시 비활성화
        AllMarbleData._instance.FailTxt.text = "닫기";
        D_Manager.Instance.ObjectSetActiveTrue(AllMarbleData._instance.DiceButton); //주사위 활성화
    }
    void EventExitFunction()
    {
        AllMarbleData._instance.DiceButton.SetActive(true);
        AllMarbleData._instance.M_Success.SetActive(false);
        AllMarbleData._instance.M_Fail.SetActive(false);
        EventBtn.SetActive(false);
    }
}
