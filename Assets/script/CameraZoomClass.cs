using UnityEngine;
using System.Collections;

public class CameraZoomClass : MonoBehaviour {

    Camera Cam;
    float delta = 0;
    float delta1 = 0;
    float smooth = 1.5f;

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
            //transform.parent = PlayerPos.transform;
        }
        if (!D_Manager.Instance.MoveChk)
        {
            CameraZoomOut();
        }
        //Cam.transform.position = Vector3.SmoothDamp(Cam.transform.position, new Vector3(PlayerPos.transform.position.x + 23.51f, PlayerPos.position.y + 31.51f, PlayerPos.transform.position.z + 20.86f), ref velocity, 30f);
    }
    void CameraZoomIn()
    {
        delta += Time.deltaTime;

        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 2.0f, delta/5);
        Cam.transform.position = Vector3.Lerp(new Vector3(Cam.transform.position.x, Cam.transform.position.y, Cam.transform.position.z), new Vector3(PlayerPos.transform.position.x + 23.51f, PlayerPos.position.y + 31.51f, PlayerPos.transform.position.z + 20.86f), delta/10);
       
        if (delta > 1)
        {
            delta = 0;
        }
    }
    void CameraZoomOut()
    {
        delta1 += Time.deltaTime;

        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 2.6f, delta1 / 5);
        Cam.transform.position = Vector3.Lerp(new Vector3(Cam.transform.position.x, Cam.transform.position.y, Cam.transform.position.z), new Vector3(CamInitPos.x, CamInitPos.y, CamInitPos.z), delta1 / 2);

        if (delta1 > 1)
        {
            delta1 = 0;
        }
    }
}
