using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]public void PauseOn()
    {
        Time.timeScale = 0;
    }
    [SerializeField]public void PauseOff()
    {
        Time.timeScale = 1;
    }
}
