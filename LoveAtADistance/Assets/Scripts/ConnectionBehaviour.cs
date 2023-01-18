using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConnectionBehaviour : MonoBehaviour
{
  public GameObject centre, red, green, blue, RopeLengthText;
  public float ropeLength = 100f;
  [SerializeField]
  private float ropeLengthMax = 12f;
  [SerializeField]
  private float ropeLengthMin = 6f;
  [SerializeField]
  private float warningRange = 2f;
  private SpriteRenderer spriteRenderer;
  public bool valid;

  void Start()
  {
    spriteRenderer = centre.GetComponent<SpriteRenderer>();
  }
  // Update is called once per frame
  void Update()
  {
    // Update the position of the centre object
    centre.transform.position = (red.transform.position + green.transform.position + blue.transform.position) / 3;

    // Calculate the rope length
    ropeLength = Vector2.Distance(red.transform.position, centre.transform.position) + Vector2.Distance(green.transform.position, centre.transform.position) + Vector2.Distance(blue.transform.position, centre.transform.position);

    // Update the rope length text
    RopeLengthText.GetComponent<TextMeshPro>().text = ropeLength.ToString("F1");
 
    

    // Check if the connection is valid
    if(ropeLength > ropeLengthMin && ropeLength < ropeLengthMax)
    {
      valid = true;
      spriteRenderer.color = Color.black;
    }else
    {
        spriteRenderer.color = Color.red;
    }

    // Check if ropeLength is withing warning Range
    if(ropeLength > ropeLengthMax - warningRange)
    {
      Color tmp = spriteRenderer.color;
      tmp.a = 255f * (((ropeLength - (ropeLengthMax - warningRange))) / warningRange);
      //print(255f * (((ropeLength - (ropeLengthMax - warningRange))) / warningRange));
      //print(((ropeLength - (12 - 2)) / 2));
      //print((ropeLengthMax - warningRange));
      spriteRenderer.color = tmp;

    }else if(ropeLength < ropeLengthMin + warningRange)
    {
      //Color tmp = spriteRe nderer.color;
      //tmp.a = 255 * ((ropeLength - (ropeLengthMin + warningRange)) / ropeLengthMax);
      //spriteRenderer.color = tmp;
    }

  }
}
  