using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingBack2StartPoint : MonoBehaviour
{
    private Vector3 startPoint;
    public Cat cat;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = GameObject.Find("OCat").transform.position;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        cat.DesactivateRb ();
        col.transform.position=startPoint+new Vector3(0,7,0);
        cat.ActivateRb ();
    }
}
