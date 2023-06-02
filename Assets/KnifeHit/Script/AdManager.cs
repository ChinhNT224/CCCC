using UnityEngine;

public class AdManager : MonoBehaviour
{
    public static AdManager Instance { get; private set; }

    private bool shouldShowAds = true;

    public bool ShouldShowAds
    {
        get { return shouldShowAds; }
        set { shouldShowAds = value; }
    }

    private const string shouldShowAdsKey = "ShouldShowAds";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }

        if (PlayerPrefs.HasKey(shouldShowAdsKey))
        {
            shouldShowAds = PlayerPrefs.GetInt(shouldShowAdsKey) == 1;
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(shouldShowAdsKey, shouldShowAds ? 1 : 0);
    }

    public void SetAdStatus(bool enabled)
    {
        shouldShowAds = enabled;
    }

    public void ToggleAdStatus()
    {
        shouldShowAds = false;
    }
}
