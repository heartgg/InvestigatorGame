using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float radius = 1f;
    [SerializeField] private GameObject mark;
    private bool marked = false;

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Selected(Vector3 playerPos) {
        if (Vector3.Distance(playerPos, transform.position) <= radius)
        {
            Debug.Log("clicked");
            if (!marked)
            {
                GameObject clone = Instantiate(mark, transform.position + new Vector3(-0.075f, -0.075f, 0), Quaternion.identity);
                clone.SetActive(true);
                marked = true;
            }
        }
    }

    public bool Check (Vector3 playerPos) {
        if (Vector3.Distance(playerPos, transform.position) <= radius) return true;
        else return false;
    }
}
