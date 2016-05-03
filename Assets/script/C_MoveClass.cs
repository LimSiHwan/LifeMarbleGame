using UnityEngine;
using System.Collections;

public class C_MoveClass : MonoBehaviour {

    int MoveCount;
    int TempMoveCount;
    int MoveIndex;
    DiceClass diceClass;
	void Start () {
        StartCoroutine(Ch_Move());
        TempMoveCount = 0;
        MoveIndex = 0;
        diceClass = GameObject.Find("dice").GetComponent<DiceClass>();
    }
    void Ch_Rotation()
    {
        if (transform.position.x == AllMarbleData._instance.Marble[8].transform.position.x && transform.position.z == AllMarbleData._instance.Marble[8].transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (transform.position.x == AllMarbleData._instance.Marble[16].transform.position.x && transform.position.z == AllMarbleData._instance.Marble[16].transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (transform.position.x == AllMarbleData._instance.Marble[24].transform.position.x && transform.position.z == AllMarbleData._instance.Marble[24].transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (transform.position.x == AllMarbleData._instance.Marble[0].transform.position.x && transform.position.z == AllMarbleData._instance.Marble[0].transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
	IEnumerator Ch_Move()
    {
        while (true)
        {
            if (D_Manager.Instance.MoveChk)
            {
                MoveCount = D_Manager.Instance.getDiceValue(); //주사위 값.
                if (TempMoveCount + MoveCount > 31) // 31칸 초과라면
                {
                    for(int i = 1; i <= MoveCount; i++) 
                    {
                        if(TempMoveCount + i > 31) //ex) 31 + 1 이라면 32이다. 마블에선 32 == 0 이기때문에..
                        {
                            transform.position = new Vector3(AllMarbleData._instance.Marble[MoveIndex].transform.position.x, -0.65f, AllMarbleData._instance.Marble[MoveIndex].transform.position.z);
                            Ch_Rotation();
                            MoveIndex++;
                            yield return new WaitForSeconds(0.5f);
                        } else // 한칸씩 움직이기위해서
                        {
                            transform.position = new Vector3(AllMarbleData._instance.Marble[TempMoveCount + i].transform.position.x, -0.65f, AllMarbleData._instance.Marble[TempMoveCount + i].transform.position.z);
                            Ch_Rotation();
                            yield return new WaitForSeconds(0.5f);
                        }
                    }
                    TempMoveCount = (TempMoveCount + MoveCount) % 32;
                }
                else //미만 이라면
                {
                    for (int i = MoveCount-1; i >= 0; i--)
                    {
                        transform.position = new Vector3(AllMarbleData._instance.Marble[(MoveCount + TempMoveCount) - i].transform.position.x, -0.65f, AllMarbleData._instance.Marble[(MoveCount + TempMoveCount) - i].transform.position.z);
                        Ch_Rotation();
                        yield return new WaitForSeconds(0.5f);
                    }
                    TempMoveCount = MoveCount + TempMoveCount;
                }
                MoveIndex = 0; //다시 초기화해준다. 임이의 index값
                D_Manager.Instance.MoveChk = false; //움직임이 끝났다.
                D_Manager.Instance.DiceStart = true; //스타트 할 수 있다.
                diceClass.DiceInitSetting(); //주사위 다시 셋팅
            }
            yield return new WaitForEndOfFrame();
        }
    }

}
