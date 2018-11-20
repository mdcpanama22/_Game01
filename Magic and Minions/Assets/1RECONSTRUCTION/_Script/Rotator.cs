//original file by matt
//used by Board_GEO
//used for unknown



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script based off of: https://answers.unity.com/questions/177391/drag-to-rotate-gameobject.html
 */

public class Rotator : MonoBehaviour {

	private float _sensitive;
	private Vector3 _mousePoint, _mouseOffset, _rotation;
	private bool _isRotating;

	// Use this for initialization
	void Start(){
		_sensitive = 0.4f;
		_rotation = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update(){
		if(_isRotating){
			_mousePoint = (Input.mousePosition - _mousePoint);
			_rotation.z = -(_mouseOffset.x + _mousePoint.y) * _sensitive;
			transform.Rotate(_rotation);
			_mousePoint = Input.mousePosition;
		}
	}

	void OnMouseDown(){
		_isRotating = true;

		_mousePoint = Input.mousePosition;
	}

	void OnMouseUp(){
		_isRotating = false;	
	}
}