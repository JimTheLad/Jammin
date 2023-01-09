using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConnectionBehaviour : MonoBehaviour
{
  public GameObject centre, red, green, blue, RopeLengthText;
  public float ropeLength = 100f;
  private float ropeLengthMax = 100f;
  private float ropeLengthMin = 10f;
  public bool valid;

  // Update is called once per frame
  void Update()
  {
    // Update the position of the centre object
    centre.transform.position = (red.transform.position + green.transform.position + blue.transform.position) / 3;

    // Calculate the rope length
    ropeLength = Vector2.Distance(red.transform.position, centre.transform.position) + 
                 Vector2.Distance(green.transform.position, centre.transform.position) + 
                 Vector2.Distance(blue.transform.position, centre.transform.position);

    // Update the rope length text
    RopeLengthText.GetComponent<TextMeshPro>().text = ropeLength.ToString("F1");
 
    // Check if the connection is valid
    if (ropeLength > ropeLengthMin && ropeLength < ropeLengthMax)
    {
      valid = true;
      centre.GetComponent<SpriteRenderer>().color = Color.black;
    }else
    {
        centre.GetComponent<SpriteRenderer>().color = Color.red;
    }
  }
}
  