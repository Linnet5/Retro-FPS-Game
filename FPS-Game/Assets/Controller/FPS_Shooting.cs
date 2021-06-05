using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Shooting : MonoBehaviour {
    [SerializeField] private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //Move raycast calculations to fixed update if possible in the future
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Firing");
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
            if(Physics.Raycast(ray, out hit)) {
                Debug.DrawRay(ray.origin, ray.direction*100.0f, Color.red, 1.0f);
                Transform objectHit = hit.transform;
                Debug.Log(objectHit);
            }
            else {
                Debug.Log("No object hit");
            }
        }
    }

}
