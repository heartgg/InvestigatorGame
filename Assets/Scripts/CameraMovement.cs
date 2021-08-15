using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject player;
    Vector3 playerPosition;
    Vector3 smoothPosition;

    void LateUpdate() {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, -1);
        smoothPosition = Vector3.Lerp(transform.position, playerPosition, speed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
