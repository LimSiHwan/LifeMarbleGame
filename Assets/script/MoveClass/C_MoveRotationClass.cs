using UnityEngine;
using System.Collections;

public class C_MoveRotationClass : MonoBehaviour {

    public void Ch_Rotation()
    {
        if (transform.position.x == AllMarbleData._instance.Marble[8].transform.position.x && transform.position.z == AllMarbleData._instance.Marble[8].transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (transform.position.x == AllMarbleData._instance.Marble[16].transform.position.x && transform.position.z == AllMarbleData._instance.Marble[16].transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x == AllMarbleData._instance.Marble[24].transform.position.x && transform.position.z == AllMarbleData._instance.Marble[24].transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (transform.position.x == AllMarbleData._instance.Marble[0].transform.position.x && transform.position.z == AllMarbleData._instance.Marble[0].transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
