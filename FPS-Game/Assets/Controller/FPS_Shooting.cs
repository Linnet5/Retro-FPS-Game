using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Future implementation: Make pistolAnimator and pistolSound generic so that they can take in any held weapon and animate / play their sounds.

public class FPS_Shooting : MonoBehaviour {
    [Header("Camera")]
    [SerializeField] private Camera _camera;
    
    [Header("Animation")]
    [SerializeField] private Animator pistolAnimator;

    [Header("Sounds")]
    [SerializeField] private AudioSource pistolSounds;
    [SerializeField] private AudioClip shot;
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
            pistolSounds.PlayOneShot(shot);
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
