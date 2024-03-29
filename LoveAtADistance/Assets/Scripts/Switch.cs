using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite onSprite;
    public Sprite offSprite;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    public bool isOn = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = offSprite;
        audioSource = transform.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetType() == typeof(BoxCollider2D) && other.tag == "Player") //Checks it was player body not radius that hits switch
        {
            // Toggle the switch
            if (isOn)
            {
                spriteRenderer.sprite = offSprite;
                isOn = false;
                audioSource.Play();
            }else
            {
                spriteRenderer.sprite = onSprite;
                isOn = true;
                audioSource.Play();
            }
        }
    }
}