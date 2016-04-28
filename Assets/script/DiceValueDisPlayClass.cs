using UnityEngine;
using System.Collections;

public class DiceValueDisPlayClass : MonoBehaviour {

    public LayerMask dieValueColliderLayer = -1;
    public int CurrentValue = 1;
    RaycastHit hit;
    
	void Update ()
    {
        if (D_Manager.Instance.DiceStart)
        {
            if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer))
            {
                CurrentValue = hit.collider.GetComponent<DiceValueClass>().value;
                D_Manager.Instance.setDiceValue(CurrentValue);
            }
        }
	}
}
