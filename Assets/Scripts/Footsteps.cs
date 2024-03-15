using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public FMODUnity.EventReference footstepEvent;
    private FMOD.Studio.EventInstance instance;
    private FMOD.Studio.PLAYBACK_STATE playbackState;

    private void PlayFootstep()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/PlayerInteractive/footstepGrass");
        // instance.setParameterByName("Terrain", );
        //instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        instance.start();
        instance.release();
    }


}
