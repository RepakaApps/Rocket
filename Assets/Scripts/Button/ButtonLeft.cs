﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLeft : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool onObject;
    public GameObject player;
    public Player pl;

    public float rotSpeed;

    public void OnPointerEnter(PointerEventData eventData) => onObject = true;

    public void OnPointerExit(PointerEventData eventData) => onObject = false;

    private void Start()
    {
        pl.GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        RotationLeft();
    }

    void RotationLeft()
    {
        float rotationSpeed = rotSpeed * Time.deltaTime;

        pl.rigidBody.freezeRotation = true;
        if (onObject && Input.GetMouseButton(0))
        {
            pl.transform.Rotate(-Vector3.forward * rotationSpeed);
        }
    }
}
