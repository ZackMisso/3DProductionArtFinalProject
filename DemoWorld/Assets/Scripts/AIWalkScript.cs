using UnityEngine;
using System.Collections;

public class AIWalkScript : MonoBehaviour {
	public Vector3 startPosition;
	public Vector3 endPosition;
	public float timeToGo = 20.0f;
	public float startTime = -1.0f;

	//void Start() {
	//	startTime = Time.time;
	//}

	// Update is called once per frame
	void Update () {
		if(startTime == -1.0f) {
			startTime = Time.time;
			Vector3 relativePos = endPosition - startPosition;
      Quaternion rotation = Quaternion.LookRotation(relativePos);
      transform.rotation = rotation;
		}
		if(Time.time - startTime >= timeToGo) {
			gameObject.transform.position = endPosition;
			Vector3 tmp = startPosition;
			startPosition = endPosition;
			endPosition = tmp;
			Vector3 relativePos = endPosition - startPosition;
      Quaternion rotation = Quaternion.LookRotation(relativePos);
      transform.rotation = rotation;
			startTime = Time.time;
		} else {
			transform.position = (endPosition-startPosition)*(Time.time-startTime) / timeToGo + startPosition;
		}
	}
}
