using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    
    public void Death()
    {
        SoundManager.Instance.PlaySeOneShot("Death");
    }
}
