using UnityEngine;

public class CameraHolderScript : MonoBehaviour
{

    [SerializeField] private Transform cameraPosition;

    private void Update() {
        transform.position = cameraPosition.position;
    }

}
