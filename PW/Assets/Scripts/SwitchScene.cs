using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [System.Obsolete]
    public void ChangeScene(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }
}