using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class D_Manager {
    private static D_Manager inst;
    public static D_Manager Instance
    {
        get
        {
            if (inst == null)
            {
                inst = new D_Manager();
            }
            return inst;
        }
    }
    private D_Manager()
    {

    }
    
    public bool DiceStart = false;
    public bool DiceValueChk = false;
    public bool MoveChk = false;
    
    public int DiceValue;
    int TempMoveCountindex;

    //로그텍스트
    List<string> LogTemp = new List<string>();
    string tempLogTxt;

    //랜덤 미션
    public int RandomMissionIndex;
    public void ObjectSetActiveFalse(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void ObjectSetActiveTrue(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void setDiceValue(int value)
    {
        DiceValue = value;
    }
    public int getDiceValue()
    {
        return DiceValue;
    }
    public void setTempMoveCount(int TempMoveCount)
    {
        TempMoveCountindex = TempMoveCount;
    }
    public int getTempMoveCount()
    {
        return TempMoveCountindex;
    }
    public void UI_ResultTextSetting(int MarbleCount) //첫번째 기본적인 텍스트
    {
        AllMarbleData._instance.testImage.SetActive(true);
        if (MarbleCount == 0)
        {
            AllMarbleData._instance.UI_ResultText.text = "시작 지점입니다.";
        }
        else
        {
            AllMarbleData._instance.UI_ResultText.text = EventClass._instance.eventText[MarbleCount - 1];
        }
    }
    public void UI_REsultText2(int MarbleCount) //두번째 결과 텍스트
    {
        if(MarbleCount == 0)
        {
            return ;
        }
        else
        {
            EventClass._instance.ResultTextAdd(MarbleCount);
        }
    }
    public void LogTextFunction(string msg)
    {
        if(tempLogTxt == null)
        {
            AllMarbleData._instance.LogTxt.text = "\n" + msg;
        }
        else
        {
            AllMarbleData._instance.LogTxt.text = tempLogTxt + "\n" + msg;
        }
        tempLogTxt = tempLogTxt + "\n" + msg;
    }
}
