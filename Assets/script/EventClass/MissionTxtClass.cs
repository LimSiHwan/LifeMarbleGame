using UnityEngine;
using System.Collections;

public class MissionTxtClass : MonoBehaviour {

    public static MissionTxtClass _instance;
	void Start ()
    {
        _instance = this;

        D_Manager.Instance.RandomMissionIndex = Random.Range(1, 6);
        RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
    }
    public void RandomMissionIndex(int randomMission)
    {
        if (randomMission == 1)
        {
            Mission1();
        }
        if (randomMission == 2)
        {
            Mission2();
        }
        if (randomMission == 3)
        {
            Mission3();
        }
        if (randomMission == 4)
        {
            Mission4();
        }
        if (randomMission == 5)
        {
            Mission5();
        }
    }
    public void Mission1()
    {
        
        if(PlayerPrefs.GetInt("lovely") == 50)
        {
            AllMarbleData._instance.MissionTxt.text = "미션 완료!!";
            AllMarbleData._instance.MissionStatTxt.text = "";
        } else
        {
            AllMarbleData._instance.MissionTxt.text = "애정도 50을 만드세요 !!";
            AllMarbleData._instance.MissionStatTxt.text = PlayerPrefs.GetInt("lovely") + " / 50";
        }
    }
    public void Mission2()
    {
        if (PlayerPrefs.GetInt("skill") == 50)
        {
            AllMarbleData._instance.MissionTxt.text = "미션 완료!!";
            AllMarbleData._instance.MissionStatTxt.text = "";
        } else
        {
            AllMarbleData._instance.MissionTxt.text = "기술력 50을 만드세요 !!";
            AllMarbleData._instance.MissionStatTxt.text = PlayerPrefs.GetInt("skill") + " / 50";
        }
    }
    public void Mission3()
    {
       
        if (PlayerPrefs.GetInt("strength") == 50)
        {
            AllMarbleData._instance.MissionTxt.text = "미션 완료!!";
            AllMarbleData._instance.MissionStatTxt.text = "";
        } else
        {
            AllMarbleData._instance.MissionTxt.text = "체력 50을 만드세요 !!";
            AllMarbleData._instance.MissionStatTxt.text = PlayerPrefs.GetInt("strength") + " / 50";
        }
    }
    public void Mission4()
    {
        if (PlayerPrefs.GetInt("edu") == 50)
        {
            AllMarbleData._instance.MissionTxt.text = "미션 완료!!";
            AllMarbleData._instance.MissionStatTxt.text = "";
        } else
        {
            AllMarbleData._instance.MissionTxt.text = "학력 50을 만드세요 !!";
            AllMarbleData._instance.MissionStatTxt.text = PlayerPrefs.GetInt("edu") + " / 50";
        }
    }
    void Mission5()
    {
       
        if (PlayerPrefs.GetInt("art") == 50)
        {
            AllMarbleData._instance.MissionTxt.text = "미션 완료!!";
            AllMarbleData._instance.MissionStatTxt.text = "";
        } else
        {
            AllMarbleData._instance.MissionTxt.text = "예술 50을 만드세요 !!";
            AllMarbleData._instance.MissionStatTxt.text = PlayerPrefs.GetInt("art") + " / 50";
        }
    }
}
