using UnityEngine;
using System.Collections;

public class AllMarbleData : MonoBehaviour {

    public static AllMarbleData _instance;

    public GameObject[] Marble;

	void Start () {

        _instance = this;
	}
}
