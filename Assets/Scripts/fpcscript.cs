using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class fpcscript : MonoBehaviour {

    Vector3 posinicial;
    Quaternion rotacioninicial;
    public GameObject diana;
    public GameObject FPC;
    GameObject cartelmal;
    GameObject cartelbien;
    GameObject cartelbusca;
    SpriteRenderer bueno;
    SpriteRenderer malo;
    SpriteRenderer busca;
    public GameObject sceneController;


    void Start () {
        posinicial = gameObject.transform.position;
        cartelmal = GameObject.FindGameObjectWithTag("mal");
        cartelbien = GameObject.FindGameObjectWithTag("bien");
        cartelbusca = GameObject.FindGameObjectWithTag("start");
        bueno = cartelbien.GetComponent<SpriteRenderer>();
        malo = cartelmal.GetComponent<SpriteRenderer>();
        busca = cartelbusca.GetComponent<SpriteRenderer>();
        StartCoroutine("inicio");


    }



    void OnTriggerEnter(Collider errorcol)
    {
        if (errorcol.gameObject.name == "WIN")
        {
            StartCoroutine("bien");
        }
        else StartCoroutine("mal");
    }


    IEnumerator mal()
    {
       
        malo.enabled = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(Application.loadedLevel);

    }

    IEnumerator bien()
    {
        bueno.enabled = true;
        yield return new WaitForSeconds(2);
        //CONDICION DE SALIR DE ESCENA
        SceneManager.LoadScene("Scenes/Level Selector");
    }

    IEnumerator inicio()
    {

        yield return new WaitForSeconds(2);
        busca.enabled = false;
    }
}

