using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombee : MonoBehaviour
{
    Transform wayPoint;
    Rigidbody2D rb;

    private void Awake()
    {
        wayPoint = GameObject.Find("Waypoint").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * walkingSpeed, ForceMode2D.Impulse);
        float angle = Mathf.Atan2(wayPoint.position.y - transform.position.y, wayPoint.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100 * Time.deltaTime);
    }
}
