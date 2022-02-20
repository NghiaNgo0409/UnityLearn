using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private Text _txtLives;
    [SerializeField]
    private Text _txtScore;
    [SerializeField]
    private RectTransform _pnlReplay;

    [SerializeField]
    private PnlSetting _pnlSetting;

    [SerializeField]
    private AudioSetting _bgmAudioSetting;
    [SerializeField]
    private AudioSetting _sfxAudioSetting;

    [SerializeField]
    private Button _btnReplay;

    // Start is called before the first frame update
    void Start()
    {
        //_btnReplay.onClick.AddListener(OnBtnReplayClicked);
        _bgmAudioSetting.Setup(PlayerPrefs.GetFloat(_bgmAudioSetting.ParamName));
        _sfxAudioSetting.Setup(PlayerPrefs.GetFloat(_sfxAudioSetting.ParamName));
    }

    public void SetLives(int live)
    {
        _txtLives.text = $"Lives: {live}";
    }

    public void SetScore(int score)
    {
        _txtScore.text = $"Score: {score}";
    }

    public void ShowReplayUI()
    {
        _pnlReplay.gameObject.SetActive(true);
    }

    public void OnBtnReplayClicked()
    {
        Debug.Log("OnBtnReplayClicked");
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayScene");
    }

    public void OnBtnExitClicked()
    {
        Debug.Log("OnBtnExitClicked");
        //Application.Quit();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnBtnSettingClicked()
    {
        Debug.Log("OnBtnSettingClicked");
        Time.timeScale = 0f;
        _pnlSetting.gameObject.SetActive(true);
    }
}
