using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Sprite pressedSprite;
    public Sprite notPressedSprite;
    private SpriteRenderer spriteRenderer;
    public bool isPressed = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = notPressedSprite;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetType() == typeof(BoxCollider2D) && col.tag == "Player") //Checks it was player body not radius that hits switch //PRESS
        {
            spriteRenderer.sprite = pressedSprite;
            isPressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetType() == typeof(BoxCollider2D) && col.tag == "Player") //Checks it was player body not radius that hits switch //RELEASE
        {
            spriteRenderer.sprite = notPressedSprite;
            isPressed = false;
        }
    }
}