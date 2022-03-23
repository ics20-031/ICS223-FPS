using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingsPopup : MonoBehaviour
{

    [SerializeField]
    private OptionsPopup OptionsPopup;

    [SerializeField]
    private TextMeshProUGUI difficultyLabel;

    [SerializeField]
    private Slider difficultySlider;

    // Start is called before the first frame update
    void Start()
    {
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

    public void OnOKButton()
    {
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        gameObject.SetActive(false);
        OptionsPopup.Open();
    }

    public void OnCancelButton()
    {
        gameObject.SetActive(false);
        OptionsPopup.Open();
    }

    public void UpdateDifficulty(float difficulty)
    {
        difficultyLabel.text = "Difficulty: " + ((int)difficulty).ToString();
    }

    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }

}
