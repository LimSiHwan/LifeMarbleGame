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
    public int DiceValue;
    public void setDiceValue(int value)
    {
        DiceValue = value;
    }
    public int getDiceValue()
    {
        return DiceValue;
    }
}
