using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renkdegisimi : MonoBehaviour
{
    public List<Color> renkler;
    Color ilkrenk, ikincirenk;
    int birinci_renk;
    public Material zemin_material;
    void Start()
    {
        birinci_renk=Random.Range(0,renkler.Count);
        Camera.main.backgroundColor=renkler[birinci_renk];
        zemin_material.color=renkler[birinci_renk];
        ikincirenk=renkler[ikincirenksec()];

    }

    // Update is called once per frame
    void Update()
    {
        Color fark=zemin_material.color-ikincirenk;
        if(Mathf.Abs(fark.r)+Mathf.Abs(fark.g)+Mathf.Abs(fark.b)<0.2f){
            ikincirenk=renkler[ikincirenksec()];
        }
        zemin_material.color=Color.Lerp(zemin_material.color,ikincirenk,0.0003f);
        Camera.main.backgroundColor=Color.Lerp(Camera.main.backgroundColor,ikincirenk,0.00007f);
    }
    int ikincirenksec(){
        int ikincil_renk;
        ikincil_renk=Random.Range(0,renkler.Count);
        while(ikincil_renk==birinci_renk){
        ikincil_renk=Random.Range(0,renkler.Count);
        }
    return ikincil_renk;
    }
}
