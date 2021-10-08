using UnityEngine;

public class sphereMove : MonoBehaviour
{
    private float mouseZCoord;

    [SerializeField] private Transform[] spheres;
    [SerializeField] private FixedJoint[] joints;

    [SerializeField] private float maxDistance = 2f;
    private float distance;

    private CharacterController characterController;

    [SerializeField] private lookAtSphere lookAtSphere;

    [SerializeField] private UI ui;
    [SerializeField] private cameraFollow CameraFollow;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mouseZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        lookAtSphere.toLookAt = transform;

        distance = Vector3.Distance(spheres[0].position, spheres[1].position);

        Vector3 movement = GetMouseWorldPosition();
        movement.z = 0;

        MoveTo(movement);

        if(distance >= maxDistance)
        {
            for(int i = 0; i < joints.Length; i++)
            {
                Destroy(joints[i]);
            }

            Destroy(CameraFollow);

            ui.looseMenuActivate();
        }
    }

    private void MoveTo(Vector3 newPos)
    {
        Vector3 moveVector = newPos - transform.position;
        characterController.Move(moveVector * Time.deltaTime * (2 - (distance/maxDistance) * 1.75f));
    }
}