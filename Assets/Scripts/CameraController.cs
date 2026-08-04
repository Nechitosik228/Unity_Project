using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private List<Transform> Points;
    [SerializeField] private Camera maincamera;

    private int currentindex = 0;
    void Start()
    {
        currentindex = 0;
        Transform point = Points[currentindex];
        maincamera.transform.position = point.position;
        maincamera.transform.rotation = point.rotation;
    }

    
    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentindex++;
            if (currentindex == Points.Count) currentindex = 0;
            Transform point = Points[currentindex];
            maincamera.transform.position = point.position;
            maincamera.transform.rotation = point.rotation;
        }
    }
}
