using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D GameArea;
    void Start()
    {
        RandomizeBoxPos();
    }


    void RandomizeBoxPos()
    {
        Bounds bounds = GameArea.bounds;
        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

        transform.position = new Vector3(x, y, 0);
    }
}
