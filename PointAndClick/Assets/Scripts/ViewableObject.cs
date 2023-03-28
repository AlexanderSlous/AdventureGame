using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewableObject : MonoBehaviour
{
    private PointAndClickController AdventureController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3.Distance(AdventureController.transform.position, gameObject.transform.position);

    }
}
