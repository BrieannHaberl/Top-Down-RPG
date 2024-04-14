using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PersistentTitleMusic : MonoBehaviour

{
    
    public FMODUnity.EventReference footstepEvent;
    private FMOD.Studio.EventInstance instance;
    private FMOD.Studio.PLAYBACK_STATE playbackState;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/musicTitle");
        instance.start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Toggle.inGame == 1)
        {
            StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(7);
        instance.setParameterByName("Scene Transition", 1);
    }
}
