using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -6) Destroy(this.gameObject);
    }
}
