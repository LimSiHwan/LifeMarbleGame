using UnityEngine;
using System.Collections;

public class StartControll : MonoBehaviour {

    public bool AnimationChk;
    MeshRenderer Mr;
    Animation anim;
   
    GameObject BackGround; //배경 소환
    void Start ()
    {
        //뒷 배경 소환
        BackGround = Instantiate(Resources.Load("BackGround/backGround01", typeof(GameObject))) as GameObject;
        BackGround.transform.position = Vector3.zero;

        if (AnimationChk == true)
        {
            StartCoroutine(AnimationMarble());
        }
        else
        {
            for (int i = 0; i < 32; i++)
            {
                Mr = AllMarbleData._instance.Marble[i].GetComponent<MeshRenderer>();
                Mr.enabled = true;
            }
            D_Manager.Instance.DiceStart = true;
        }
        //로그테스트
        D_Manager.Instance.LogTextFunction("시작입니다.");

    }
    IEnumerator AnimationMarble()
    {
        for (int i = 0; i < 32; i++)
        {
            anim = AllMarbleData._instance.Marble[i].GetComponent<Animation>();
            anim.clip = AllMarbleData._instance.MarbleAnimation;
            anim.Play();
            yield return new WaitForSeconds(0.1f);
        }
        D_Manager.Instance.DiceStart = true;
    }
}
