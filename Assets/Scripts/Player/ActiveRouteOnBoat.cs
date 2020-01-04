using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRouteOnBoat : MonoBehaviour
{
    private GoToBezierRoute goToBezierRoute;
    private GameObject children;
    public Transform initialRoute;
    public Transform finalRoute;
    private Vector3 startPosition;
    private Vector3 endPosition;


    void Start()
    {
        goToBezierRoute = GetComponent<GoToBezierRoute>();
        startPosition = initialRoute.position;
        endPosition = finalRoute.position;
        Debug.Log(endPosition);
    }

    void Update()
    {
        if (Vector3.Distance(this.transform.position, finalRoute.position) < 0.5)
        {
            if (children != null)
            {
                children.transform.position = new Vector3(this.transform.position.x,
                                                        this.transform.position.y + 3.0f,
                                                        this.transform.position.z);

                children.transform.parent = null;
            }
            Vector3 tempPosition = startPosition;
            startPosition = endPosition;
            endPosition = tempPosition;
            goToBezierRoute.enabled = false;

            this.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            children = collision.gameObject;
            collision.gameObject.transform.parent = gameObject.transform;
            collision.gameObject.transform.position = this.transform.position;
            goToBezierRoute.enabled = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
    }
}
