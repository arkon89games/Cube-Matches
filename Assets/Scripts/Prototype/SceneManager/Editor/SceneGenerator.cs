using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class SсeneGenerator
{
    static SсeneGenerator()
    {
        EditorSceneManager.newSceneCreated += OnSceneCreated;
        // Debug.Log("Hellow!");
    }

    public static void OnSceneCreated(Scene scene, NewSceneSetup setup, NewSceneMode mode)
    {
        var cameraGameObject = Camera.main.transform;
        var lightGameObject = GameObject.Find("Directional Light").transform;

        var setupFoldier = new GameObject("[SETUP]").transform;

        var lights = new GameObject("Lights").transform;
        lights.parent = setupFoldier;
        lightGameObject.parent = lights;

        var cameras = new GameObject("Cameras").transform;
        cameras.parent = setupFoldier;
        cameraGameObject.parent = cameras;

        var worldFoldier = new GameObject("[WORLD]").transform;
        new GameObject("Static").transform.parent = worldFoldier;
        new GameObject("Dinamic").transform.parent = worldFoldier;

        new GameObject("[UI]");

        Debug.Log("New Scene Created!");
    }
}

