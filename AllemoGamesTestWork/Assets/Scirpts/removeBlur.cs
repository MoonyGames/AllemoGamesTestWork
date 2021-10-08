using UnityEngine;
using UnityEngine.UI;

public class removeBlur : MonoBehaviour
{
    [SerializeField] private Image blur;

    private void Update()
    {
        blur.material.SetFloat("_Size", Mathf.Lerp(blur.material.GetFloat("_Size"), 0f, Time.deltaTime * 0.5f));
    }
}
