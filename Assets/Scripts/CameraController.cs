using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //start pos 0.1,5.4,-6.2
    //start rot 14.191f,-0.018f, -0.003
    // Start is called before the first frame update
    [SerializeField] private Vector3 firstLocation;
    [SerializeField] private Vector3 firstRotation;
    [SerializeField] private Vector3 lastLocation;
    [SerializeField] private Vector3 lastRotation;
    [SerializeField] private float firstDelay;
    void Start()
    {
        transform.position = firstLocation;
        transform.eulerAngles = firstRotation;
        StartCoroutine(cameraMovement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator cameraMovement()
    {
        yield return new WaitForSeconds(firstDelay);
        transform.DOMove(lastLocation, 1f);
        transform.DORotate(lastRotation, 1f);
    }
}
