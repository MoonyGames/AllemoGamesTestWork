using UnityEngine;

public class outOfTheBounds : MonoBehaviour
{
    [SerializeField] private Rigidbody[] rigidbodies;
    [SerializeField] private sphereMove[] sphereMoves;

    [SerializeField] private UI ui;
    [SerializeField] private cameraFollow CameraFollow;

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Sphere 1" || other.tag == "Sphere 2")
        {
            for(int i = 0; i < 2; i++)
            {
                rigidbodies[i].isKinematic = false;
                sphereMoves[i].enabled = false;

                ui.looseMenuActivate();
                Destroy(CameraFollow);
            }
        }
    }
}
