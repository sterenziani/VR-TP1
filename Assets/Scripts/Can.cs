using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public bool isStanding = true;

    void Start()
    {
        isStanding = true;
    }

    void Update()
    {
        if (isStanding && (transform.up.y < 0.75 || transform.localPosition.y < 0))
            isStanding = false;
    }
}
