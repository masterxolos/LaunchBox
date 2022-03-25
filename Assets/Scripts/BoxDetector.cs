using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetector : MonoBehaviour
{
    [SerializeField]
    private Vector2 size;

    [SerializeField] 
    private int gap;
    

    private List<Vector3> _raycasters = new List<Vector3>(20);
    [SerializeField] RaycastHit[] _raycastHits = new RaycastHit[10];
    int i;
    private string name = "a";

    [SerializeField]
    private Material greenMaterial;
    [SerializeField]
    private Material redMaterial;
    [SerializeField] 
    private Material whiteMaterial;
    // Start is called before the first frame update
    void Start()
    {
        CreateVectors();
        i = Mathf.CeilToInt(size.x * size.y) +1;
    }

    // Update is called once per frame
    void Update()
    {
        sendRaycast();
    }

    private void CreateVectors()
    {
        var sizeX = size.x;
        var sizeY = size.y;
        while (sizeX >= 0)
        {
            while (sizeY >= 0)
            {
                var currentPos = transform.position;
                _raycasters.Add(new Vector3((currentPos.x + sizeX * gap), currentPos.y + sizeY * gap, currentPos.z));
                
                sizeY--;
            }
            sizeX--;
        }
    }

    private void sendRaycast()
    {
        while (i > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10000));
            {
                Debug.Log(i);
                _raycastHits[i] = hit;
                Debug.Log("Bir şeye çarptı");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 10000);
                if (hit.collider.tag.Equals("EmptyBox"))
                {
                    Debug.Log("çarptııı");
                    hit.collider.gameObject.GetComponent<Renderer>().material = greenMaterial;
                }
                else
                {
                    hit.collider.gameObject.GetComponent<Renderer>().material = whiteMaterial;
                }
            }
            i--;
        }
    }
}
