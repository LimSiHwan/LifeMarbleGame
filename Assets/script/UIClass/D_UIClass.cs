using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class D_UIClass : MonoBehaviour {

    //주사위버튼
    Button DiceStart;

    //텍스트버튼
    Button Touchbutton;
    DiceClass diceClass;
    //Exit버튼
    Button EventExit;
    GameObject EventBtn;
    //로그 텍스트
    void Start ()
    {
        DiceStart = GameObject.Find("DiceBtn").gameObject.GetComponent<Button>();
        DiceStart.onClick.AddListener(() => { DiceGo(); });
        Touchbutton = GameObject.Find("EventButton").transform.FindChild("touchbutton").gameObject.GetComponent<Button>();
        Touchbutton.onClick.AddListener(() => { touchTextNext(); });
        Touchbutton.gameObject.SetActive(false);
        diceClass = GameObject.Find("dice").GetComponentInChildren<DiceClass>();
        EventBtn = GameObject.Find("EventButton");
        EventExit = GameObject.Find("Exit").GetComponent<Button>();
        EventExit.onClick.AddListener(() => { EventExitFunction(); });
    }
    void DiceGo() //주사위 클릭하면 주사위 발사
    {
        if (D_Manager.Instance.DiceStart)
        {
            AllMarbleData._instance.testImage.SetActive(false);
            diceClass.DiceFire();
            //임시로구현 터치 버튼 애니메이션때문..
            StartCoroutine(imsi());
        }
    }
    IEnumerator imsi()
    {
        yield return new WaitForSeconds(1.5f);
        EventBtn.SetActive(true);
    }
    void touchTextNext() //터치버튼
    {
        D_Manager.Instance.UI_REsultText2(D_Manager.Instance.getTempMoveCount());
        AllMarbleData._instance.ResultTouchButton.SetActive(false); //터치버튼 비활성화
        D_Manager.Instance.ObjectSetActiveTrue(AllMarbleData._instance.DiceButton); //주사위 활성화
    }
    void EventExitFunction()
    {
        AllMarbleData._instance.DiceButton.SetActive(true);
        EventBtn.SetActive(false);
    }
   
}
