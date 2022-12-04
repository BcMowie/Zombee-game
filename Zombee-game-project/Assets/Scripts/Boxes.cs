using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D GameArea;
    [SerializeField]
    GameObject boxPrefab;
    List<Vector3> collidersPositions = new(); 
    void Start()
    {
        RandomizeBoxPos();
        collidersPositions.Add(Vector3.zero);
    }


    void RandomizeBoxPos()
    {
        Bounds bounds = GameArea.bounds;
        

       


        for (int i = 1; i < Random.Range(8, 15); i++)
        {
            float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
            float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

            while (collidersPositions.Contains(new Vector3(x, y, 0)))
            {
                x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
                y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));
            }

            collidersPositions.Add(new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), 0));
            Instantiate(boxPrefab, new Vector3(collidersPositions[i-1].x, collidersPositions[i-1].y, 0), Quaternion.Euler(0, 0,Random.Range(0, 90)));

        }



    }
}
