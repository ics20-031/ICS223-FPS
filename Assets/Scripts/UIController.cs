using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    private int score = 0;
    
    [SerializeField]
    private TextMeshProUGUI scoreValue;

    [SerializeField]
    private Image healthBar;

    [SerializeField]
    private Image crossHair;

    [SerializeField]
    private OptionsPopup optionsPopup;

    [SerializeField]
    private RayShooter rayShooter;

    [SerializeField]
    private SettingsPopup settingsPopup;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        healthBar.fillAmount = 1;
        healthBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsPopup.IsActive() && !settingsPopup.IsActive())
        {
            SetGameActive(false);
            optionsPopup.Open();
        }
    }

    // update score display
    public void UpdateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            crossHair.gameObject.SetActive(true);
            rayShooter.canShoot = true;
        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            crossHair.gameObject.SetActive(false);
            rayShooter.canShoot = false;
        }
    }

}
