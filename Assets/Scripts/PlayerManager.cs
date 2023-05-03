using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager obj;
    void Awake()
    {
        obj = this;
    }

    public Transform player;


}
