using UnityEngine;
using System.Collections;

public class PathNode : MonoBehaviour {
	public PathNode next = null;
	public Vector3 position = new Vector3(0.0f,0.0f,0.0f);
	public float timeTo = 3.0f;
	public bool isEnd = false;
	public bool isStart = false;
	public int val;
}
