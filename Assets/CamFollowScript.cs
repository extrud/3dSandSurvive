using UnityEngine;
using System.Collections;

public class CamFollowScript : MonoBehaviour {
    public float speed;
    public Transform target;
    Vector3 paralax;
	// Use this for initialization
	void Start () {
        paralax = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = target.position + paralax;
           
	}
}
