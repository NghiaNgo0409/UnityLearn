using System.Collections;
using System.Collections.Generic;
using Firebase.Extensions;
using UnityEngine;
using Firebase.Analytics;
using UnityEngine.SceneManagement;

public class FirebaseManager : MonoBehaviour
{
    static FirebaseManager instance;
    public static FirebaseManager Instance => instance; 
    public Firebase.FirebaseApp FirebaseAppInstance;
    public bool IsReady {get; private set;}
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        IsReady = false;
    }

    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available) {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                FirebaseAppInstance = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
                IsReady = true;

                FirebaseAnalytics.LogEvent("Firebase Init", "Firebase ready", "true");
            } else {
                UnityEngine.Debug.LogError(System.String.Format(
                "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UserLogin()
    {
        FirebaseAnalytics.LogEvent("User Login", "name", "Nova");
        
        StartCoroutine(IsLoadSceneAsync());
    }

    IEnumerator IsLoadSceneAsync()
    {
        var async = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while(async.progress >= 0.9f)
        {
            Debug.Log("Load scene progress: " + async.progress);
            yield return null;
        }
        async.allowSceneActivation = true;
    }
}
