using UnityEngine;
using System.Collections;

public class C_MoveClass : MonoBehaviour {

    int MoveCount;
    int TempMoveCount;
	void Start () {
        StartCoroutine(Ch_Move());
        TempMoveCount = 0;
    }
	IEnumerator Ch_Move()
    {
        while (true)
        {
            if (D_Manager.Instance.DiceValueChk)
            {
                MoveCount = D_Manager.Instance.getDiceValue();
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
                D_Manager.Instance.DiceValueChk = false;
                D_Manager.Instance.DiceStart = true;
            }
            yield return new WaitForEndOfFrame();
        }
    }

}
