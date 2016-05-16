using UnityEngine;
using System.Collections;

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
    public bool CameraZoomChk = false;
    public int DiceValue;
    
    public void setDiceValue(int value)
    {
        DiceValue = value;
    }
    public int getDiceValue()
    {
        return DiceValue;
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
}
