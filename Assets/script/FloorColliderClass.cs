using UnityEngine;
using System.Collections;

public class FloorColliderClass : MonoBehaviour {

    public float ForceAmount = 10.0f;
    public ForceMode forceMode;
	void OnCollisionEnter(Collision Col)
    {
        Col.rigidbody.Sleep();
        Col.rigidbody.AddForce(new Vector3(0, -1, 0) * ForceAmount, forceMode);
    }
}
