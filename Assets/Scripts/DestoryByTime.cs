using UnityEngine;
using System.Collections;

public class DestoryByTime : MonoBehaviour {
    public long LifeTime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, LifeTime);
	}
}
