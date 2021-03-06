using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{

    public static bool followMouse;

    //code sourced from https://www.youtube.com/watch?v=6hp9-mslbzI

    private void Awake()
    {
        followMouse = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (followMouse)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
    }
}
