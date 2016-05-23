using UnityEngine;
using System.Collections;

public class FloorColliderClass : MonoBehaviour {

    public float ForceAmount = 10.0f;
    public ForceMode forceMode;

    void OnCollisionEnter(Collision Col) //바닥콜라이더에서 아래쪽으로 힘을 줍니다.
    {
        Col.rigidbody.AddForce(new Vector3(0, 0, 0) * ForceAmount, forceMode);
    }
}
