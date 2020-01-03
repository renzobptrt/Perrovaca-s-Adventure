using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlood : MonoBehaviour
{   
    private ParticleSystem ps;
    private float duration;

    void Awake(){
        ps = GetComponent<ParticleSystem>();
    }

    void Start(){
        duration = ps.main.duration;
    }

    void Update(){

        duration -= Time.deltaTime;
        if(duration < 0){
            Destroy(gameObject);
        }
    }

}
