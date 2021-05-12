using GameAnalyticsSDK;
using UnityEngine;

public class GAManager : MonoBehaviour
{
    void Awake()
    {
        GameAnalytics.Initialize();
        
        DontDestroyOnLoad(this);
    }

  
}
