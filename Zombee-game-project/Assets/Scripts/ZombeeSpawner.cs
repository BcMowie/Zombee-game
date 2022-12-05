using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombeeSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombeePref;
    GameObject wayPoint;
    Camera cam;
    [SerializeField] Collider2D gameArea;
    Vector2 min, max;
    float x, y;
    private void Awake()
    {
        wayPoint = GameObject.Find("Waypoint");
        cam = Camera.main;
    }

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 3f, 5f);
    }

    void Spawn()
    {
        max = new(cam.transform.position.x + cam.aspect * cam.orthographicSize +2f, cam.transform.position.y +cam.orthographicSize +2f);
        min = new(cam.transform.position.x - cam.aspect * cam.orthographicSize -2f, cam.transform.position.y - cam.orthographicSize -2f);


        while (x < max.x && x > min.x)
        {
            x = Random.Range(gameArea.bounds.min.x, gameArea.bounds.max.x);
        }
        while (y < max.y && y > min.y)
        {
            y = Random.Range(gameArea.bounds.min.y, gameArea.bounds.max.y);
        }



        Vector3 pos = new(x, y, 0);

        GameObject zombee = Instantiate(zombeePref,pos,Quaternion.identity);
        zombee.transform.right = wayPoint.transform.position - transform.position;
        x = 0;
        y = 0;
    }

    // Update is called once per frame

}
