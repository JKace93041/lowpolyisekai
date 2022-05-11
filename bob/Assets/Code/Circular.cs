using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular : MonoBehaviour
{
    
   public float rotationspeed;
    public GameObject pivotObject;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(0, 1, 0), rotationspeed * Time.deltaTime);

    }
}
