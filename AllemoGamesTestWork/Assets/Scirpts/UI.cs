using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private sphereMove[] sphereMoves;
    [SerializeField] private Animator UIAnimator;
    [SerializeField] private removeBlur removeBlurStart, removeBluerEnd, removeBlurLoose;
    [SerializeField] private activateBlur activateBlurEnd, activateBlurLoose;
    [SerializeField] private cameraFollow CameraFollow;
    [SerializeField] private Image blur;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip[] sounds;

    [SerializeField] private GameObject startMenu, endMenu, looseMenu;
    [SerializeField] private TextMeshProUGUI moneyText, costText;

    private void Start()
    {
        blur.material.SetFloat("_Size", 5f);
        audioSource = GetComponent<AudioSource>();

        updateMoney();
    }

    public void Play()
    {
        removeBlurStart.enabled = true;
        CameraFollow.enabled = true;

        UIAnimator.SetBool("Exit", true);

        for(int i = 0; i < 2; i++)
        {
            sphereMoves[i].enabled = true;
        }

        audioSource.Play();
    }

    public void Home()
    {
        audioSource.Play();

        SceneManager.LoadScene(0);
    }

    public void looseMenuActivate()
    {
        Destroy(removeBlurLoose);
        activateBlurLoose.enabled = true;
        startMenu.SetActive(false);
        endMenu.SetActive(false);

        looseMenu.SetActive(true);

        UIAnimator.SetBool("Loose", true);
        audioSource.PlayOneShot(sounds[0]);
    }

    public void endMenuActivation()
    {
        Destroy(removeBluerEnd);
        activateBlurEnd.enabled = true;
        startMenu.SetActive(false);
        looseMenu.SetActive(false);

        endMenu.SetActive(true);

        UIAnimator.SetBool("Complete", true);
        audioSource.PlayOneShot(sounds[1]);
    }

    public void updateMoney()
    {
        moneyText.text = "$: " + PlayerPrefs.GetInt("Money", 0).ToString();
        costText.text = "$: " + (10 + PlayerPrefs.GetInt("Cost", 0)).ToString();
    }

    public void buySmth()
    {
        if (PlayerPrefs.GetInt("Money", 0) >= 10 + PlayerPrefs.GetInt("Cost", 0))
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - (PlayerPrefs.GetInt("Cost", 0) + 10));
            PlayerPrefs.SetInt("Cost", PlayerPrefs.GetInt("Cost", 0) + 1);

            updateMoney();
        }
    }
}
