using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ads : MonoBehaviour {
    //Class does 2 main jobs: 1) Check what data is available and decide what ads to show. 2) Show ads one by one using a timer.
    //////////////////////////////////////////////////////////////////////////// FIELDS ///////////////////////////////////////////////////////////////////////
    public Texture [] genericAds;   //(textures for generic ads)
    public Texture coffeeAd;        //|(textures for targeted ads)
    public Texture cannabisAd;      //|
    public Texture tobaccoAd;       //|
    public Texture northFaceAd;     //|
    public Texture pumaAd;          //|
    public Texture alcoholAd;       //|--- new targeted ads starting from here
    public Texture nikeAd;          //|
    public Texture adidasAd;        //|
    public Texture underArmourAd;   //|
    public Texture skechersAd;      //|
    public Texture reebokAd;        //|
    
    public UI_Handler ui_handler;
    public RawImage[] allImageObjects; //RawImage Component r
    public AudioSource adsSound;

    private GameObject[] imageObjectGOs; //references to the GameObjects holding the RawImage components (to hide / show)

    public GameObject endingPrompt;

    float timeLeft = 0.6f;
    float origTimeLeft;
    bool timerStarted = false;
    bool done = false;
    int lastActivatedAd = 0;

    

    //////////////////////////////////////////////////////////////////////////// START ///////////////////////////////////////////////////////////////////////
    void Start()
    {
        origTimeLeft = timeLeft;
        timeLeft = timeLeft * 3;
        imageObjectGOs = new GameObject[allImageObjects.Length];

        ui_handler.dataTable = ui_handler.gimmeDatabase();

        //check what data is available for targeted ads
        ArrayList availableData = new ArrayList();
        if (((string)ui_handler.dataTable["Drugs_consumed"]).Contains("Caffeine")) availableData.Add((Texture)coffeeAd);
        if (((string)ui_handler.dataTable["Drugs_consumed"]).Contains("Cannabis")) availableData.Add((Texture)cannabisAd);
        if (((string)ui_handler.dataTable["Drugs_consumed"]).Contains("Tobacco")) availableData.Add((Texture)tobaccoAd);
        if (((string)ui_handler.dataTable["Drugs_consumed"]).Contains("Alcohol")) availableData.Add((Texture)alcoholAd);
        if (((string)ui_handler.dataTable["Favorite_Sportsbrands"]).Contains("Northface")) availableData.Add((Texture)northFaceAd);
        if (((string)ui_handler.dataTable["Favorite_Sportsbrands"]).Contains("Puma")) availableData.Add((Texture)pumaAd);
        if (((string)ui_handler.dataTable["Favorite_Sportsbrands"]).Contains("Nike")) availableData.Add((Texture)nikeAd);
        if (((string)ui_handler.dataTable["Favorite_Sportsbrands"]).Contains("Adidas")) availableData.Add((Texture)adidasAd);
        if (((string)ui_handler.dataTable["Favorite_Sportsbrands"]).Contains("Under Armour")) availableData.Add((Texture)underArmourAd);
        if (((string)ui_handler.dataTable["Favorite_Sportsbrands"]).Contains("Skechers")) availableData.Add((Texture)skechersAd);
        if (((string)ui_handler.dataTable["Favorite_Sportsbrands"]).Contains("Reebok")) availableData.Add((Texture)reebokAd);

        //creat boolean array to see which ads should be targeted
        bool[] replaceWithTargetedAd = new bool[allImageObjects.Length];

        if (availableData.Count > 0)
        {
            //calculate how many targeted ads there should be in total
            int numberOfAdsToTarget = mapNumber(availableData.Count, 1, 11, (int)allImageObjects.Length/6, (int)((allImageObjects.Length / 5)*4));

            int amountOfIndexesSet = 0;
            //randomly assign indexes of the random ads (so they are spread equally throughout the panels)
            while (amountOfIndexesSet < numberOfAdsToTarget)
            {
                int randomVal = Random.Range((int)0, (int)replaceWithTargetedAd.Length);
                if (!replaceWithTargetedAd[randomVal])
                {
                    replaceWithTargetedAd[randomVal] = true;
                    amountOfIndexesSet++;
                }
            }
        }
        
        for (int i = 0; i < allImageObjects.Length; i++)
        {
            //load random image from the generic Ads pool, assign to current RawImage
            if (replaceWithTargetedAd[i])
            {
                // -> targeted
                allImageObjects[i].texture = (Texture)availableData[Random.Range(0, availableData.Count - 1)];
            }
            else {
                // -> generic
                allImageObjects[i].texture = genericAds[(int)(Random.Range(0, genericAds.Length - 1))];
            }
            
            //correct scale, so it has correct aspect ratio and it's scaled down
            allImageObjects[i].SetNativeSize();
            int w = (int)(allImageObjects[i].rectTransform.rect.width / 5);
            int h = (int)(allImageObjects[i].rectTransform.rect.height / 5);
            allImageObjects[i].rectTransform.sizeDelta = new Vector2(w, h);
            //asign GameObjects for each component
            imageObjectGOs[i] = allImageObjects[i].gameObject;
        }

        //shuffle Array, so images are loaded in random order
        shuffleArray(imageObjectGOs);

        for (int i = 0; i < imageObjectGOs.Length; i++)
        {
            //deactivate all ads
            imageObjectGOs[i].SetActive(false);
        }

        startTimer();
    }

    //source: https://forum.unity.com/threads/randomize-array-in-c.86871/
    void shuffleArray(GameObject[] orderedGOs)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < orderedGOs.Length; t++)
        {
            GameObject tmp = orderedGOs[t];
            int r = Random.Range(t, orderedGOs.Length);
            orderedGOs[t] = orderedGOs[r];
            orderedGOs[r] = tmp;
        }
    }

    //source: https://stackoverflow.com/questions/5731863/mapping-a-numeric-range-onto-another
    private int mapNumber(int var, int numA, int numB, int numC, int numD) { 
        return (int)((var-numA)/(numB-numA) * (numD-numC) + numC);
    }

    //////////////////////////////////////////////////////////////////////////// UPDATE ///////////////////////////////////////////////////////////////////////
    //update: handles timer and popping up of ads
    void Update()
    {
        if (timerStarted && !done)
        {
            timeLeft -= Time.deltaTime;

            //timer expired
            if (timeLeft < 0)
            {
                imageObjectGOs[lastActivatedAd].SetActive(true);
                lastActivatedAd++;
                //reset timer
                timeLeft = origTimeLeft;
                if (lastActivatedAd == imageObjectGOs.Length - 1)
                {
                    done = true;
                    Debug.Log("DONE DISPLAYING ADS");
                    endingPrompt.SetActive(true);
                }
            }
        }
        if (lastActivatedAd > 5) if (!adsSound.isPlaying) adsSound.Play();
    }

    //////////////////////////////////////////////// startTimer: Starts loading Ads
    public void startTimer() {
        timerStarted = true;
    }

}
