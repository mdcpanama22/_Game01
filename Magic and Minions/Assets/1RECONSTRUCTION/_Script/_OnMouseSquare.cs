﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _OnMouseSquare : MonoBehaviour {
    public Color _originalColor;

    MeshRenderer _mRenderer;

    public bool _Occupied;
	// Use this for initialization
	void Start () {

        _mRenderer = GetComponent<MeshRenderer>();
        _originalColor = _mRenderer.material.color;
	}

    private void OnMouseDown()
    {
        if (GetComponent<SphereCollider>().enabled && GetComponent<MeshRenderer>().enabled)
        {
            GM.instance.ChosenPosition(gameObject);
        }
    }
    private void OnMouseOver()
    {
        _mRenderer.material.color = GM.instance.ChangeSquareColor(_originalColor);
    }

    private void OnMouseExit()
    {
        _mRenderer.material.color = _originalColor;
    }
}
