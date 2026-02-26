using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    Vector3 yon;
    [SerializeField]
    float hiz;

    public zemin_olusturma zemin_Olusturr;

    public static bool dustuMu=true;

    public float hizlanma_zorlugu;

    float skor=0f, artisMiktari=1f;
    [SerializeField]
    Text skorText;

    int eniyiskor;
    [SerializeField]
    Text eniyiskorText, bestscoreText,scoreText;

    public GameObject restartgamePanel, playgamePanel;
    void Start()
    {
        
        bestscoreText.text="Best Score: "+PlayerPrefs.GetInt("eniyiskor").ToString();
        if(restartgame.isRestart==true){
            playgamePanel.SetActive(false);
            dustuMu=false;
            skorText.gameObject.SetActive(true);
            eniyiskorText.gameObject.SetActive(true);
        }

        yon=Vector3.left;
        eniyiskor=PlayerPrefs.GetInt("eniyiskor");
        eniyiskorText.text="Best Score:"+eniyiskor.ToString();
    }
    public void StartGame(){
        dustuMu=false;
        
        playgamePanel.SetActive(false);
        skorText.gameObject.SetActive(true);
        eniyiskorText.gameObject.SetActive(true);
    }

    void Update()
    {   
        if(dustuMu)
        {
            return;
        }
        
        hareket();
        olmek();
    }
    void olmek(){
        if(transform.position.y<0f)
        {
            dustuMu = true;
            restartgamePanel.SetActive(true);
            Destroy(gameObject,2f);
            scoreText.text="Score: "+((int)skor).ToString();
            skorText.gameObject.SetActive(false);
            eniyiskorText.gameObject.SetActive(false);
            if(eniyiskor<skor){
                eniyiskor=(int)skor;
                PlayerPrefs.SetInt("eniyiskor",eniyiskor);
                 PlayerPrefs.Save();
            }
        }
    }
    void hareket(){
        if(Input.GetMouseButtonDown(0)){
        if(yon.z==0){
        yon=Vector3.back;
        }
        else{
        yon=Vector3.left;
        }
        }
    }
    private void FixedUpdate() {
        if(dustuMu){
            return;
        }
        Vector3 hareket=yon*hiz*Time.deltaTime;

        transform.position+=hareket;

        hiz+=hizlanma_zorlugu*Time.deltaTime;

        skor+=artisMiktari*hiz*Time.deltaTime;

        skorText.text = "Score: "+((int)skor).ToString();

    }
    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.CompareTag("zemin")){
            StartCoroutine(yoket(collision.gameObject));
            zemin_Olusturr.zemin_Olustur();

        }
        
    }
    IEnumerator yoket(GameObject obje){
        yield return new WaitForSeconds(0.3f);
        obje.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1f);
        Destroy(obje);
    }
}
