using UnityEngine;
using System.Collections;

public class collectCoin : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private AudioSource audioSource;
    private MeshCollider meshCollider;

    [SerializeField] private GameObject particles;
    [SerializeField] private UI money;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        meshCollider = GetComponent<MeshCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + 1);
            money.updateMoney();

            meshRenderer.enabled = false;
            particles.SetActive(true);
            meshCollider.enabled = false;

            audioSource.Play();

            StartCoroutine(destroyAfterTime(this.gameObject));
        }

        Destroy(meshCollider);
    }

    private IEnumerator destroyAfterTime(GameObject gameObject)
    {
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
