using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToScreen : MonoBehaviour
{
    private void OnEnable()
    {
        float scalex = GetComponent<SpriteRenderer>().sprite.rect.width / Screen.width;
        transform.localScale = new Vector3(transform.localScale.x * scalex, 1, 1);
        print(scalex);
    }
}
