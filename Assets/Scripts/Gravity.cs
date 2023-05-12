using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0,-9.8f,0));
    }
}
