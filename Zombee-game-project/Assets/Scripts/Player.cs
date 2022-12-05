using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] float accSpeed;
    [SerializeField] float steering;
    [SerializeField] GameObject waypoint;
    [SerializeField] Collider2D gameArea;
    Rigidbody2D rb;

    [NonSerialized]
    public List<Vector2> positions = new ();


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(UpdateWaypoint), 0, 0.3f);
        InvokeRepeating(nameof(Log), 0, 0.1f);


        GetInitialPositions();

    }

    void Log()
    {
        if (positions.Find((x) => x == new Vector2((int)transform.position.x, (int)transform.position.y)) != null)
            positions.Remove(positions.Find((x) => x == new Vector2((int)transform.position.x, (int)transform.position.y)));
        Debug.Log(100 - (positions.Count / (gameArea.bounds.size.x * gameArea.bounds.size.y)) * 100 + "%");
    }

    void UpdateWaypoint()
    {
        waypoint.transform.position = transform.position;
    }

    void FixedUpdate()
    {
        float rot = -Input.GetAxis("Horizontal");
        float acc = Input.GetAxis("Vertical");

        Vector2 speed = transform.up * (acc * accSpeed);
        rb.AddForce(speed);

        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
        if (direction >= 0.0f)
        {
            rb.rotation += rot * steering * ((rb.velocity.magnitude + 3 / (rb.velocity.magnitude + 1f) - 2.5f) / 5.0f);
        }
        else
        {
            rb.rotation -= rot * steering * ((rb.velocity.magnitude + 3 / (rb.velocity.magnitude + 1f) - 2.5f) / 5.0f);
        }

        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left));

        Vector2 relativeForce = Vector2.right * (driftForce * 10.0f);
        Debug.DrawLine(rb.position, rb.GetRelativePoint(relativeForce), Color.red);

        rb.AddForce(rb.GetRelativeVector(relativeForce));

    }


    void GetInitialPositions()
    {
        for (int j = (int)gameArea.bounds.min.y; j < gameArea.bounds.max.y; j++)
        {
            for (int i = (int)gameArea.bounds.min.x; i < gameArea.bounds.max.x; i++)
            {
                positions.Add(new (i, j));
                Debug.DrawLine(new (i, j), new Vector2(i + 0.05f, j + 0.05f), Color.red, 999);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Zombee"))
        {
            Destroy(this);
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }



}