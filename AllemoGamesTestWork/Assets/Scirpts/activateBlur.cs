using UnityEngine;
using UnityEngine.UI;

public class activateBlur : MonoBehaviour
{
    [SerializeField] private Image blur;

    private void Update()
    {
        blur.material.SetFloat("_Size", Mathf.Lerp(blur.material.GetFloat("_Size"), 5f, Time.deltaTime * 0.5f));
    }
}