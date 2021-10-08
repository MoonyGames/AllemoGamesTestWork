using UnityEngine;

public class lookAtSphere : MonoBehaviour
{
    public Transform toLookAt;

    private void Update()
    {
        Vector3 targetDirection = toLookAt.position - transform.position;

        targetDirection.y = 0.0f;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDirection), Time.time);
    }
}
