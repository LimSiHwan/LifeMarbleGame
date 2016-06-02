using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DiceDownGageClass : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Image Gage;
    bool DiceDownChk;
    bool DiceTestchk;

    DiceClass diceClass;
    GameObject EventBtn;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (D_Manager.Instance.DiceStart)
        {
            AllMarbleData._instance.testImage.SetActive(false);
            DiceDownChk = true;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (D_Manager.Instance.DiceStart)
        {
            DiceDownChk = false;
            DiceTestchk = false;
            Gage.fillAmount = 0.0f;
            diceClass.DiceFire();
            EventBtn.SetActive(true); //이벤트 텍스트
        }
    }
    
    void Start ()
    {
        Gage = GameObject.Find("gage").GetComponent<Image>();
        diceClass = GameObject.Find("dice").GetComponentInChildren<DiceClass>();
        EventBtn = GameObject.Find("EventButton");
    }
	
	void Update ()
    {
        if (DiceDownChk)
        {
            Gage.fillAmount += 1f * Time.deltaTime;
            if(Gage.fillAmount >= 1.0f)
            {
                DiceDownChk = false;
                DiceTestchk = true;
            }
        }
        if (DiceTestchk)
        {
            Gage.fillAmount -= 1f * Time.deltaTime;
            if(Gage.fillAmount <= 0.0f)
            {
                DiceTestchk = false;
                DiceDownChk = true;
            }
        }
	}
}
