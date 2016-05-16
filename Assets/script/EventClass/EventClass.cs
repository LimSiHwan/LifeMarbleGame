using UnityEngine;
using System.Collections;

public class EventClass : MonoBehaviour {

    public static EventClass _instance;

    public string[] eventText = new string[31];

    // Use this for initialization
    void Start () {

        _instance = this;
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
