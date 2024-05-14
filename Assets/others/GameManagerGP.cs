using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagerGP : MonoBehaviour
{
    public GameObject[] playerModels;
    public PlayerWeapons playerWeaponsScript;
    bool CheckToDisplayFailPanelOnce;
    public GameObject RFPSCanvas;
    public float levelHealth;
    public GameObject Player;
    public Slider healthSlider;
    public float healthvalue;
    public GameObject GameCompletePanel;
    public GameObject GamePausedPanel;
    public GameObject GameFailPanel;
    [HideInInspector]
    public float dinocount;
    public float dinotokillinlevels;
    [HideInInspector]
    public float dinotokillsimple;
    public Text dinotext;
    float storemaxhealth;
    public GameObject playerblood;
    public bool sheildvalue;
    float sv;
    public int multiplir;
    public GameObject sheildbtn;
    public GameObject sheildsldr;
    public Image sheildimage;
    public Text weaponname;
    public Text ammotext;
    public GameObject bloodscreen;
    public bool greenkey;
    public bool redkey;
    public bool bluekey;
    public GameObject bluekeyimage;
    public GameObject redkeyimage;
    public GameObject greenkeyimage;
    public Text keystatus;
    public static GameManagerGP instance;

    void OnEnable()
    {
        playerWeaponsScript.firstWeapon = 0;
    }
    public void sheildbutton()
    {
       
        sheildvalue = true;
        sv = 10;
        sheildbtn.SetActive(false);
        sheildsldr.SetActive(true);
        sheildimage.fillAmount = sv / 10f;
    }
    void Start()
    {
        instance = this;
        greenkey = false;
        bluekey = false;
        redkey = false;
        bluekeyimage.SetActive(false);
        redkeyimage.SetActive(false);
        greenkeyimage.SetActive(false);
        keystatus.gameObject.SetActive(false);
        sheildvalue = false;
        sheildbtn.SetActive(true);
        sheildsldr.SetActive(false);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (PlayerPrefs.GetInt("unlocklevel") >= 0 && PlayerPrefs.GetInt("unlocklevel") < 30)
        {
            for (int i = 1; i < 6; i++)
            {
                playerModels[i].GetComponent<WeaponBehavior>().haveWeapon = true;
            }
        }
        dinocount = 0;
        CheckToDisplayFailPanelOnce = true;
        Time.timeScale = 1;
        healthvalue = levelHealth;
        storemaxhealth = levelHealth;
        healthSlider.maxValue = storemaxhealth;
        dinotokillsimple = dinotokillinlevels;
       
    }
    public void Update()
    {
        int ammoleft = playerWeaponsScript.weaponOrder[playerWeaponsScript.currentWeapon].GetComponent<WeaponBehavior>().ammo + playerWeaponsScript.weaponOrder[playerWeaponsScript.currentWeapon].GetComponent<WeaponBehavior>().bulletsLeft- playerWeaponsScript.weaponOrder[playerWeaponsScript.currentWeapon].GetComponent<WeaponBehavior>().bulletsPerClip;
       ammotext.text = ammoleft.ToString();

        if (playerWeaponsScript.currentWeapon == 0)
        {
            GameManagerGP.instance.weaponname.text = "M1911";
        }
        else if (playerWeaponsScript.currentWeapon == 1)
        {
            GameManagerGP.instance.weaponname.text = "Shotgun";
        }
        else if (playerWeaponsScript.currentWeapon == 2)
        {
            GameManagerGP.instance.weaponname.text = "MP5";
        }
        else if (playerWeaponsScript.currentWeapon == 3)
        {
            GameManagerGP.instance.weaponname.text = "AK47";
        }
        else if (playerWeaponsScript.currentWeapon == 4)
        {
            GameManagerGP.instance.weaponname.text = "M4";
        }
        else if (playerWeaponsScript.currentWeapon == 5)
        {
            GameManagerGP.instance.weaponname.text = "Sniper";
        }




        AudioSource[] audioSourceObjects = GameObject.FindObjectsOfType<AudioSource>();
        if (PlayerPrefs.GetInt("Sound", 0) == 0)
        {
            foreach (AudioSource item in audioSourceObjects)
            {
                item.mute = false;
            }
        }
        else if (PlayerPrefs.GetInt("Sound", 0) == 1)
        {
            foreach (AudioSource item in audioSourceObjects)
            {
                item.mute = true;
            }
        }
        if (healthvalue >= storemaxhealth)
        {
            healthvalue = storemaxhealth;
        }
        dinotext.text = dinocount + " / " + dinotokillsimple;
        if (GamePausedPanel.activeInHierarchy == false)
        {
            if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.Escape))
            {
                GamePausedPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if (GamePausedPanel.activeInHierarchy)
        {
            if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.Escape))
            {
                GamePausedPanel.SetActive(false);
                Time.timeScale = 1;
            }
        }
        healthSlider.value = healthvalue;
        if (healthvalue <= 0)
        {
            if (CheckToDisplayFailPanelOnce)
            {
                if (GameCompletePanel.activeInHierarchy == false)
                {
                    StartCoroutine(FailRoutine());
                }
                CheckToDisplayFailPanelOnce = false;
            }
        }
        float newVar = (healthvalue / storemaxhealth) * 100;
        if (dinocount >= dinotokillsimple)
        {
            StartCoroutine(GameCompleteRoutine());
        }

        if (sheildvalue == true && sv > 0)
        {
            sv -= Time.deltaTime * multiplir;
            sheildimage.fillAmount = sv / 10f;
        }
        if (sv <= 0)
        {
            sheildvalue = false;
            sheildbtn.SetActive(true);
            sheildsldr.SetActive(false);
        }
    }
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GP");
    }
    public void ResumeButton()
    {
        GamePausedPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void PauseGameButton()
    {
        GamePausedPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public IEnumerator GameCompleteRoutine()
    {
        RFPSCanvas.SetActive(false);
        AudioSource[] audioSourceObjects = GameObject.FindObjectsOfType<AudioSource>();
        foreach (AudioSource item in audioSourceObjects)
        {
            item.mute = true;
        }
        playerblood.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        GameCompletePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public IEnumerator FailRoutine()
    {
        RFPSCanvas.SetActive(false);
      
        AudioSource[] audioSourceObjects = GameObject.FindObjectsOfType<AudioSource>();
        foreach (AudioSource item in audioSourceObjects)
        {
            item.mute = true;
        }
        playerblood.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        GameFailPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void damagetoPlayer()
    {
        StartCoroutine(showbloodspot());
    }
    public IEnumerator showbloodspot()
    {
        if (GameManagerGP.instance.sheildvalue == true)
        {
            GameManagerGP.instance.healthvalue -= 2;
            bloodscreen.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            bloodscreen.SetActive(false);
        }
        else if (GameManagerGP.instance.sheildvalue == false)
        {
            GameManagerGP.instance.healthvalue -= 10;
            bloodscreen.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            bloodscreen.SetActive(false);
        }
    }
}
