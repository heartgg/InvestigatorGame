using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public bool visible = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.GetComponentInChildren<Button>().onClick.AddListener(delegate{Display(false);});
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) Display(!visible);
    }
    
    void Display (bool enable) {
        visible = enable;
        panel.SetActive(visible);
        GetComponent<PlayerMovement>().disableControls = visible;
        GetComponent<Interaction>().disableControls = visible;
        GetComponent<Interaction>().CloseMenu();
    }
}
