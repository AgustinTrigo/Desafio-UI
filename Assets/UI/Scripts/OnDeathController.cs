using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnDeathController : MonoBehaviour
{
    //[SerializeField] private InputField tryAgainButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickTryAgainButton()
    {
        SceneManager.LoadScene("MainScene");
    }

}
