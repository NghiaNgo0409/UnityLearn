using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] int sceneLoadIndex;
    [SerializeField] string areaTransitionName;
    [SerializeField] float waitTimeLoadScene;
    bool isLoadedScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isLoadedScene)
        {
            waitTimeLoadScene -= Time.deltaTime;
            if(waitTimeLoadScene <= 0)
            {
                SceneManager.LoadScene(sceneLoadIndex);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            isLoadedScene = true;
            UIFade.instance.FadeToBlack();
            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
