﻿using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

    public float time;
	//Universal script to destroy objects after a set time. you can define the time in the inspector
	void Start ()
    {
        StartCoroutine(DestroyClock());
	}

    IEnumerator DestroyClock()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}
