using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(0, 0, 2.0f);
    }
}
