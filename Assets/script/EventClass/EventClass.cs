﻿using UnityEngine;
using System.Collections;

public class EventClass : MonoBehaviour {

    public static EventClass _instance;

    public string[] eventText = new string[31];
    
    int MonthMoney; //월급 카운트
    float MoneySuccesstemp;
    // Use this for initialization
    void Start () {
        _instance = this;
        eventTextAdd();
        MonthMoney = 0;
    }
    int LovelySuccess()
    {
        int Lovely = Random.Range(2, 5);
        PlayerPrefs.SetInt("lovely", PlayerPrefs.GetInt("lovely") + Lovely);
        AllMarbleData._instance.LovelyTxt.text = PlayerPrefs.GetInt("lovely").ToString();
        return Lovely;
    }
    int EduSuccess()
    {
        int Edu = Random.Range(3, 6);
        PlayerPrefs.SetInt("edu", PlayerPrefs.GetInt("edu") + Edu);
        AllMarbleData._instance.EduTxt.text = PlayerPrefs.GetInt("edu").ToString();
        return Edu;
    }
    int StrengthSuccess()
    {
        int Strength = Random.Range(3, 6);
        PlayerPrefs.SetInt("strength", PlayerPrefs.GetInt("strength") + Strength);
        AllMarbleData._instance.StrengthTxt.text = PlayerPrefs.GetInt("strength").ToString();
        return Strength;
    }
    int ArtSuccess()
    {
        int Art = Random.Range(3, 6);
        PlayerPrefs.SetInt("art", PlayerPrefs.GetInt("art") + Art);
        AllMarbleData._instance.ArtTxt.text = PlayerPrefs.GetInt("art").ToString();
        return Art;
    }
    int SkillSuccess()
    {
        int Skill = Random.Range(3, 6);
        PlayerPrefs.SetInt("skill", PlayerPrefs.GetInt("skill") + Skill);
        AllMarbleData._instance.SkillTxt.text = PlayerPrefs.GetInt("skill").ToString();
        return Skill;
    }
    float MoneySuccess(float money)
    {
        PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") + money);
        AllMarbleData._instance.MoneyTxt.text = PlayerPrefs.GetFloat("money").ToString("#,##0") + "원";
        MoneySuccesstemp += money;
        return money;
    }
    float MoneyFail(float money)
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
                AllMarbleData._instance.UI_ResultText.text = "세입자들과 함께 집주인을 설득시켰다!!";
                break;
            case 2:
                AllMarbleData._instance.UI_ResultText.text = "이쁜(잘생긴) 여(남)학생들을 발견했다. \n애정도 " + LovelySuccess() + " 상승!!";
                break;
            case 3:
                AllMarbleData._instance.UI_ResultText.text = "공포심이 생겼는지 도망갔다.";
                break;
            case 4:
                AllMarbleData._instance.UI_ResultText.text = "열심히 수업에 집중했다. \n학력 " + EduSuccess() + " 상승!!";
                break;
            case 5:
                AllMarbleData._instance.UI_ResultText.text = "친구로부터 생일선물을 받다.";
                break;
            case 6:
                AllMarbleData._instance.UI_ResultText.text = "자전거를 타며 바람을 맞으니 기분이 좋아진다. \n체력 " + StrengthSuccess() + " 상승!!";
                break;
            case 7:
                AllMarbleData._instance.UI_ResultText.text = "성공적으로 적금을 만기했다. \n돈 " + MoneySuccess(200000) + "원을 얻었다!!" ;
                break;
            case 8:
                AllMarbleData._instance.UI_ResultText.text = "물건을 구매한다.";
                break;
            case 9:
                AllMarbleData._instance.UI_ResultText.text = "참아냈다.";
                break;
            case 10:
                AllMarbleData._instance.UI_ResultText.text = "은행에 맡긴 예금의 이자를 받았다.";
                break;
            case 11:
                AllMarbleData._instance.UI_ResultText.text = "기입한 보험에서 보험비가 나갔다. \n돈 " + MoneyFail(30000) + "원을 잃었다!!ㅠㅠ";
                break;
            case 12:
                AllMarbleData._instance.UI_ResultText.text = "박물관에서 고흐의 그림을 보고 감동받았다. \n예술 " + ArtSuccess() + " 상승!!";
                break;
            case 13:
                AllMarbleData._instance.UI_ResultText.text = "두껍고 비싸보이는 지갑이다. \n돈 " + MoneySuccess(100000) + "원을 얻었다!!";
                break;
            case 14:
                AllMarbleData._instance.UI_ResultText.text = "책을 열심히 읽었다. \n기술력 " + SkillSuccess() + " 상승!!";
                break;
            case 15:
                AllMarbleData._instance.UI_ResultText.text = "야근하는 모습을 사장님이 보셨다. \n보너스 " + MoneySuccess(MonthMoney * 1000000 * 0.3f) + "원을 받았다!!";
                break;
            case 16:
                AllMarbleData._instance.UI_ResultText.text = "선택가능한 보험상품을 출력";
                break;
            case 17:
                AllMarbleData._instance.UI_ResultText.text = "유지비가 3% 상승했다.";
                break;
            case 18:
                AllMarbleData._instance.UI_ResultText.text = "노래방 기계에서 " + (50 + PlayerPrefs.GetInt("lovely") + Random.Range(0, 50 - PlayerPrefs.GetInt("lovely"))) + " 점을 받았다. \n애정도가 " + LovelySuccess() + " 증가 했다. !";
                break;
            case 19:
                AllMarbleData._instance.UI_ResultText.text = "입원비가 나갔다. \n돈 " + MoneyFail(1000000) + "원을 잃었다!!";
                break;
            case 20:
                AllMarbleData._instance.UI_ResultText.text = "상식이 늘어났다. \n학력 " + EduSuccess() + "증가 !!";
                break;
            case 21:
                AllMarbleData._instance.UI_ResultText.text = "그림이 똑같다.";
                break;
            case 22:
                AllMarbleData._instance.UI_ResultText.text = "들키지 않았다. \n체력 " + StrengthSuccess() + "증가 !!";
                break;
            case 23:
                AllMarbleData._instance.UI_ResultText.text = "월급의 70%를 받았다. \n돈 " + MoneySuccess(700000) + "원 증가!!";
                break;
            case 24:
                AllMarbleData._instance.UI_ResultText.text = "예금을 100만원 들었다.";
                break;
            case 25:
                AllMarbleData._instance.UI_ResultText.text = "학비로 " + MoneyFail(3000000) + "만원이 나갔다.";
                break;
            case 26:
                AllMarbleData._instance.UI_ResultText.text = "지금까지 나온 수익의 10퍼센트를 받았다. \n돈 " + MoneySuccess(MoneySuccesstemp * 0.1f) + "원 증가!!";
                break;
            case 27:
                AllMarbleData._instance.UI_ResultText.text = "소지품 소실";
                break;
            case 28:
                AllMarbleData._instance.UI_ResultText.text = "재미있었다. \n매력 " + LovelySuccess() + "증가!!";
                break;
            case 29:
                AllMarbleData._instance.UI_ResultText.text = "잭팟이 터졌다. 배팅미 * 100만원";
                break;
            case 30:
                AllMarbleData._instance.UI_ResultText.text = "장르에 따라 금액 지출과 수익 증가";
                break;
            case 31:
                MonthMoney++;
                AllMarbleData._instance.UI_ResultText.text = "월급 " + MoneySuccess(1000000) + "만원을 받았다.";
                break;
        }
    }
    void eventTextAdd()
    {
        eventText[0] = "집주인 : 관리비 인상이 필요할 것 같습니다.";
        eventText[1] = "동네 서점에 방문하다.";
        eventText[2] = "집안에 강도가 들었다!!";
        eventText[3] = "수업을 듣기위해 학교에 가다.";
        eventText[4] = "오늘은 생일이다.";
        eventText[5] = "자전거를 타다.";
        eventText[6] = "적금을 들었습니다.";
        eventText[7] = "상점가에 도착했다.";
        eventText[8] = "식욕이 왕성해졌다.";
        eventText[9] = "이자를 받다.";
        eventText[10] = "비가 많이 와서 집이 물에 잠겼다.";
        eventText[11] = "박물관 견학을 가다.";
        eventText[12] = "지갑을 발견했다!!";
        eventText[13] = "프로그래밍 책을 선물받다.";
        eventText[14] = "보너스를 받다!!";
        eventText[15] = "보험회사 직원이 보험상품을 보여준다.";
        eventText[16] = "교통비가 올랐다.";
        eventText[17] = "노래방 기계에서 점수를 받았다.";
        eventText[18] = "교통사고가 나 입원을 하였다.";
        eventText[19] = "독서실에서 책을 읽었다.";
        eventText[20] = "복권을 구입하려한다. 그림을 선택해라";
        eventText[21] = "지각을 해서 창문으로 몰래 들어갔다.";
        eventText[22] = "퇴근 후 부업을 시작했다.";
        eventText[23] = "은행에서 예금 적금을 들 수 있다.";
        eventText[24] = "새학기가 시작했다.";
        eventText[25] = "세금을 돌려받았다.";
        eventText[26] = "집에 불이났다.";
        eventText[27] = "뮤지컬을 보러갔다.";
        eventText[28] = "슬롯머신을 하였다.";
        eventText[29] = "자격증을 취득했다.";
        eventText[30] = "오늘은 즐거운 월급날!!";
    }
}
