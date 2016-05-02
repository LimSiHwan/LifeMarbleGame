using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AllMarbleData : MonoBehaviour {

    public static AllMarbleData _instance;

    public GameObject[] Marble;
    public AnimationClip MarbleAnimation;

    Camera UICam;
    Canvas UICanvas;
    GameObject UIObject;
   
    void Awake ()
    {
        _instance = this;
        UICam = Instantiate(Resources.Load("UI/UICamera", typeof(Camera))) as Camera;
        UICam.transform.position = new Vector3(0, 100, 0);
        UICam.farClipPlane = 150;
        UICanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        UIObject = GameObject.Find("UIObject");
        UIObject.gameObject.AddComponent<D_UIClass>(); //UI 버튼 클래스 추가
        UICanvas.renderMode = RenderMode.ScreenSpaceCamera;//캔버스에 렌더모드를 카메라로 전환
        UICanvas.worldCamera = UICam;//카메라 셋팅
    }
}
