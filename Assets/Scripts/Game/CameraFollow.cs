    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    [SerializeField]
    private GameObject followTarget;
    [SerializeField] //Para mostrarlas en el editor a pesar de que son privadas
    private Vector3 targetPosition;
    [SerializeField]
    private float cameraSpeed = 4.0f;

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
    }
}
