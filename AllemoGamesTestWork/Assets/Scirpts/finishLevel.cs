using UnityEngine;

public class finishLevel : MonoBehaviour
{
    private SphereCollider sphereCollider;

    [SerializeField] private UI ui;
    [SerializeField] private cameraFollow CameraFollow;
    [SerializeField] private sphereMove sphereMove1, sphereMove2;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sphere 1" || other.tag == "Sphere 2")
        {
            ui.endMenuActivation();
            Destroy(CameraFollow);

            sphereMove1.enabled = false;
            sphereMove2.enabled = false;

            sphereCollider.enabled = false;
        }
    }
}
