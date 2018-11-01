using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    private Transform _transform;
    private Transform _transformT;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _transformT = _transform;
        _transform.LookAt(Camera.main.transform.position, Vector3.up);
        _transform.rotation = Quaternion.Euler(new Vector3(_transform.transform.rotation.x, _transformT.transform.rotation.y, _transformT.transform.rotation.z));
    }
}
