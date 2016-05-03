using UnityEngine;
using System.Collections;

public class StartControll : MonoBehaviour {

    public bool AnimationChk;
    MeshRenderer Mr;
    Animation anim;
    int RandomIndex;

    GameObject Player_Ch;
    void Start () { //애니메이션 스타트
        RandomIndex = Random.Range(1, 5);
        Player_Ch = Instantiate(Resources.Load("Character/Player_0" + RandomIndex, typeof(GameObject))) as GameObject;
        Player_Ch.transform.position = new Vector3(0, -0.65f, 0);
        Player_Ch.name = "Player";
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
