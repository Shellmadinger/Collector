using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerText : MonoBehaviour
{
    public Text playerText;

    // Update is called once per frame
    void Update()
    {
        Vector3 textPos = Camera.main.WorldToScreenPoint(this.transform.position);
        playerText.transform.position = textPos;
    }
}
