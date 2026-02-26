using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera_takip : MonoBehaviour
{
    public GameObject hedef;
    Vector3 uzaklik;

    void Start()
    {
        uzaklik=transform.position-hedef.transform.position;
    }

    private void LateUpdate() {
        if(player.dustuMu){
            return;
        }
        transform.position=hedef.transform.position+uzaklik;

    }
}
