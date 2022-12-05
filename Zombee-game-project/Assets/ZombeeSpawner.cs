using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombeeSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombeePref;
    GameObject wayPoint;
    private void Awake()
    {
        wayPoint = GameObject.Find("Waypoint");
    }

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 3f, 10f);
    }

    void Spawn()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        
        GameObject zombee = Instantiate(zombeePref,pos,Quaternion.identity);
        zombee.transform.right = wayPoint.transform.position - transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
