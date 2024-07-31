using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditLoader : MonoBehaviour
{
    public Lantern theLastLantern;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneLoader());
    }
    IEnumerator SceneLoader()
    {
        yield return new WaitUntil(() => !theLastLantern.lanternLight2D.gameObject.activeSelf && theLastLantern.isTheFinalLantern);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Scenes/Credits");
    }
}
