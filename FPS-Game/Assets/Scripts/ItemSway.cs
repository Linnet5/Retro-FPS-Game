using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSway : MonoBehaviour
{    
    private Quaternion idleRotation;
    private Vector3 idlePosition;
    private Vector3 defaultPosition;
    private GameObject fpsCam;
    private FirstPersonLook fpsLook;

    //The rate for the random generator to generate
    private float randomRate;
    private float timer;


    private void Start() {
        idleRotation = transform.localRotation;
        defaultPosition = idlePosition = transform.localPosition;
        fpsCam = GameObject.FindGameObjectWithTag("MainCamera");
        fpsLook= fpsCam.GetComponent<FirstPersonLook>();
        randomRate = 0.5f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        //Sway the item as the player looks around. Amount of sway depends on turning speed
        gameObject.transform.localRotation = Quaternion.Lerp(idleRotation, Quaternion.AngleAxis(fpsLook.getAppliedMouseDelta().x*10.0f, Vector3.up) * Quaternion.AngleAxis(fpsLook.getAppliedMouseDelta().y*10.0f, Vector3.right), 0.005f);
        idleRotation = gameObject.transform.localRotation;

/*
        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) {
            Debug.Log("moving");
            float randomFloat = Random.value/100.0f;
            Vector3 newPosition = new Vector3(idlePosition.x + randomFloat, idlePosition.y + randomFloat, idlePosition.z);
            transform.localPosition = Vector3.Lerp(idlePosition, newPosition, 0.005f);
            idlePosition = newPosition;
        }
        else {
            transform.localPosition = Vector3.Lerp(transform.localPosition, defaultPosition, 0.005f);
        }
*/
    }
}
