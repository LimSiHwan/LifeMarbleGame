using UnityEngine;
using System.Collections;

public class AllMarbleData : MonoBehaviour {

    public static AllMarbleData _instance;

    public GameObject[] Marble;
    public AnimationClip MarbleAnimation;

	void Awake ()
    {
        _instance = this;
	}
}
