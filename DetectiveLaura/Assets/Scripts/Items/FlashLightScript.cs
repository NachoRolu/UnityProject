using UnityEngine;

public class FlashLightScript : MonoBehaviour
{

    [SerializeField] private float cameraRotationDelay = .2f;

    private Camera cam;

    private void Awake() {
        cam = Camera.main;
    }

    private void Update() {
        transform.forward = Vector3.Lerp(transform.forward, cam.transform.forward, cameraRotationDelay * Time.deltaTime);
    }

}
