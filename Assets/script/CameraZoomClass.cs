using UnityEngine;
using System.Collections;

public class CameraZoomClass : MonoBehaviour {

    Camera Cam;
    float ZoomIndelta = 0;
    float ZoomOutdelta1 = 0;
    public float smooth = 1.5f;

    Vector3 CamInitPos;

    public Transform PlayerPos;

    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        CamInitPos = transform.position;
        PlayerPos = GameObject.Find("Player").GetComponent<Transform>();
        Cam = this.GetComponent<Camera>();
    }
	void Update ()
    {
        if (D_Manager.Instance.MoveChk)
        {
            CameraZoomIn();
            ZoomOutdelta1 = 0;
            //transform.parent = PlayerPos.transform;
        }
        if (!D_Manager.Instance.MoveChk)
        {
            CameraZoomOut();
            ZoomIndelta = 0;
        }
        //Cam.transform.position = Vector3.SmoothDamp(Cam.transform.position, new Vector3(PlayerPos.transform.position.x + 23.51f, PlayerPos.position.y + 31.51f, PlayerPos.transform.position.z + 20.86f), ref velocity, 30f);
    }
    void CameraZoomIn()
    {
        ZoomIndelta += Time.deltaTime;

        Cam.transform.position = Vector3.Lerp(new Vector3(Cam.transform.position.x, Cam.transform.position.y, Cam.transform.position.z), new Vector3(PlayerPos.transform.position.x + 23.51f, PlayerPos.position.y + 31.51f, PlayerPos.transform.position.z + 20.86f), ZoomIndelta * 2);

        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 2.0f, ZoomIndelta * 2);
        if (ZoomIndelta > 1)
        {
            ZoomIndelta = 0;
        }
    }
    void CameraZoomOut()
    {
        ZoomOutdelta1 += Time.deltaTime;

        Cam.transform.position = Vector3.Lerp(new Vector3(Cam.transform.position.x, Cam.transform.position.y, Cam.transform.position.z), new Vector3(CamInitPos.x, CamInitPos.y, CamInitPos.z), ZoomOutdelta1 * 2);
        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 2.6f, ZoomOutdelta1 * 2);
        if (ZoomOutdelta1 > 1)
        {
            ZoomOutdelta1 = 0;
        }
    }
}
