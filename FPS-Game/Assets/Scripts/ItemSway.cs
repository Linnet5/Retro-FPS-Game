using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSway : MonoBehaviour
{    
    private Quaternion idleRotation;
    private GameObject fpsCam;
    private FirstPersonLook fpsLook;

    //The rate for the random generator to generate
    private float randomRate;
    private float timer;

    [Range(0.0f, 20.0f)]
    [SerializeField] private float amplitude;

    [Range(0.0f, 0.1f)]
    [SerializeField] private float interpolatingSpeed;


    private void Start() {
        idleRotation = transform.localRotation;
        fpsCam = GameObject.FindGameObjectWithTag("MainCamera");
        fpsLook= fpsCam.GetComponent<FirstPersonLook>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        //Sway the item as the player looks around. Amount of sway depends on turning speed
        gameObject.transform.localRotation = Quaternion.Lerp(idleRotation, 
        Quaternion.AngleAxis(fpsLook.getAppliedMouseDelta().x*amplitude, Vector3.up) * 
        Quaternion.AngleAxis(fpsLook.getAppliedMouseDelta().y*amplitude, Vector3.right), interpolatingSpeed);
        
        idleRotation = gameObject.transform.localRotation;
    }
}
