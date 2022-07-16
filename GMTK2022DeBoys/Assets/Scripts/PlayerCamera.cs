using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform player;
    [SerializeField] private Transform orientation;    
    [SerializeField] private float cameraSmoothing;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float maximumZoom;
    [SerializeField] private float minimumZoom;
  
    public float notCenteredDuration;
    public GameObject playerOrientation;
    public Vector3 targetTransform; 

    // Start is called before the first frame update
    void Start()
    {
    }
    void Update(){
    }
    //Update is called once per frame
    void FixedUpdate()
    { 
        ZoomCamera();
        MoveCamera();
    }

    private void MoveCamera()
    {
        float distance = CameraToPlayerDistance();
        if(distance > 0f)
        {
            targetTransform = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            orientation.transform.position = Vector3.Lerp(orientation.transform.position, targetTransform, Time.deltaTime * (distance * cameraSmoothing)); 
        }
    }
    private void ZoomCamera()
    { 
        if(Input.mouseScrollDelta.y > 0 && camera.GetComponent<RectTransform>().localPosition.z < maximumZoom)
        {
            camera.transform.Translate(0,0,Input.mouseScrollDelta.y * zoomSpeed); 
        }
        else if(Input.mouseScrollDelta.y < 0 && camera.GetComponent<RectTransform>().localPosition.z > minimumZoom)
        {
            camera.transform.Translate(0,0,Input.mouseScrollDelta.y * zoomSpeed); 
        }
    }
    private float CameraToPlayerDistance()
    {
        Vector3 orientationPosition = new Vector3(orientation.transform.position.x, orientation.transform.position.y, orientation.transform.position.z);
        Vector3 playerPosition = new Vector3(player.position.x, player.position.y, player.position.z);
        return Vector3.Distance(orientationPosition, playerPosition);
    }

    private float RoundTwoDecimals(float number)
    {
        return Mathf.Round(number * 100f) * 0.01f;
    }
}
