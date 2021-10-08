using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followTransform;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(followTransform.position.x, followTransform.position.y, -5f), Time.deltaTime * 1.2f);
    }
}
