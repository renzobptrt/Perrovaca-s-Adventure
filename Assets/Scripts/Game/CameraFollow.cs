    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   

    //Features
    [SerializeField]
    private GameObject followTarget;
    [SerializeField] //Para mostrarlas en el editor a pesar de que son privadas
    private Vector3 targetPosition;
    [SerializeField]
    private float cameraSpeed = 4.0f;

    //Limits
    private Camera theCamera;
    private BoxCollider2D cameraLimits;
    private Vector3 minLimits, maxLimits;
    private float halfWidth, halfHeight;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(followTarget.transform.position.x,
                                    followTarget.transform.position.y,
                                    this.transform.position.z);
        //Mover de un punto a otro de forma suave, Linea Interpolada
        this.transform.position = Vector3.Lerp(this.transform.position,
                                                targetPosition,
                                                cameraSpeed*Time.deltaTime);
        float clampX = Mathf.Clamp(this.transform.position.x,
                                 minLimits.x + halfWidth,
                                 maxLimits.x - halfWidth);
        float clampy = Mathf.Clamp(this.transform.position.y,
                                 minLimits.y + halfHeight,
                                 maxLimits.y - halfHeight);
        this.transform.position = new Vector3(clampX,clampy, this.transform.position.z);
    }

    public void ChangeLimits(BoxCollider2D newCameraLimits){
        minLimits = newCameraLimits.bounds.min;
        maxLimits = newCameraLimits.bounds.max;

        theCamera = GetComponent<Camera>();
        //Camera Limits
        halfWidth = theCamera.orthographicSize;
        halfHeight = halfWidth/ Screen.width * Screen.height;
    }
}
