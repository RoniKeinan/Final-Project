using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class openDoor : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private TextMeshProUGUI codeText;
    string codeTextValue = "";
    public string safeCode;
    public GameObject codePanel;
    private bool isAtDoor=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;
        if (codeTextValue == safeCode)
        {
            anim.SetTrigger("openDoor");
            codePanel.SetActive(false);
        }
        if(codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }
        if (Input.GetKey(KeyCode.E) && isAtDoor == true)
        {
            codePanel.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isAtDoor = true;

        }
    }
    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
    private void OnTriggerExit(Collider other)
    {
        isAtDoor=false;
        codePanel.SetActive(false);
    }
    
}
