using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Sprite pressedSprite;
    public Sprite notPressedSprite;
    private SpriteRenderer spriteRenderer;
    public bool isPressed = false;
    private AudioSource audioSource;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = notPressedSprite;
        audioSource = transform.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetType() == typeof(BoxCollider2D) && col.tag == "Player") //Checks it was player body not radius that hits switch //PRESS
        {
            spriteRenderer.sprite = pressedSprite;
            isPressed = true;
            audioSource.Play();
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