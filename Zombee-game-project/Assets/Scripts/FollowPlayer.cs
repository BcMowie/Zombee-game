using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;
    BoxCollider2D gameArea;
    Camera cam;
    float x, y;
    void Start()
    {
        player = GameObject.Find("Player");
        gameArea = GameObject.Find("GameArea").GetComponent<BoxCollider2D>();
        cam = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        
        x = Mathf.Clamp(player.transform.position.x, gameArea.bounds.min.x + cam.aspect * cam.orthographicSize - 1, gameArea.bounds.max.x - cam.aspect * cam.orthographicSize + 1);
        y = Mathf.Clamp(player.transform.position.y, gameArea.bounds.max.y - cam.orthographicSize*2, gameArea.bounds.min.y + cam.orthographicSize * 2);

        transform.position = new Vector3(x, y, -10);

    }
}
