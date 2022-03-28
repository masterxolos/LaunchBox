    using System;
using UnityEngine;

public class BoxDetector : MonoBehaviour
{
    [SerializeField]
    private Vector2 size;

    [SerializeField] 
    private int gap;
    
    [SerializeField] private Vector3[] raycasters = new Vector3[20];
    [SerializeField] RaycastHit[] _raycastHits = new RaycastHit[20];
    int i;
    private string name = "a";

    [SerializeField]
    private Material greenMaterial;
    [SerializeField]
    private Material redMaterial;
    [SerializeField] 
    private Material whiteMaterial;

    
    private bool Key;
    private RaycastHit tempHit;
    void Start()
    {
        i = Mathf.CeilToInt(size.x * size.y);
    }

    // Update is called once per frame
    void Update()
    {
        CreateVectors();
        sendRaycast();
        
    }

    private void FixedUpdate()
    {
        
    }

    private void CreateVectors()
    {
        int j = 0;
        int tempX = 0;
        int tempY = 0;
        var sizeX = size.x;
        var sizeY = size.y;
        var currentPos = transform.position;
        while (tempX < sizeX)
        {
            while (tempY < sizeY)
            {
                raycasters[j] = new Vector3(currentPos.x + tempX * gap, currentPos.y , currentPos.z + tempY * gap);
                j++;
                tempY++;
            }

            tempY = 0;
            tempX++;
        }
    }

    private void sendRaycast()
    {
        int a = i+1;
        while (a > 0) // başlangıçta a 5 oluyor 
        {
            a--;
            Debug.Log(a);
            RaycastHit hit;
            Ray ray = new Ray(raycasters[a], Vector3.down);
            Debug.DrawRay(raycasters[a], Vector3.down * 5000, Color.black);
            if (Physics.Raycast(ray, out hit, 5000f)) 
            {
                Debug.Log("ray gönderildi");
                Debug.DrawRay(raycasters[a], Vector3.down * hit.distance, Color.green);
                if(hit.collider == null)
                    return;
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.CompareTag("EmptyBox"))
                    {
                        Debug.Log("çarptııı");
                        hit.collider.gameObject.GetComponent<Renderer>().material = greenMaterial;
                        tempHit = hit;
                        Key = true;
                    }
                    else
                    {
                        Key = false;
                    }
                }
            }
            else if (Key == true)
            {
                tempHit.collider.gameObject.GetComponent<Renderer>().material = whiteMaterial;
                // not anymore.
                Key = false;
            }
        }

    }
}
