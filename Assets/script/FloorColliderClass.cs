using UnityEngine;
using System.Collections;

public class FloorColliderClass : MonoBehaviour {

    public float ForceAmount = 10.0f;
    public ForceMode forceMode;
    GameObject Explosion;

    void OnCollisionEnter(Collision Col) //바닥콜라이더에서 아래쪽으로 힘을 줍니다.
    {
        Explosion = Instantiate(Resources.Load("Effect/Explosion", typeof(GameObject))) as GameObject;
        Explosion.transform.position = Col.transform.position;
        Col.rigidbody.AddForce(new Vector3(0, 0, 0) * ForceAmount, forceMode);
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(Explosion);
    }
}
