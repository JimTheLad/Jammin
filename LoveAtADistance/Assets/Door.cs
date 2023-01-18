using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    [SerializeField]
    private List<Switch> _switches;
    [SerializeField]
    private List<PressurePlate> pressurePlates;
    private bool isOpen;
    [SerializeField]
    private bool stayOpen;
    [SerializeField]
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {// Checks if all required pressure plates or switches have been activated
        if(_switches.Count > 2 || pressurePlates.Count > 2)
        {
            if (_switches.Count != 0)
            {
                if(_switches[0].isOn && _switches[1].isOn && _switches[2].isOn) OpenDoor();
                else CloseDoor();
            }else
            {
                if(pressurePlates[0].isPressed && pressurePlates[1].isPressed && pressurePlates[2].isPressed) OpenDoor();
                else CloseDoor();
            } 
        }else if(_switches.Count > 1 || pressurePlates.Count > 1)
        {
            if (_switches.Count != 0)
            {
                if(_switches[0].isOn && _switches[1].isOn) OpenDoor();
                else CloseDoor();
            }else
            {
                if(pressurePlates[0].isPressed && pressurePlates[1].isPressed) OpenDoor();
                else CloseDoor();
            } 
        }else if(_switches.Count == 1)
        {
            if (_switches.Count != 0)
            {
                if(_switches[0].isOn) OpenDoor();
                else CloseDoor();
            }else
            {
                if(pressurePlates[0].isPressed) OpenDoor();
                else CloseDoor();
            }  
        }
        
    }

    private void OpenDoor()///////CHANGE TO SPRITE OVER
    {
        if(!isOpen)
        {
            isOpen = true;
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
        }
    }
    private void CloseDoor()
    {
        if(isOpen && !stayOpen)
        {
            isOpen = false;
            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
        }
    }
}
