using UnityEngine;
using System.Collections;

public class StartControll : MonoBehaviour {

    public bool AnimationChk;
    MeshRenderer Mr;
    Animation anim;
    void Start () { //애니메이션 스타트
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
