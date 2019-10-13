using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public SpriteRenderer sr;
    public Color Startcolor;
    public Color Endcolor;
    public float FadeSpeed;
    public float currenttime;
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
        
        if(fadein==true &&currenttime>100)
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
            if (currenttime > 100)
            {
                ChangeScene();
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
    public void ChangeScene()
    {
        scenes[currentscene].SetActive(false);
        scenes[currentscene+=1].SetActive(true);
    }

}
