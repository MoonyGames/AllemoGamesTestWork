using UnityEngine;

public class rotator : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private void Update()
    {
        transform.Rotate(new Vector3(0f, speed, 0f) * Time.deltaTime);
    }
}
