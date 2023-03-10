using UnityEngine;
using UnityEngine.EventSystems;
public class UpgradeMenu : MonoBehaviour
{
    public GameObject firstbutton;
    public GameObject upgradeMenu;
    // Start is called before the first frame update
    void Start()
    {
        //upgradeMenu.SetActive(false);
    }
    public void Activate()
    {
        upgradeMenu.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(firstbutton);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
