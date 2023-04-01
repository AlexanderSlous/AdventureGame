using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObject : MonoBehaviour
{
    public string SceneName;

    //public static PersistentObject Instance;

    // Start is called before the first frame update
    void Awake()
    {
        //Instance = this;
        //DontDestroyOnLoad(gameObject);

        if(SceneManager.GetActiveScene().name != SceneName)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
