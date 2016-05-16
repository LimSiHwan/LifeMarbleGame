using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AllMarbleData : MonoBehaviour {

    public static AllMarbleData _instance;
    
    public GameObject[] Marble;
    public AnimationClip MarbleAnimation;

    //UI 카메라
    Camera UICam;
    Canvas UICanvas;
    GameObject UIObject;
    public GameObject testImage;
    public Text UI_ResultText;

    //캐릭터 생성
    int RandomIndex;
    GameObject Player_Ch;

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
        UIObject.gameObject.AddComponent<D_UIClass>(); //UI 버튼 클래스 추가
        UICanvas.renderMode = RenderMode.ScreenSpaceCamera;//캔버스에 렌더모드를 카메라로 전환
        UICanvas.worldCamera = UICam;//카메라 셋팅
        UI_ResultText = GameObject.Find("EventText").GetComponent<Text>(); //테스트용 이벤트
        testImage = GameObject.Find("TestImage"); //테스트용 뒷배경이미지
        testImage.SetActive(false);
    }
}
