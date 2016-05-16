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
    public int DiceValue;
    
    public void setDiceValue(int value)
    {
        DiceValue = value;
    }
    public int getDiceValue()
    {
        return DiceValue;
    }
    public void CameraSetting()
    {
        if (DiceStart)
        {
            AllMarbleData._instance.Main_Camera.gameObject.SetActive(true);
            AllMarbleData._instance.CH_Camera.gameObject.SetActive(false);
        }
        else
        {
            AllMarbleData._instance.Main_Camera.gameObject.SetActive(false);
            AllMarbleData._instance.CH_Camera.gameObject.SetActive(true);
        }
    }
}
