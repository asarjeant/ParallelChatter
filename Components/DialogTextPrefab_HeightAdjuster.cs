using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTextPrefab_HeightAdjuster : MonoBehaviour {

	public float yTarget = 0;
	public float speedCyclesToTarget = 7;
	private float distanceToTarget = 0;

	void Start() {
		
	}

	void Update () {
		distanceToTarget = yTarget - this.transform.localPosition.y;
		this.transform.localPosition += Vector3.up * distanceToTarget / speedCyclesToTarget;
	}
}
