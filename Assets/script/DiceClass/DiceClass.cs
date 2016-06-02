using UnityEngine;
using System.Collections;

public class DiceClass : MonoBehaviour
{

    public float forceAmount = 10.0f;
    public ForceMode forceMode;
    Rigidbody D_Rg;

    void Start()
    {
        D_Rg = this.gameObject.GetComponent<Rigidbody>();
        StartCoroutine(RotateDice());
    }
    IEnumerator RotateDice()
    {
        while (true)
        {
            if (D_Manager.Instance.DiceStart)
            {
                transform.Rotate(new Vector3(1, 1, 1) * 3f);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    public void DiceFire() //주사위 버튼을 클릭하면 여기로옵니다.
    {
        Fire();
        StartCoroutine(WaitStart());
        D_Manager.Instance.DiceStart = false;
    }
    IEnumerator WaitStart() // 주사위가 던져지고 2초뒤 주사위값을 체크합니다.
    {
        yield return new WaitForSeconds(1.2f);
        D_Manager.Instance.DiceValueChk = true;
        D_Manager.Instance.ObjectSetActiveFalse(AllMarbleData._instance.DiceButton); //주사위 버튼 비활성화
        AllMarbleData._instance.UICanvasOBj.SetActive(false);
    }
    void Fire() //주사위를 던집니다.
    {
        D_Rg.WakeUp();
        D_Rg.useGravity = true;
        D_Rg.AddForce(new Vector3(1, 0, 0) * forceAmount, forceMode);
    }
    public void DiceInitSetting() //주사위 다시 셋팅
    {
        D_Rg.Sleep();
        D_Rg.useGravity = false;
        transform.position = new Vector3(-4.31f, 2.67f, 2.732258f);
    }
}
