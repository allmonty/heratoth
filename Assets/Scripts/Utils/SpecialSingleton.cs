using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections.Generic;

public class SpecialSingleton : MonoBehaviour {

    public static Dictionary<string, SpecialSingleton> Instances = new Dictionary<string, SpecialSingleton>();

    public string specialName = "Special";

    public UnityEvent eventsToCall;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instances.ContainsKey(specialName))
        {
            Destroy(this);
            Destroy(gameObject);
        }
        else
        {
            SceneManager.sceneLoaded += doOnSceneLoaded;
            Instances[specialName] = this;
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= doOnSceneLoaded;
    }

    void doOnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        eventsToCall.Invoke();
    }

    public void addEvent(UnityAction listener)
    {
        eventsToCall.AddListener(listener);
    }
}