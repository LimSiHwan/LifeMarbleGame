using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    public void UI_ResultTextSetting(int MarbleCount)
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
    public void UI_REsultText2(int MarbleCount)
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
}
