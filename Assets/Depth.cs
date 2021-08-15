using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder = (int)Camera.main.WorldToScreenPoint(this.transform.position).y * -1;
    }
}
