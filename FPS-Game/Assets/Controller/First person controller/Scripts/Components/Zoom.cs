using UnityEngine;

public class Zoom : MonoBehaviour
{
    [HideInInspector]
    public float sensitivity = 1;
    Camera camera;
    [HideInInspector]
    public float defaultFOV;
    [Tooltip("Effectively the min FOV that we can reach while zooming with this camera.")]
    public float maxZoom = 15;
    [HideInInspector]
    public float zoomAmount;
    private Transform pistolHolder;
    private float pistolHolderDefaultX;


    void Awake()
    {
        camera = GetComponent<Camera>();
    }

    void Start()
    {
        defaultFOV = camera.fieldOfView;
        pistolHolder = transform.GetChild(0); //Should be the pistol holder index
        pistolHolderDefaultX = pistolHolder.localPosition.x;
    }

    void Update()
    {
        /* Code commented away from script asset
        zoomAmount += Input.mouseScrollDelta.y * sensitivity * .05f;
        */
        AimDownSights();
        zoomAmount = Mathf.Clamp01(zoomAmount);
        camera.fieldOfView = Mathf.Lerp(defaultFOV, maxZoom, zoomAmount);
    }

    void AimDownSights() {
        if(Input.GetMouseButton(1)) {
            zoomAmount += maxZoom;
            pistolHolder.localPosition = new Vector3(0.0f, pistolHolder.localPosition.y, pistolHolder.localPosition.z);
        }
        else {
            zoomAmount -= maxZoom;
            pistolHolder.localPosition = new Vector3(pistolHolderDefaultX, pistolHolder.localPosition.y, pistolHolder.localPosition.z);
        }
    }
}
