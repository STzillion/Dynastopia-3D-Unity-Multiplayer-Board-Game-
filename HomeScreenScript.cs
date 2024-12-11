using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class HomeScreenScript : MonoBehaviour
{

    
    public Button StartButton;
    public Button PlayButtonStartGame;
    public CameraController cameraControllerScript;
    public GameObject CamCharacter;
    public Image GameLogo;
    public GameObject CameraPoint;
    public Animator MenuPanelAnimator;
    public Animator[] GameModeButtonAnimators;
 

    public PostProcessVolume postProcessVolume;
    DepthOfField depthOfField;

    public Button BackButton;

    public Button NormalModeButton;
    public Button CrimeModeButton;
    public Button LowGraphicsButton;
    public Button HighGraphicsButton;
    public Button DayButton;
    public Button NightButton;
    public Button DayAndNightButton;


    public Button HomeScreenButton;

    public bool[] ButtonsBool;
    public bool[] NextButtonBool;
    public int BoolChecker = 0;


    // Start is called before the first frame update

    private void Awake()
    {
        StartButton.onClick.AddListener(StartButtonClicked);
        PlayButtonStartGame.onClick.AddListener(PlayButtonStartGameClicked);
        NormalModeButton.onClick.AddListener(NormalModeButtonClicked);
        CrimeModeButton.onClick.AddListener(CrimeModeButtonClicked);
        LowGraphicsButton.onClick.AddListener(LowGraphicsModeClicked);
        HighGraphicsButton.onClick .AddListener(HighGraphicsModeClicked);
        HomeScreenButton.onClick.AddListener(HomeScreenButtonClicked);
        BackButton.onClick.AddListener(BackButtonClicked);
        DayButton.onClick.AddListener(DayButtonClicked);
        NightButton.onClick.AddListener(NightButtonClicked);
        DayAndNightButton.onClick.AddListener(DayAndNightButtonClicked);
    }
    public void StartButtonClicked()
    {
        StartCoroutine(StartButtonEnumerator());
    }

    public void PlayButtonStartGameClicked()
    {
        StartCoroutine(PlayButtonStartGameEnumerator());
    }

    public void BackButtonClicked()
    {
       StartCoroutine(BackButtonClickedEnumerator());
    }

  

    public void NormalModeButtonClicked()
    {
        ButtonsBool[0] = true;
        ButtonsBool[1] = true;

    StartCoroutine(NormalButtonEnumerator());
       // BoolChecker = 0;
    }

    public void CrimeModeButtonClicked()
    {
        ButtonsBool[0] = true;
        ButtonsBool[1] = true;
        StartCoroutine(CrimeButtonEnumerator());
        //BoolChecker = 1;
    }

    public void LowGraphicsModeClicked()
    {
        ButtonsBool[2] = true;
        ButtonsBool[3] = true;
        StartCoroutine(LowGraphicsButtonEnumerator());
       // BoolChecker = 2;
    }

    public void HighGraphicsModeClicked()
    {
        ButtonsBool[2] = true;
        ButtonsBool[3] = true;
        StartCoroutine(HighGraphicsButtonEnumerator());
        //BoolChecker = 3;
    }

    public void DayButtonClicked()
    {
        ButtonsBool[4] = true;
        ButtonsBool[5] = true;
        ButtonsBool[6] = true;
        InbetweenGameManager.Instance?.LoadGame();

       // BoolChecker = 4;
    }

    public void NightButtonClicked()
    {
        ButtonsBool[4] = true;
        ButtonsBool[5] = true;
        ButtonsBool[6] = true;
        InbetweenGameManager.Instance?.LoadGame();
        // BoolChecker = 5;
    }

    public void DayAndNightButtonClicked()
    {
        ButtonsBool[4] = true;
        ButtonsBool[5] = true;
        ButtonsBool[6] = true;
        InbetweenGameManager.Instance?.LoadGame();
        // BoolChecker = 6;
    }



    public void HomeScreenButtonClicked()
    {
        
       StartCoroutine (HomeScreenButtonEnumerator()); 
    }




  

    public IEnumerator HomeScreenButtonEnumerator()
    {
        BackButton.gameObject.SetActive(false);
        HomeScreenButton.gameObject.SetActive(false);

        for (int i = 0; i < ButtonsBool.Length; i++)
        {
            if (NextButtonBool[i] == true)
            {

               
                GameModeButtonAnimators[i].SetBool("IsPlayButtonClicked", false);
                GameModeButtonAnimators[i].SetBool("IsBackToMenuClicked", true);
                GameModeButtonAnimators[i].CrossFade("GameModeButtonClosingAnim", 0.01f);

                yield return new WaitForSeconds(0.1f);

                GameModeButtonAnimators[i].SetBool("IsPlayButtonClicked", false);
                GameModeButtonAnimators[i].SetBool("IsBackToMenuClicked", false);
                 NextButtonBool[i] = false;

                // ButtonsBoolChecker++;
            }
        }
        StartCoroutine(normalScreeUI());
        yield return new WaitForSeconds(0.5f);


        MenuPanelAnimator.SetBool("PlayClicked", true);
        MenuPanelAnimator.CrossFade("MenuToScreenAnimation", 0.1f);
        GameLogo.gameObject.SetActive(true);


    }
    public IEnumerator LowGraphicsButtonEnumerator()
    {
        yield return new WaitForSeconds(0f);
        BackButton.gameObject.SetActive(false);
        HomeScreenButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < ButtonsBool.Length; i++)
        {
            if (ButtonsBool[i] == true)
            {

                ButtonsBool[i] = false;
                NextButtonBool[i] = false;
                GameModeButtonAnimators[i].SetBool("IsPlayButtonClicked", false);
                GameModeButtonAnimators[i].SetBool("IsBackToMenuClicked", true);
                GameModeButtonAnimators[i].CrossFade("GameModeButtonClosingAnim", 0.01f);

                yield return new WaitForSeconds(0.1f);

                GameModeButtonAnimators[i].SetBool("IsPlayButtonClicked", false);
                GameModeButtonAnimators[i].SetBool("IsBackToMenuClicked", false);

                // ButtonsBoolChecker++;
            }
        }

        yield return new WaitForSeconds(0.5f);


        GameModeButtonAnimators[4].SetBool("IsPlayButtonClicked", true);
        GameModeButtonAnimators[4].CrossFade("GameModesButtonOpening", 0.01f);
        NextButtonBool[4] = true;
        BoolChecker = 5;

        GameModeButtonAnimators[5].SetBool("IsPlayButtonClicked", true);
        GameModeButtonAnimators[5].CrossFade("GameModesButtonOpening", 0.01f);
        NextButtonBool[5] = true;
        BoolChecker = 6;

        GameModeButtonAnimators[6].SetBool("IsPlayButtonClicked", true);
        GameModeButtonAnimators[6].CrossFade("GameModesButtonOpening", 0.01f);
        NextButtonBool[6] = true;
        BoolChecker = 7;






        BackButton.gameObject.SetActive(true);
        HomeScreenButton.gameObject.SetActive(true);



    }


    public IEnumerator HighGraphicsButtonEnumerator()
    {
        yield return new WaitForSeconds(0f);
        BackButton.gameObject.SetActive(false);
        HomeScreenButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < ButtonsBool.Length; i++)
        {
            if (ButtonsBool[i] == true)
            {

                ButtonsBool[i] = false;
                NextButtonBool[i] = false;
                GameModeButtonAnimators[i].SetBool("IsPlayButtonClicked", false);
                GameModeButtonAnimators[i].SetBool("IsBackToMenuClicked", true);
                GameModeButtonAnimators[i].CrossFade("GameModeButtonClosingAnim", 0.01f);

                yield return new WaitForSeconds(0.1f);

                GameModeButtonAnimators[i].SetBool("IsPlayButtonClicked", false);
                GameModeButtonAnimators[i].SetBool("IsBackToMenuClicked", false);

                // ButtonsBoolChecker++;
            }
        }

        yield return new WaitForSeconds(0.5f);


        GameModeButtonAnimators[4].SetBool("IsPlayButtonClicked", true);
        GameModeButtonAnimators[4].CrossFade("GameModesButtonOpening", 0.01f);
        NextButtonBool[4] = true;
        BoolChecker = 5;

        GameModeButtonAnimators[5].SetBool("IsPlayButtonClicked", true);
        GameModeButtonAnimators[5].CrossFade("GameModesButtonOpening", 0.01f);
        NextButtonBool[5] = true;
        BoolChecker = 6;

        GameModeButtonAnimators[6].SetBool("IsPlayButtonClicked", true);
        GameModeButtonAnimators[6].CrossFade("GameModesButtonOpening", 0.01f);
        NextButtonBool[6] = true;
        BoolChecker = 7;






        BackButton.gameObject.SetActive(true);
        HomeScreenButton.gameObject.SetActive(true);
    }

    public IEnumerator NormalButtonEnumerator()
    {
        BackButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < ButtonsBool.Length; i++)
        {
            if (ButtonsBool[i] == true)
            {

                NextButtonBool[i] = false;
                ButtonsBool[i] = false;
                GameModeButtonAnimators[i].SetBool("IsPlayButtonClicked", false);
                GameModeButtonAnimators[i].SetBool("IsBackToMenuClicked", true);
                GameModeButtonAnimators[i].CrossFade("GameModeButtonClosingAnim", 0.01f);

                yield return new WaitForSeconds(0.1f);

                GameModeButtonAnimators[i].SetBool("IsPlayButtonClicked", false);
                GameModeButtonAnimators[i].SetBool("IsBackToMenuClicked", false);

                // ButtonsBoolChecker++;
            }
        }

        yield return new WaitForSeconds(0.5f);

       
       GameModeButtonAnimators[2].SetBool("IsPlayButtonClicked", true);
       GameModeButtonAnimators[2].CrossFade("GameModesButtonOpening", 0.01f);
        NextButtonBool[2] = true;
        BoolChecker = 3;

       GameModeButtonAnimators[3].SetBool("IsPlayButtonClicked", true);
       GameModeButtonAnimators[3].CrossFade("GameModesButtonOpening", 0.01f);
        NextButtonBool[3] = true;
        BoolChecker = 4;




        BackButton.gameObject.SetActive(true);
    }

    public IEnumerator CrimeButtonEnumerator()
    {
        BackButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < ButtonsBool.Length; i++)
        {
            if (ButtonsBool[i] == true)
            {

                NextButtonBool[i] = false;
                ButtonsBool[i] = false;
                GameModeButtonAnimators[i].SetBool("IsPlayButtonClicked", false);
                GameModeButtonAnimators[i].SetBool("IsBackToMenuClicked", true);
                GameModeButtonAnimators[i].CrossFade("GameModeButtonClosingAnim", 0.01f);

                yield return new WaitForSeconds(0.1f);

                GameModeButtonAnimators[i].SetBool("IsPlayButtonClicked", false);
                GameModeButtonAnimators[i].SetBool("IsBackToMenuClicked", false);

                // ButtonsBoolChecker++;
            }
        }

        yield return new WaitForSeconds(0.5f);


        GameModeButtonAnimators[2].SetBool("IsPlayButtonClicked", true);
        GameModeButtonAnimators[2].CrossFade("GameModesButtonOpening", 0.01f);
        NextButtonBool[2] = true;
        BoolChecker = 3;

        GameModeButtonAnimators[3].SetBool("IsPlayButtonClicked", true);
        GameModeButtonAnimators[3].CrossFade("GameModesButtonOpening", 0.01f);
        NextButtonBool[3] = true;
        BoolChecker = 4;

        BackButton.gameObject.SetActive(true);
    }



    public IEnumerator StartButtonEnumerator()
    {
        yield return new WaitForSeconds(0);
        cameraControllerScript.target = CameraPoint.transform;
        cameraControllerScript.distance = 0.6f;
        cameraControllerScript.height = 0f;
        cameraControllerScript.offset = -0.25f;
        cameraControllerScript.smoothSpeed = 5f;
        MenuPanelAnimator.SetBool("PlayClicked", true);
        MenuPanelAnimator.CrossFade("MenuToScreenAnimation", 0.1f);

      //  GameLogo.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);
        
    }

    public IEnumerator BackButtonClickedEnumerator()
    {
        BackButton.gameObject.SetActive(false);
        HomeScreenButton.gameObject.SetActive(false);

       if(BoolChecker == 1 || BoolChecker == 2)
       {
            GameModeButtonAnimators[0].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[0].SetBool("IsBackToMenuClicked", true);
            GameModeButtonAnimators[0].CrossFade("GameModeButtonClosingAnim", 0.01f);

            yield return new WaitForSeconds(0.1f);

            GameModeButtonAnimators[0].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[0].SetBool("IsBackToMenuClicked", false);


            GameModeButtonAnimators[1].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[1].SetBool("IsBackToMenuClicked", true);
            GameModeButtonAnimators[1].CrossFade("GameModeButtonClosingAnim", 0.01f);

            yield return new WaitForSeconds(0.1f);

            GameModeButtonAnimators[1].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[1].SetBool("IsBackToMenuClicked", false);

            StartCoroutine(normalScreeUI());
            yield return new WaitForSeconds(0.5f);


            MenuPanelAnimator.SetBool("PlayClicked", true);
            MenuPanelAnimator.CrossFade("MenuToScreenAnimation", 0.1f);
            GameLogo.gameObject.SetActive(true);


        }
       else if (BoolChecker == 3 || BoolChecker == 4)
       {
            GameModeButtonAnimators[2].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[2].SetBool("IsBackToMenuClicked", true);
            GameModeButtonAnimators[2].CrossFade("GameModeButtonClosingAnim", 0.01f);

            yield return new WaitForSeconds(0.1f);

            GameModeButtonAnimators[2].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[2].SetBool("IsBackToMenuClicked", false);


            GameModeButtonAnimators[3].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[3].SetBool("IsBackToMenuClicked", true);
            GameModeButtonAnimators[3].CrossFade("GameModeButtonClosingAnim", 0.01f);

            yield return new WaitForSeconds(0.1f);

            GameModeButtonAnimators[3].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[3].SetBool("IsBackToMenuClicked", false);


            yield return new WaitForSeconds(0.5f);


            GameModeButtonAnimators[0].SetBool("IsPlayButtonClicked", true);
            GameModeButtonAnimators[0].CrossFade("GameModesButtonOpening", 0.01f);
            NextButtonBool[0] = true;
            BoolChecker = 2;

            GameModeButtonAnimators[1].SetBool("IsPlayButtonClicked", true);
            GameModeButtonAnimators[1].CrossFade("GameModesButtonOpening", 0.01f);
            NextButtonBool[1] = true;
            BoolChecker = 2;

            BackButton.gameObject.SetActive(true);
            HomeScreenButton.gameObject.SetActive(true);
       }
        else if (BoolChecker == 5 || BoolChecker == 6 || BoolChecker == 7)
        {
            GameModeButtonAnimators[4].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[4].SetBool("IsBackToMenuClicked", true);
            GameModeButtonAnimators[4].CrossFade("GameModeButtonClosingAnim", 0.01f);

            yield return new WaitForSeconds(0.1f);

            GameModeButtonAnimators[4].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[4].SetBool("IsBackToMenuClicked", false);


            GameModeButtonAnimators[5].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[5].SetBool("IsBackToMenuClicked", true);
            GameModeButtonAnimators[5].CrossFade("GameModeButtonClosingAnim", 0.01f);

            yield return new WaitForSeconds(0.1f);

            GameModeButtonAnimators[5].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[5].SetBool("IsBackToMenuClicked", false);


            GameModeButtonAnimators[6].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[6].SetBool("IsBackToMenuClicked", true);
            GameModeButtonAnimators[6].CrossFade("GameModeButtonClosingAnim", 0.01f);

            yield return new WaitForSeconds(0.1f);

            GameModeButtonAnimators[6].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[6].SetBool("IsBackToMenuClicked", false);


            yield return new WaitForSeconds(0.5f);


            GameModeButtonAnimators[2].SetBool("IsPlayButtonClicked", true);
            GameModeButtonAnimators[2].CrossFade("GameModesButtonOpening", 0.01f);
            NextButtonBool[2] = true;
            BoolChecker = 3;

            GameModeButtonAnimators[3].SetBool("IsPlayButtonClicked", true);
            GameModeButtonAnimators[3].CrossFade("GameModesButtonOpening", 0.01f);
            NextButtonBool[3] = true;
            BoolChecker = 4;

            BackButton.gameObject.SetActive(true);
            HomeScreenButton.gameObject.SetActive(true);



        }
        else
        {
            GameModeButtonAnimators[0].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[0].SetBool("IsBackToMenuClicked", true);
            GameModeButtonAnimators[0].CrossFade("GameModeButtonClosingAnim", 0.01f);

            yield return new WaitForSeconds(0.1f);

            GameModeButtonAnimators[0].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[0].SetBool("IsBackToMenuClicked", false);


            GameModeButtonAnimators[1].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[1].SetBool("IsBackToMenuClicked", true);
            GameModeButtonAnimators[1].CrossFade("GameModeButtonClosingAnim", 0.01f);

            yield return new WaitForSeconds(0.1f);

            GameModeButtonAnimators[1].SetBool("IsPlayButtonClicked", false);
            GameModeButtonAnimators[1].SetBool("IsBackToMenuClicked", false);

            StartCoroutine(normalScreeUI());
            yield return new WaitForSeconds(0.5f);


            MenuPanelAnimator.SetBool("PlayClicked", true);
            MenuPanelAnimator.CrossFade("MenuToScreenAnimation", 0.1f);
            GameLogo.gameObject.SetActive(true);
        }

       /* yield return new WaitForSeconds(0.5f);
        StartCoroutine(normalScreeUI());

       

        MenuPanelAnimator.SetBool("PlayClicked", true);
        MenuPanelAnimator.CrossFade("MenuToScreenAnimation", 0.1f);
        GameLogo.gameObject.SetActive(true);
        */
    }

    public IEnumerator PlayButtonStartGameEnumerator()
    {
        MenuPanelAnimator.SetBool("PlayClicked", false);
        MenuPanelAnimator.SetBool("PlayTwoClicked", true);
        MenuPanelAnimator.CrossFade("MenuCloseAnim", 0.1f);

        yield return new WaitForSeconds(0.1f);

        MenuPanelAnimator.SetBool("PlayClicked", false);
        MenuPanelAnimator.SetBool("PlayTwoClicked", false);

        StartCoroutine(BlurScreenUi());
        GameLogo.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

       
            GameModeButtonAnimators[0].SetBool("IsPlayButtonClicked", true);
            GameModeButtonAnimators[0].CrossFade("GameModesButtonOpening", 0.01f);
            NextButtonBool[0] = true;

        GameModeButtonAnimators[1].SetBool("IsPlayButtonClicked", true);
        GameModeButtonAnimators[1].CrossFade("GameModesButtonOpening", 0.01f);
        NextButtonBool[1] = true;


        BackButton.gameObject.SetActive(true);
    }

    public IEnumerator BlurScreenUi()
    {
        if (postProcessVolume.profile.TryGetSettings(out depthOfField))
        {
            float elapsedTime = 0f;
            float startAperture = depthOfField.aperture.value;
            float startFocalLength = depthOfField.focalLength.value;
            float startfocusDistance = depthOfField.focusDistance.value;

            float targetAperture = 0.1f;
            float targetFocalLength = 100f;
            float targetFocusDistance = 0f;
            float transitionDuration = 0.6f;


            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / transitionDuration);

                // Interpolate between the current values and the target values over time
                depthOfField.aperture.value = Mathf.Lerp(startAperture, targetAperture, t);
                depthOfField.focalLength.value = Mathf.Lerp(startFocalLength, targetFocalLength, t);
                depthOfField.focusDistance.value = Mathf.Lerp(startfocusDistance, targetFocusDistance, t);

                yield return null;
            }

            // Ensure the final values are exactly the target values
            depthOfField.aperture.value = targetAperture;
            depthOfField.focalLength.value = targetFocalLength;
        }
    }

    public IEnumerator normalScreeUI()
    {
        if (postProcessVolume.profile.TryGetSettings(out depthOfField))
        {
            float elapsedTime = 0f;
            float startAperture = depthOfField.aperture.value;
            float startFocalLength = depthOfField.focalLength.value;
            float startfocusDistance = depthOfField.focusDistance.value;

            float targetAperture = 4.4f;
            float targetFocalLength = 25f;
            float targetFocusDistance = 0.45f;
            float transitionDuration = 0.6f;


            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / transitionDuration);

                // Interpolate between the current values and the target values over time
                depthOfField.aperture.value = Mathf.Lerp(startAperture, targetAperture, t);
                depthOfField.focalLength.value = Mathf.Lerp(startFocalLength, targetFocalLength, t);
                depthOfField.focusDistance.value = Mathf.Lerp(startfocusDistance, targetFocusDistance, t);

                yield return null;
            }

            // Ensure the final values are exactly the target values
            depthOfField.aperture.value = targetAperture;
            depthOfField.focalLength.value = targetFocalLength;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Start()
    {
        BackButton.gameObject.SetActive(false);
        HomeScreenButton.gameObject.SetActive(false);
       
    }
}




