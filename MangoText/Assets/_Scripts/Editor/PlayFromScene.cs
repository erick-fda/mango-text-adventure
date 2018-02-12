/*========================================================================================
    PlayFromScene                                                                    *//**
	
    Creates a menu item that starts and stops play mode from the specified scene.
	
    Copyright 2018 Erick Fernandez de Arteaga. All rights reserved.
        https://www.linkedin.com/in/erick-fda
        https://bitbucket.org/erick-fda
	
*//*====================================================================================*/

/*========================================================================================
	Dependencies
========================================================================================*/
using UnityEditor;
using UnityEditor.SceneManagement;

/*========================================================================================
	MyMonoBehaviour
========================================================================================*/
public static class PlayFromScene
{
	/*----------------------------------------------------------------------------------------
		Static Fields
	----------------------------------------------------------------------------------------*/
    /* Scene to play from. */
    const string DEFAULT_START_SCENE_PATH = "Assets/_Scenes/scene_persistent.unity";

	/*----------------------------------------------------------------------------------------
		Static Methods
	----------------------------------------------------------------------------------------*/
    /**
        Creates a menu item to start and stop play mode with Alt+0 as the keyboard 
        shortcut.
    */
	[MenuItem("Play/Play or Stop &0")]
    public static void PlayOrStop()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene(DEFAULT_START_SCENE_PATH);
        EditorApplication.isPlaying = true;
    }
}
