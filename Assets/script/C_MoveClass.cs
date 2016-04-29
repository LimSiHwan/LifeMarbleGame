using UnityEngine;
using System.Collections;

public class C_MoveClass : MonoBehaviour {

    int MoveCount;
    int TempMoveCount;
    DiceClass diceClass;
	void Start () {
        StartCoroutine(Ch_Move());
        TempMoveCount = 0;
        diceClass = GameObject.Find("dice").GetComponent<DiceClass>();
    }
	IEnumerator Ch_Move()
    {
        while (true)
        {
            if (D_Manager.Instance.MoveChk)
            {
                MoveCount = D_Manager.Instance.getDiceValue();
                Debug.Log("Count : " + MoveCount);
                if(TempMoveCount + MoveCount > 31)
                {
                    TempMoveCount = (TempMoveCount + MoveCount) % 32;
                    transform.position = new Vector3(AllMarbleData._instance.Marble[TempMoveCount].transform.position.x, 0.75f, AllMarbleData._instance.Marble[TempMoveCount].transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(AllMarbleData._instance.Marble[MoveCount + TempMoveCount].transform.position.x, 0.75f , AllMarbleData._instance.Marble[MoveCount + TempMoveCount].transform.position.z);
                    TempMoveCount = MoveCount + TempMoveCount;
                }
                D_Manager.Instance.MoveChk = false;
                D_Manager.Instance.DiceStart = true;
                diceClass.DiceInitSetting(); //주사위 다시 셋팅
            }
            yield return new WaitForEndOfFrame();
        }
    }

}
