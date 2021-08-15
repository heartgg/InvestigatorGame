using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{
    [SerializeField] private bool blinking = true;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float offset = 0f;
    void Start() {
        StartCoroutine(Blinking());
    }
 
    IEnumerator Blinking() {
        WaitForSeconds wait = new WaitForSeconds(speed);
        WaitForSeconds waitOffset = new WaitForSeconds(offset);

        yield return waitOffset;
        while (blinking)
        {
            GetComponent<Light2D>().intensity = 0;
            yield return wait;
            GetComponent<Light2D>().intensity = 1;
            yield return wait;
        }
    }
}
