using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public bool disableControls;
    [SerializeField] private Button inspect;
    [SerializeField] private Button talk;
    [SerializeField] private Button travel;
    [SerializeField] private GameObject interactable;
    public bool active;
    List<Button> buttons = new List<Button>();
    void Start()
    {
        inspect.onClick.AddListener(Inspect);
        talk.onClick.AddListener(Talk);
        travel.onClick.AddListener(Travel);
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            if (disableControls) return;
            if (active)
            {
                CloseMenu();
                active = false;
                return;
            } 
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider == null) return;
            switch (hit.collider.tag)
            {
                case "Item":
                    AppendButtons(inspect);
                    break;
                case "Character":
                    AppendButtons(inspect, talk);
                    break;
                case "Drivable":
                    AppendButtons(inspect, travel);
                    break;
                default:
                    return;
            }
            interactable = hit.collider.gameObject;
            if (!interactable.GetComponent<Interactable>().Check(transform.position)) return;
            Vector3 initPosition = Input.mousePosition + new Vector3(buttons[0].GetComponent<RectTransform>().sizeDelta.x / 2, buttons[0].GetComponent<RectTransform>().sizeDelta.y / 2, 0);
            for (int i = 0; i < buttons.Count; i++)
            {
                RectTransform button_rt = buttons[i].GetComponent<RectTransform>();
                button_rt.position = initPosition + new Vector3(0, -button_rt.sizeDelta.y, 0);
                initPosition = button_rt.position;
                buttons[i].gameObject.SetActive(true);
            }
            active = true;
        }
        
        if (GetComponent<PlayerMovement>().movement != Vector2.zero)
        {
            CloseMenu();
        }
    }

    void Inspect () {
        Debug.Log("You have clicked the button!");
    }

    void Talk () {
        Debug.Log("You have clicked the button!");
    }

    void Travel () {
        Debug.Log("You have clicked the button!");
    }

    void AppendButtons(params Button[] values) {
        buttons.Clear();
        foreach (Button button in values)
        {
            buttons.Add(button);
        }
    }

    public void CloseMenu() {
        if (buttons.Count < 1) return;
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
        buttons.Clear();
        active = false;
    }
}
