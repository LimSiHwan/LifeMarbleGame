using UnityEngine;
using System.Collections;

public class DiceClass : MonoBehaviour {
  
    public float forceAmount = 10.0f;
    public ForceMode forceMode;
    Rigidbody D_Rg;
   
	void Start ()
    {
        D_Rg = this.gameObject.GetComponent<Rigidbody>();
	}
   
	void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (D_Manager.Instance.DiceStart)
            {
                Fire();
                StartCoroutine(WaitStart());
                D_Manager.Instance.DiceStart = false;
            }
        }
        if (D_Manager.Instance.DiceStart)
        {
            transform.Rotate(new Vector3(1, 1, 1) * 3f);
        }
	}
    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(2.0f);
        D_Manager.Instance.DiceValueChk = true;
    }
    void Fire()
    {
        D_Rg.WakeUp();
        D_Rg.useGravity = true;
        D_Rg.AddForce(Vector3.forward * forceAmount, forceMode);
        //D_Rg.AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
    }
    public void DiceInitSetting()
    {
        D_Rg.Sleep();
        D_Rg.useGravity = false;
        transform.position = new Vector3(4, 3, -7);
    }
}
