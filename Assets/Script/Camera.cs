using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
