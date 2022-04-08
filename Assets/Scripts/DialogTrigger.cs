using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialogue;
    public bool isInRange;

    private Text InteractUI;

    private string infoTexte = "PRESS    E   TO    INTERACT";

    void Awake()
    {
        InteractUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();

    }
    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialog();
        }
        if(!DialogManager.instance.GetDialogIsOpen())
        {
            infoTexte = "PRESS    E   TO    INTERACT";
            InteractUI.text = infoTexte;
        }
        else
        {
            infoTexte = "PRESS    ENTER   TO    INTERACT";
            InteractUI.text = infoTexte;
        }

    }

    void TriggerDialog()
    {
        DialogManager.instance.StartDialog(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            InteractUI.text = infoTexte;
            InteractUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {        
            InteractUI.enabled = false;
            isInRange = false;
            DialogManager.instance.EndDialog();
        }
    }
}
