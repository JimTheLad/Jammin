using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    [SerializeField]
    private Switch _switch;
    [SerializeField]
    private PressurePlate pressurePlate;
    private bool isOpen;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (_switch != null)
        {
            if(_switch.isOn) OpenDoor();
            else CloseDoor();
        }else
        {
            if(pressurePlate.isPressed) OpenDoor();
            else CloseDoor();
        }
    }

    private void OpenDoor()
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
        if(isOpen)
        {
            isOpen = false;
            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
        }
    }
}
