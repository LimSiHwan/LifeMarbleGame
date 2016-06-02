using UnityEngine;
using System.Collections;

public class C_MoveClass : MonoBehaviour {

    int MoveCount;
    int TempMoveCount;
    int MoveIndex;
    public float delaytime = 5.0f;

    DiceClass diceClass;

    Vector3 StartPos;
    Vector3 EndPos;
    
    Animator _animator;
    public AnimationCurve ac;

    float time;

    //자식오브젝트에 rotation
    C_MoveRotationClass CMR;
    void Start () {
        StartCoroutine(Ch_Move());
        TempMoveCount = 0;
        MoveIndex = 0;
        diceClass = GameObject.Find("dice").GetComponent<DiceClass>();
        _animator = gameObject.GetComponentInChildren<Animator>();
        CMR = gameObject.GetComponentInChildren<C_MoveRotationClass>();

    }
	IEnumerator Ch_Move()
    {
        while (true)
        {
            if (D_Manager.Instance.MoveChk)
            {
                yield return new WaitForSeconds(0.5f);
                StartPos = gameObject.transform.position;
                MoveCount = D_Manager.Instance.getDiceValue(); //주사위 값.
                D_Manager.Instance.LogTextFunction("주사위 : " + MoveCount + " 입니다.");
                float deltatime = Time.deltaTime * delaytime;
                if (TempMoveCount + MoveCount > 31) // 31칸 초과라면
                {
                    for(int i = 1; i <= MoveCount; i++) 
                    {
                        if(TempMoveCount + i > 31) //ex) 31 + 1 이라면 32이다. 마블에선 32 == 0 이기때문에..
                        {
                            AudioSource.PlayClipAtPoint(AllMarbleData._instance.JumpSound, transform.position);
                            EndPos = new Vector3(AllMarbleData._instance.Marble[MoveIndex].transform.position.x, 0.23f, AllMarbleData._instance.Marble[MoveIndex].transform.position.z);
                            for (time = 0.0f; time <= 1.0f + deltatime; time += deltatime)
                            {
                                _animator.SetBool("Jump", true);
                                transform.position = Vector3.Lerp(StartPos, EndPos, time);
                                yield return new WaitForEndOfFrame();
                                deltatime = Time.deltaTime * delaytime;
                            }
                            StartPos = EndPos;
                            CMR.Ch_Rotation();
                            _animator.SetBool("Jump", false);
                            MoveIndex++;
                            yield return new WaitForSeconds(0.08f);
                        } else // 한칸씩 움직이기위해서
                        {
                            AudioSource.PlayClipAtPoint(AllMarbleData._instance.JumpSound, transform.position);
                            EndPos = new Vector3(AllMarbleData._instance.Marble[TempMoveCount + i].transform.position.x, 0.23f, AllMarbleData._instance.Marble[TempMoveCount + i].transform.position.z);
                            for (time = 0.0f; time <= 1.0f + deltatime; time += deltatime)
                            {
                                _animator.SetBool("Jump", true);
                                transform.position = Vector3.Lerp(StartPos, EndPos, time);
                                yield return new WaitForEndOfFrame();
                                deltatime = Time.deltaTime * delaytime;
                            }
                            StartPos = EndPos;
                            CMR.Ch_Rotation();
                            _animator.SetBool("Jump", false);
                            yield return new WaitForSeconds(0.08f); // << TEST 중 0.08
                        }
                    }
                    TempMoveCount = (TempMoveCount + MoveCount) % 32;
                }
                else //미만 이라면
                {
                    for (int i = MoveCount - 1; i >= 0; i--)
                    {
                        AudioSource.PlayClipAtPoint(AllMarbleData._instance.JumpSound, transform.position);
                        EndPos = new Vector3(AllMarbleData._instance.Marble[(MoveCount + TempMoveCount) - i].transform.position.x, 0.23f, AllMarbleData._instance.Marble[(MoveCount + TempMoveCount) - i].transform.position.z);
                        for (time = 0.0f; time <= 1.0f + deltatime; time += deltatime)
                        {
                            _animator.SetBool("Jump", true);
                            transform.position = Vector3.Lerp(StartPos, EndPos, time);
                            yield return new WaitForEndOfFrame();
                            deltatime = Time.deltaTime * delaytime;
                        }
                        StartPos = EndPos;
                        CMR.Ch_Rotation();
                        _animator.SetBool("Jump", false);
                        yield return new WaitForSeconds(0.08f);
                    }
                    TempMoveCount = MoveCount + TempMoveCount;
                }
                AllMarbleData._instance.UICanvasOBj.SetActive(true);
                D_Manager.Instance.setTempMoveCount(TempMoveCount); //위치를 저장
                MoveIndex = 0; //다시 초기화해준다. 임이의 index값
                D_Manager.Instance.MoveChk = false; //움직임이 끝났다.
                D_Manager.Instance.DiceStart = true; //스타트 할 수 있다.
                diceClass.DiceInitSetting(); //주사위 다시 셋팅
                D_Manager.Instance.UI_ResultTextSetting(TempMoveCount); //테스트용 이벤트 텍스트
                AllMarbleData._instance.M_Success.SetActive(true);//미션수행 활성화
                AllMarbleData._instance.M_Fail.SetActive(true);//미션무시 활성화
                AllMarbleData._instance.FailTxt.text = "무시";
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
