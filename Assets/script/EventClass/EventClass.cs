using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventClass : MonoBehaviour {

    public static EventClass _instance;

    public string[] eventText = new string[31];
    
    int MonthMoney; //월급 카운트
    float MoneySuccesstemp;

    //능력치
    int StatusArt;
    int StatusEdu;
    int StatusStrength;
    int StatusLovely;
    int StatusSkill;
    bool artchk;
    bool educhk;
    bool strengthchk;
    bool lovelychk;
    bool skillchk;
    List<int> Status = new List<int>();
    void Start ()
    {
        _instance = this;
        eventTextAdd();
        MonthMoney = 0;
        StatusSetting();
    }

    void StatusSetting() //능력치가 높은 2개를 게임화면에 표시
    {
        Status.Clear();
        StatusArt = PlayerPrefs.GetInt("art");
        StatusEdu = PlayerPrefs.GetInt("edu");
        StatusSkill = PlayerPrefs.GetInt("skill");
        StatusLovely = PlayerPrefs.GetInt("lovely");
        StatusStrength = PlayerPrefs.GetInt("strength");
        Status.Add(StatusArt);
        Status.Add(StatusEdu);
        Status.Add(StatusSkill);
        Status.Add(StatusLovely);
        Status.Add(StatusStrength);
        Status.Sort();

        AllMarbleData._instance.StatSort1.text = Status[4].ToString();
        AllMarbleData._instance.StatSort2.text = Status[3].ToString();
        StatAllActiveFalse();

        if (Status[4] == StatusArt)
        {
            artchk = true;
            AllMarbleData._instance.ArtImg.SetActive(true);
        }
        else if(Status[4] == StatusEdu)
        {
            educhk = true;
            AllMarbleData._instance.EduImg.SetActive(true);
        }
        else if (Status[4] == StatusSkill)
        {
            skillchk = true;
            AllMarbleData._instance.SkillImg.SetActive(true);
        }
        else if (Status[4] == StatusLovely)
        {
            lovelychk = true;
            AllMarbleData._instance.Lovelyimg.SetActive(true);
        }
        else if (Status[4] == StatusStrength)
        {
            strengthchk = true;
            AllMarbleData._instance.StrengthImg.SetActive(true);
        }

        if (Status[3] == StatusEdu && educhk == false)
        {
            AllMarbleData._instance.EduImg1.SetActive(true);
        }
        else if (Status[3] == StatusArt && artchk == false)
        {
            AllMarbleData._instance.ArtImg1.SetActive(true);
        }
        else if (Status[3] == StatusSkill && skillchk == false)
        {
            AllMarbleData._instance.SkillImg1.SetActive(true);
        }
        else if (Status[3] == StatusLovely && lovelychk == false)
        {
            AllMarbleData._instance.Lovelyimg1.SetActive(true);
        }
        else if (Status[3] == StatusStrength && strengthchk == false)
        {
            AllMarbleData._instance.StrengthImg1.SetActive(true);
        }
    }
    void StatAllActiveFalse() //능력치에관한 모든 이미지를 꺼준다.
    {
        AllMarbleData._instance.StrengthImg.SetActive(false);
        AllMarbleData._instance.EduImg.SetActive(false);
        AllMarbleData._instance.SkillImg.SetActive(false);
        AllMarbleData._instance.Lovelyimg.SetActive(false);
        AllMarbleData._instance.ArtImg.SetActive(false);
        AllMarbleData._instance.StrengthImg1.SetActive(false);
        AllMarbleData._instance.EduImg1.SetActive(false);
        AllMarbleData._instance.SkillImg1.SetActive(false);
        AllMarbleData._instance.Lovelyimg1.SetActive(false);
        AllMarbleData._instance.ArtImg1.SetActive(false);
    }
    int LovelySuccess() //애정도 성공했을때
    {
        int Lovely = Random.Range(2, 5);
        PlayerPrefs.SetInt("lovely", PlayerPrefs.GetInt("lovely") + Lovely);
        StatusSetting();
        return Lovely;
    }
    int EduSuccess()//학력 성공했을때
    {
        int Edu = Random.Range(3, 6);
        PlayerPrefs.SetInt("edu", PlayerPrefs.GetInt("edu") + Edu);
        StatusSetting();
        return Edu;
    }
    int StrengthSuccess()//체력 성공했을때
    {
        int Strength = Random.Range(3, 6);
        PlayerPrefs.SetInt("strength", PlayerPrefs.GetInt("strength") + Strength);
        StatusSetting();
        return Strength;
    }
    int ArtSuccess()//예술 성공했을때
    {
        int Art = Random.Range(3, 6);
        PlayerPrefs.SetInt("art", PlayerPrefs.GetInt("art") + Art);
        StatusSetting();
        return Art;
    }
    int SkillSuccess()//기술력 성공했을때
    {
        int Skill = Random.Range(3, 6);
        PlayerPrefs.SetInt("skill", PlayerPrefs.GetInt("skill") + Skill);
        StatusSetting();
        return Skill;
    }
    float MoneySuccess(float money)//자금이 들어올때
    {
        PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") + money);
        AllMarbleData._instance.MoneyTxt.text = PlayerPrefs.GetFloat("money").ToString("#,##0") + "원";
        MoneySuccesstemp += money;
        return money;
    }
    float MoneyFail(float money)//자금이 나갈때
    {
        PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - money);
        AllMarbleData._instance.MoneyTxt.text = PlayerPrefs.GetFloat("money").ToString("#,##0") + "원";
        return money;
    }
    public void ResultTextAdd(int CountIndex)
    {
        switch (CountIndex)
        {
            case 1:
                AllMarbleData._instance.UI_ResultText.text = "세입자들과 함께 집주인을 \n설득시켰다!!";
                D_Manager.Instance.LogTextFunction(eventText[0]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 2:
                AllMarbleData._instance.UI_ResultText.text = "이쁜(잘생긴) 여(남)학생들을 발견했다. \n애정도 " + LovelySuccess() + " 상승!!";
                D_Manager.Instance.LogTextFunction(eventText[1]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 3:
                AllMarbleData._instance.UI_ResultText.text = "공포심이 생겼는지 도망갔다.";
                D_Manager.Instance.LogTextFunction(eventText[2]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 4:
                AllMarbleData._instance.UI_ResultText.text = "열심히 수업에 집중했다. \n학력 " + EduSuccess() + " 상승!!";
                D_Manager.Instance.LogTextFunction(eventText[3]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 5:
                AllMarbleData._instance.UI_ResultText.text = "친구로부터 생일선물을 받다.";
                D_Manager.Instance.LogTextFunction(eventText[4]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 6:
                AllMarbleData._instance.UI_ResultText.text = "자전거를 타며 바람을 \n맞으니 기분이 좋아진다. \n체력 " + StrengthSuccess() + " 상승!!";
                D_Manager.Instance.LogTextFunction(eventText[5]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 7:
                AllMarbleData._instance.UI_ResultText.text = "성공적으로 적금을 만기했다. \n돈 " + MoneySuccess(200000).ToString("#,##0") + "원을 얻었다!!" ;
                D_Manager.Instance.LogTextFunction(eventText[6]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 8:
                AllMarbleData._instance.UI_ResultText.text = "물건을 구매한다.";
                D_Manager.Instance.LogTextFunction(eventText[7]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 9:
                AllMarbleData._instance.UI_ResultText.text = "참아냈다.";
                D_Manager.Instance.LogTextFunction(eventText[8]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 10:
                AllMarbleData._instance.UI_ResultText.text = "은행에 맡긴 예금의 이자를 받았다.";
                D_Manager.Instance.LogTextFunction(eventText[9]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 11:
                AllMarbleData._instance.UI_ResultText.text = "기입한 보험에서 보험비가 나갔다. \n돈 " + MoneyFail(30000).ToString("#,##0") + "원을 잃었다!!ㅠㅠ";
                D_Manager.Instance.LogTextFunction(eventText[10]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 12:
                AllMarbleData._instance.UI_ResultText.text = "박물관에서 고흐의 그림을 \n보고 감동받았다. \n예술 " + ArtSuccess() + " 상승!!";
                D_Manager.Instance.LogTextFunction(eventText[11]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 13:
                AllMarbleData._instance.UI_ResultText.text = "두껍고 비싸보이는 지갑이다. \n돈 " + MoneySuccess(100000).ToString("#,##0") + "원을 얻었다!!";
                D_Manager.Instance.LogTextFunction(eventText[12]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 14:
                AllMarbleData._instance.UI_ResultText.text = "책을 열심히 읽었다. \n기술력 " + SkillSuccess() + " 상승!!";
                D_Manager.Instance.LogTextFunction(eventText[13]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 15:
                AllMarbleData._instance.UI_ResultText.text = "야근하는 모습을 사장님이 보셨다. \n보너스 " + MoneySuccess(MonthMoney * 1000000 * 0.3f).ToString("#,##0") + "원을 받았다!!";
                D_Manager.Instance.LogTextFunction(eventText[14]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 16:
                AllMarbleData._instance.UI_ResultText.text = "선택가능한 보험상품을 출력";
                D_Manager.Instance.LogTextFunction(eventText[15]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 17:
                AllMarbleData._instance.UI_ResultText.text = "유지비가 3% 상승했다.";
                D_Manager.Instance.LogTextFunction(eventText[16]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 18:
                AllMarbleData._instance.UI_ResultText.text = "노래방 기계에서 " + (50 + PlayerPrefs.GetInt("lovely") + Random.Range(0, 50 - PlayerPrefs.GetInt("lovely"))) + " 점을 받았다. \n애정도가 " + LovelySuccess() + " 증가 했다. !";
                D_Manager.Instance.LogTextFunction(eventText[17]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 19:
                AllMarbleData._instance.UI_ResultText.text = "입원비가 나갔다. \n돈 " + MoneyFail(1000000).ToString("#,##0") + "원을 잃었다!!";
                D_Manager.Instance.LogTextFunction(eventText[18]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 20:
                AllMarbleData._instance.UI_ResultText.text = "상식이 늘어났다. \n학력 " + EduSuccess() + "증가 !!";
                D_Manager.Instance.LogTextFunction(eventText[19]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 21:
                AllMarbleData._instance.UI_ResultText.text = "그림이 똑같다.";
                D_Manager.Instance.LogTextFunction(eventText[20]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 22:
                AllMarbleData._instance.UI_ResultText.text = "들키지 않았다. \n체력 " + StrengthSuccess() + "증가 !!";
                D_Manager.Instance.LogTextFunction(eventText[21]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 23:
                AllMarbleData._instance.UI_ResultText.text = "월급의 70%를 받았다. \n돈 " + MoneySuccess(700000).ToString("#,##0") + "원 증가!!";
                D_Manager.Instance.LogTextFunction(eventText[22]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 24:
                AllMarbleData._instance.UI_ResultText.text = "예금을 100만원 들었다.";
                D_Manager.Instance.LogTextFunction(eventText[23]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 25:
                AllMarbleData._instance.UI_ResultText.text = "학비로 " + MoneyFail(3000000).ToString("#,##0") + "만원이 나갔다.";
                D_Manager.Instance.LogTextFunction(eventText[24]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 26:
                AllMarbleData._instance.UI_ResultText.text = "지금까지 나온 수익의 \n10퍼센트를 받았다. \n돈 " + MoneySuccess(MoneySuccesstemp * 0.1f).ToString("#,##0") + "원 증가!!";
                D_Manager.Instance.LogTextFunction(eventText[25]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 27:
                AllMarbleData._instance.UI_ResultText.text = "소지품 소실";
                D_Manager.Instance.LogTextFunction(eventText[26]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 28:
                AllMarbleData._instance.UI_ResultText.text = "재미있었다. \n애정도 " + LovelySuccess() + "증가!!";
                D_Manager.Instance.LogTextFunction(eventText[27]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 29:
                AllMarbleData._instance.UI_ResultText.text = "잭팟이 터졌다. 배팅비 * 100만원";
                D_Manager.Instance.LogTextFunction(eventText[28]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 30:
                AllMarbleData._instance.UI_ResultText.text = "장르에 따라 금액 지출과 수익 증가";
                D_Manager.Instance.LogTextFunction(eventText[29]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
            case 31:
                MonthMoney++;
                AllMarbleData._instance.UI_ResultText.text = "월급 " + MoneySuccess(1000000).ToString("#,##0") + "만원을 받았다.";
                D_Manager.Instance.LogTextFunction(eventText[30]);
                MissionTxtClass._instance.RandomMissionIndex(D_Manager.Instance.RandomMissionIndex);
                break;
        }
    }
    void eventTextAdd()
    {
        eventText[0] = "관리비 인상이 \n필요할 것 같습니다.";
        eventText[1] = "동네 서점에 방문하다.";
        eventText[2] = "집안에 강도가 들었다!!";
        eventText[3] = "수업을 듣기위해 학교에 가다.";
        eventText[4] = "오늘은 생일이다.";
        eventText[5] = "자전거를 타다.";
        eventText[6] = "적금을 들었습니다.";
        eventText[7] = "상점가에 도착했다.";
        eventText[8] = "식욕이 왕성해졌다.";
        eventText[9] = "이자를 받다.";
        eventText[10] = "비가 많이 와서 집이 \n물에 잠겼다.";
        eventText[11] = "박물관 견학을 가다.";
        eventText[12] = "지갑을 발견했다!!";
        eventText[13] = "프로그래밍 책을 선물받다.";
        eventText[14] = "보너스를 받다!!";
        eventText[15] = "보험회사 직원이 보험상품을 \n보여준다.";
        eventText[16] = "교통비가 올랐다.";
        eventText[17] = "노래방 기계에서 점수를 받았다.";
        eventText[18] = "교통사고가 나 입원을 하였다.";
        eventText[19] = "독서실에서 책을 읽었다.";
        eventText[20] = "복권을 구입하려한다. \n그림을 선택해라";
        eventText[21] = "지각을 해서 창문으로 \n몰래 들어갔다.";
        eventText[22] = "퇴근 후 부업을 시작했다.";
        eventText[23] = "은행에서 예금 적금을 \n들 수 있다.";
        eventText[24] = "새학기가 시작했다.";
        eventText[25] = "세금을 돌려받았다.";
        eventText[26] = "집에 불이났다.";
        eventText[27] = "뮤지컬을 보러갔다.";
        eventText[28] = "슬롯머신을 하였다.";
        eventText[29] = "자격증을 취득했다.";
        eventText[30] = "오늘은 즐거운 월급날!!";
    }
}
