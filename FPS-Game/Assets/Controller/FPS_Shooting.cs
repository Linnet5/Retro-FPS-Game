using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Shooting : MonoBehaviour {
    [SerializeField] private Camera _camera;
    [SerializeField] private Animator pistolAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        //Move raycast calculations to fixed update if possible in the future
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0)){
            pistolAnimator.SetTrigger("Shoots");
            //pistolAnimator.ResetTrigger("Shoots");
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
            if(Physics.Raycast(ray, out hit)) {
                Transform objectHit = hit.transform;
                if(objectHit.gameObject.CompareTag("Enemy")) {
                    Destroy(objectHit.gameObject);
                }
            }
        }
    }

}
