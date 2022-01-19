using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonStopBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static NonStopBGM instance = null;
    public static NonStopBGM Instance;
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else{
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
