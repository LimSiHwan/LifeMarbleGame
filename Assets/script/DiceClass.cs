using UnityEngine;
using System.Collections;

public class DiceClass : MonoBehaviour {
  
    public float forceAmount = 10.0f;
    public float torqueAmount = 10.0f;
    public ForceMode forceMode;
    Rigidbody D_Rg;
	void Start () {
        D_Rg = this.gameObject.GetComponent<Rigidbody>();
	}
	void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            D_Manager.Instance.DiceStart = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (D_Manager.Instance.DiceStart)
            {
                Fire();
                StartCoroutine(WaitStart());
            }
        }
	}
    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(2.0f);
        D_Manager.Instance.DiceStart = false;
        D_Manager.Instance.DiceValueChk = true;
    }
    void Fire()
    {
        D_Rg.AddForce(Vector3.up * forceAmount, forceMode);
        D_Rg.AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
    }
}
