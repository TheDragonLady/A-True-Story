using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Image sr;
    public Color Startcolor;
    public Color Endcolor;
    public float FadeSpeed;
    public float currenttime;
    public float cutoff;
    public bool fadein;
    public bool dofade;
    public List<GameObject> scenes = new List<GameObject>();
    public int currentscene;


    // Start is called before the first frame update
    void Start()
    {        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Startfade();
        }
        

        if(dofade==true)
        {
            Fade();
        }
        
        if(fadein==true &&currenttime>cutoff)
        {
            fadein = false;
            currenttime = 0;

        }
    }
    public void Fade()
    {
        if(fadein==true)
        {
            sr.color = Color.Lerp(Startcolor, Endcolor, Time.deltaTime + (currenttime = currenttime + Time.deltaTime) * FadeSpeed);
            if (currenttime > cutoff)
            {
                NextScene();
            }
        }

        if(fadein==false)
        {
            sr.color = Color.Lerp(Endcolor, Startcolor, Time.deltaTime + (currenttime = currenttime + Time.deltaTime) * FadeSpeed);

        }
      
    }
    public void Startfade()
    {
        dofade = true;
        fadein = true;
        currenttime = 0;
    }
    public void NextScene()
    {
        scenes[currentscene].SetActive(false);
        scenes[currentscene+=1].SetActive(true);
    }
    public void PreScene()
    {
        scenes[currentscene].SetActive(false);
        scenes[currentscene -= 1].SetActive(true);
    }
}
