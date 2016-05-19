using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AllMarbleData : MonoBehaviour {

    public static AllMarbleData _instance;
    
    public GameObject[] Marble;
    public AnimationClip MarbleAnimation;

    //UI 카메라
    public Camera UICam;
    Canvas UICanvas;
    GameObject UIObject;
    public GameObject DiceButton; //주사위 버튼
    public GameObject testImage;
    public Text UI_ResultText;

    //캐릭터 생성
    int RandomIndex;
    GameObject Player_Ch;

    //결과 touch이벤트
    public GameObject ResultTouchButton;

    //능력치 UI text
    public Text ArtTxt;
    public Text StrengthTxt;
    public Text LovelyTxt;
    public Text EduTxt;
    public Text SkillTxt;
    public Text MoneyTxt;
    void Awake ()
    {
        _instance = this;
        RandomIndex = Random.Range(1, 5);
        Player_Ch = Instantiate(Resources.Load("Character/Player_0" + RandomIndex, typeof(GameObject))) as GameObject;
        Player_Ch.transform.position = new Vector3(AllMarbleData._instance.Marble[0].transform.position.x, 0.23f, AllMarbleData._instance.Marble[0].transform.position.z);
        Player_Ch.name = "Player";

        UICam = Instantiate(Resources.Load("UI/UICamera", typeof(Camera))) as Camera;
        UICam.transform.position = new Vector3(0, 100, 0);
        UICam.farClipPlane = 150;
        UICanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        UIObject = GameObject.Find("UIObject");
        DiceButton = GameObject.Find("DiceButton");
        UIObject.gameObject.AddComponent<D_UIClass>(); //UI 버튼 클래스 추가
        UICanvas.renderMode = RenderMode.ScreenSpaceCamera;//캔버스에 렌더모드를 카메라로 전환
        UICanvas.worldCamera = UICam;//카메라 셋팅
        UI_ResultText = GameObject.Find("EventText").GetComponent<Text>(); //테스트용 이벤트
        ResultTouchButton = GameObject.Find("touchbutton");
        testImage = GameObject.Find("TestImage"); //테스트용 뒷배경이미지
        testImage.SetActive(false);

        //능력치 Txt
        ArtTxt = GameObject.Find("artTxt").GetComponent<Text>();
        ArtTxt.text = PlayerPrefs.GetInt("art").ToString();
        EduTxt = GameObject.Find("eduTxt").GetComponent<Text>();
        EduTxt.text = PlayerPrefs.GetInt("edu").ToString();
        StrengthTxt = GameObject.Find("strengthTxt").GetComponent<Text>();
        StrengthTxt.text = PlayerPrefs.GetInt("strength").ToString();
        SkillTxt = GameObject.Find("skillTxt").GetComponent<Text>();
        SkillTxt.text = PlayerPrefs.GetInt("skill").ToString();
        LovelyTxt = GameObject.Find("lovelyTxt").GetComponent<Text>();
        LovelyTxt.text = PlayerPrefs.GetInt("lovely").ToString();
        MoneyTxt = GameObject.Find("moneyTxt").GetComponent<Text>();
        if (!PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetFloat("money", 1000000);
        }
        MoneyTxt.text = PlayerPrefs.GetFloat("money").ToString("#,##0") + "원";
    }
}
