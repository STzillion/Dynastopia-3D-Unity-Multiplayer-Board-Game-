using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using static GameManager.Entity;
using System.Security.Cryptography;
using UnityEngine.Rendering.PostProcessing;
using static GameManager;
using System.Diagnostics.Contracts;



public class PlayerSelectionScreen : MonoBehaviour
{
    public GameManager GameManagerScript;
    public GameObject[] UIPanel;
    public GameObject[] SelectedCharacters;
    public GameObject[] SelectedCharactersOne;
    public GameObject[] SelectedCharactersTwo;
    public GameObject[] SelectedCharactersThree;
    public GameObject[] SelectedCharactersFour;
    public GameObject[] SelectedCharactersFive;

    public GameObject[] SelectedPlayerStone;



    public Button[] previousButtons;
    public Button[] nextButtons;

    public bool[] characterSelected;

    public bool newPlayer;

  


    public int selectedCharactersCount = 0;
    public int selectedCharactersCountOne = 0;
    public int selectedCharactersCountTwo = 0;
    public int selectedCharactersCountThree = 0;
    public int selectedCharactersCountFour = 0;
    public int selectedCharactersCountFive = 0;


    public Button addPlayerButton;
    public Button removePlayerButton;
    public Button allReady;
    public Button KeyboardButton;

    public Button[] backButtonsCPUorHuman;
    public Button[] infoButtons;
    public Button[] SelectPlayerButtons;
    public Button[] CPUPlayerSelect;
    public Button[] HumanPlayerSelect;

    public TextMeshProUGUI[] PlayerTypeTexts;
    public TMP_InputField[] PlayerInputNameFields;

    public Animator[] CPUorHumanAnims;
    public Animator KeyBoardAnimator;
    public int CPUorHumanAnimCount = 0;

    public bool[] isPlayerActive;
    public bool[] selectButtonsClicked;

    public int addedTolist = 0;

    public bool startGameClicked;

    




    private int maxPlayers = 6;
    public int currentPlayerCount = 0;
    void Start()
    {
        characterSelected = new bool[SelectedCharacters.Length];
        isPlayerActive = new bool[6];
        selectButtonsClicked = new bool[6];

        
        isPlayerActive[2] = true;
        isPlayerActive[3] = true;

        for (int i = 0; i < UIPanel.Length; i++)
        {
            UIPanel[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < SelectPlayerButtons.Length;i++)
        {
            SelectPlayerButtons[i].gameObject.SetActive(false);
        }




        for (int i = 0;i < infoButtons.Length;i++)
        {
            infoButtons[i].gameObject.SetActive(false);
        }


        for(int i = 0; i < nextButtons.Length; i++)
        {
            nextButtons[i].gameObject.SetActive(false);
        }


        for (int i = 0; i < previousButtons.Length; i++)
        {
            previousButtons[i].gameObject.SetActive(false);
        }

        for (int i = 1; i < SelectedCharacters.Length; i++)
        {
            SelectedCharacters[i].gameObject.SetActive(false);
            SelectedCharactersOne[i].gameObject.SetActive(false);
            SelectedCharactersTwo[i].gameObject.SetActive(false);
            SelectedCharactersThree[i].gameObject.SetActive(false);
            SelectedCharactersFour[i].gameObject.SetActive(false);
            SelectedCharactersFive[i].gameObject.SetActive(false);
        }

        for(int i = 0 ; i < SelectedPlayerStone.Length ; i++)
        {
            SelectedPlayerStone[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < CPUPlayerSelect.Length; i++)
        {
            CPUPlayerSelect[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < HumanPlayerSelect.Length; i++)
        {
            HumanPlayerSelect[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < backButtonsCPUorHuman.Length; i++)
        {
            backButtonsCPUorHuman[i].gameObject.SetActive(false);
        }

        KeyboardButton.onClick.AddListener(KeyBoardButtonClicked);

        SelectedPlayerStone[0].gameObject.SetActive(true);
        SelectedPlayerStone[1].gameObject.SetActive(true);

        SelectPlayerButtons[0].onClick.AddListener(AddPlayerToList);
        SelectPlayerButtons[1].onClick.AddListener(AddPlayerToListOne);
        SelectPlayerButtons[2].onClick.AddListener(AddPlayerToListTwo);
        SelectPlayerButtons[3].onClick.AddListener(AddPlayerToListThree);
        SelectPlayerButtons[4].onClick.AddListener(AddPlayerToListFour);
        SelectPlayerButtons[5].onClick.AddListener(AddPlayerToListFive);

        CPUPlayerSelect[0].onClick.AddListener(CPUSelectPlayerClicked);
        CPUPlayerSelect[1].onClick.AddListener(CPUSelectPlayerClickedOne);
        CPUPlayerSelect[2].onClick.AddListener (CPUSelectPlayerClickedTwo);
        CPUPlayerSelect[3].onClick.AddListener(CPUSelectPlayerClickedThree);
        CPUPlayerSelect[4].onClick.AddListener(CPUSelectPlayerClickedFour);
        CPUPlayerSelect[5].onClick.AddListener(CPUSelectPlayerClickedFive);

        HumanPlayerSelect[0].onClick.AddListener(HumanSelectPlayerClicked);
        HumanPlayerSelect[1].onClick.AddListener(HumanSelectPlayerClickedOne);
        HumanPlayerSelect[2].onClick.AddListener(HumanSelectPlayerClickedTwo);
        HumanPlayerSelect[3].onClick.AddListener(HumanSelectPlayerClickedThree);
        HumanPlayerSelect[4].onClick.AddListener(HumanSelectPlayerClickedFour);
        HumanPlayerSelect[5].onClick.AddListener(HumanSelectPlayerClickedFive);

        
        backButtonsCPUorHuman[0].onClick.AddListener(BackButtonsCPUorHumanClicked);
        backButtonsCPUorHuman[1].onClick.AddListener(BackButtonsCPUorHumanClickedOne);
        backButtonsCPUorHuman[2].onClick.AddListener(BackButtonsCPUorHumanClickedTwo);
        backButtonsCPUorHuman[3].onClick.AddListener (BackButtonsCPUorHumanClickedThree);
        backButtonsCPUorHuman[4].onClick.AddListener(BackButtonsCPUorHumanClickedFour);
        backButtonsCPUorHuman[5].onClick.AddListener(BackButtonsCPUorHumanClickedFive);
        

        allReady.onClick.AddListener(readyUpVoid);



        addPlayerButton.onClick.AddListener(AddPlayer);
        removePlayerButton.onClick.AddListener(RemovePlayer);

        previousButtons[0].onClick.AddListener(previousButtonClicked);
        nextButtons[0].onClick.AddListener(nextButtonClicked);

        previousButtons[1].onClick.AddListener(previousButtonClickedOne);
        nextButtons[1].onClick.AddListener(nextButtonClickedOne);

        previousButtons[2].onClick.AddListener(previousButtonClickedTwo);
        nextButtons[2].onClick.AddListener(nextButtonClickedTwo);

        previousButtons[3].onClick.AddListener(previousButtonClickedThree);
        nextButtons[3].onClick.AddListener(nextButtonClickedThree);

        previousButtons[4].onClick.AddListener(previousButtonClickedFour);
        nextButtons[4].onClick.AddListener(nextButtonClickedFour);

        previousButtons[5].onClick.AddListener(previousButtonClickedFive);
        nextButtons[5].onClick.AddListener(nextButtonClickedFive);
    }


    public void KeyBoardButtonClicked()
    {
        KeyboardButton.gameObject.SetActive(false);
        KeyBoardAnimator.SetBool("IsKeyBoardClicked", true);
        KeyBoardAnimator.CrossFade("KeyBoardOpenPanel", 0.05f);

    }

    public void BackButtonsCPUorHumanClicked()
    {
        HumanPlayerSelect[0].gameObject.SetActive(true);
        CPUPlayerSelect[0].gameObject.SetActive(true);
        PlayerTypeTexts[0].gameObject.SetActive(false);
        backButtonsCPUorHuman[0].gameObject.SetActive(false);

        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 0)
            {
                player.playerType = PlayerTypes.DEFAULT_PLAYER;
            }
        }
    }

    public void BackButtonsCPUorHumanClickedOne()
    {
        HumanPlayerSelect[1].gameObject.SetActive(true);
        CPUPlayerSelect[1].gameObject.SetActive(true);
        PlayerTypeTexts[1].gameObject.SetActive(false);
        backButtonsCPUorHuman[1].gameObject.SetActive(false);

        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 1)
            {
                player.playerType = PlayerTypes.DEFAULT_PLAYER;
            }
        }
    }

    public void BackButtonsCPUorHumanClickedTwo()
    {
        HumanPlayerSelect[2].gameObject.SetActive(true);
        CPUPlayerSelect[2].gameObject.SetActive(true);
        PlayerTypeTexts[2].gameObject.SetActive(false);
        backButtonsCPUorHuman[2].gameObject.SetActive(false);

        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 2)
            {
                player.playerType = PlayerTypes.DEFAULT_PLAYER;
            }
        }
    }

    public void BackButtonsCPUorHumanClickedThree()
    {
        HumanPlayerSelect[3].gameObject.SetActive(true);
        CPUPlayerSelect[3].gameObject.SetActive(true);
        PlayerTypeTexts[3].gameObject.SetActive(false);
        backButtonsCPUorHuman[3].gameObject.SetActive(false);

        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 3)
            {
                player.playerType = PlayerTypes.DEFAULT_PLAYER;
            }
        }
    }

    public void BackButtonsCPUorHumanClickedFour()
    {
        HumanPlayerSelect[4].gameObject.SetActive(true);
        CPUPlayerSelect[4].gameObject.SetActive(true);
        PlayerTypeTexts[4].gameObject.SetActive(false);
        backButtonsCPUorHuman[4].gameObject.SetActive(false);

        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 4)
            {
                player.playerType = PlayerTypes.DEFAULT_PLAYER;
            }
        }
    }

    public void BackButtonsCPUorHumanClickedFive()
    {
        HumanPlayerSelect[5].gameObject.SetActive(true);
        CPUPlayerSelect[5].gameObject.SetActive(true);
        PlayerTypeTexts[5].gameObject.SetActive(false);
        backButtonsCPUorHuman[5].gameObject.SetActive(false);

        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 5)
            {
                player.playerType = PlayerTypes.DEFAULT_PLAYER;
            }
        }
    }

    public void HumanSelectPlayerClicked()
    {
        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 0)
            {
                player.playerType = PlayerTypes.HUMAN;
            }
        }

        HumanPlayerSelect[0].gameObject.SetActive(false);
        CPUPlayerSelect[0].gameObject.SetActive(false);
        PlayerTypeTexts[0].gameObject.SetActive(true);
        PlayerTypeTexts[0].text = "H U M A N";
        backButtonsCPUorHuman[0].gameObject.SetActive(true);
    }

    public void HumanSelectPlayerClickedOne()
    {
        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 1)
            {
                player.playerType = PlayerTypes.HUMAN;
            }
        }

        HumanPlayerSelect[1].gameObject.SetActive(false);
        backButtonsCPUorHuman[1].gameObject.SetActive(true);
        CPUPlayerSelect[1].gameObject.SetActive(false);
        PlayerTypeTexts[1].gameObject.SetActive(true);
        PlayerTypeTexts[1].text = "H U M A N";
    }

    public void HumanSelectPlayerClickedTwo()
    {
        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 2)
            {
                player.playerType = PlayerTypes.HUMAN;
            }
        }

        HumanPlayerSelect[2].gameObject.SetActive(false);
        backButtonsCPUorHuman[2].gameObject.SetActive(true);
        CPUPlayerSelect[2].gameObject.SetActive(false);
        PlayerTypeTexts[2].gameObject.SetActive(true);
        PlayerTypeTexts[2].text = "H U M A N";
    }

    public void HumanSelectPlayerClickedThree()
    {
        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 3)
            {
                player.playerType = PlayerTypes.HUMAN;
            }
        }

        HumanPlayerSelect[3].gameObject.SetActive(false);
        backButtonsCPUorHuman[3].gameObject.SetActive(true);
        CPUPlayerSelect[3].gameObject.SetActive(false);
        PlayerTypeTexts[3].gameObject.SetActive(true);
        PlayerTypeTexts[3].text = "H U M A N";
    }

    public void HumanSelectPlayerClickedFour()
    {
        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 4)
            {
                player.playerType = PlayerTypes.HUMAN;
            }
        }

        HumanPlayerSelect[4].gameObject.SetActive(false);
        backButtonsCPUorHuman[4].gameObject.SetActive(true);
        CPUPlayerSelect[4].gameObject.SetActive(false);
        PlayerTypeTexts[4].gameObject.SetActive(true);
        PlayerTypeTexts[4].text = "H U M A N";
    }

    public void HumanSelectPlayerClickedFive()
    {
        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 5)
            {
                player.playerType = PlayerTypes.HUMAN;
            }
        }

        HumanPlayerSelect[5].gameObject.SetActive(false);
        backButtonsCPUorHuman[5].gameObject.SetActive(true);
        CPUPlayerSelect[5].gameObject.SetActive(false);
        PlayerTypeTexts[5].gameObject.SetActive(true);
        PlayerTypeTexts[5].text = "H U M A N";
    }

    public void CPUSelectPlayerClicked()
    {
        foreach(Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 0)
            {
                player.playerType = PlayerTypes.DEFAULT_PLAYER;
                //Assign default player as player type for CPU players, because as soon as CPU player type is assigned to a player the CPU immediately begins playing, disrupting character selection
            }
        }

        CPUPlayerSelect[0].gameObject.SetActive(false);
        backButtonsCPUorHuman[0].gameObject.SetActive(true);
        HumanPlayerSelect[0].gameObject.SetActive(false);
        PlayerTypeTexts[0].gameObject.SetActive(true);
        PlayerTypeTexts[0].text = "C P U";
    }

    public void CPUSelectPlayerClickedOne()
    {
        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 1)
            {
                player.playerType = PlayerTypes.DEFAULT_PLAYER;
                //Assign default player as player type for CPU players, because as soon as CPU player type is assigned to a player the CPU immediately begins playing, disrupting character selection
            }
        }

        CPUPlayerSelect[1].gameObject.SetActive(false);
        backButtonsCPUorHuman[1].gameObject.SetActive(true);
        HumanPlayerSelect[1].gameObject.SetActive(false);
        PlayerTypeTexts[1].gameObject.SetActive(true);
        PlayerTypeTexts[1].text = "C P U";
    }

    public void CPUSelectPlayerClickedTwo()
    {
        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 2)
            {
                player.playerType = PlayerTypes.DEFAULT_PLAYER;
                //Assign default player as player type for CPU players, because as soon as CPU player type is assigned to a player the CPU immediately begins playing, disrupting character selection
            }
        }

        CPUPlayerSelect[2].gameObject.SetActive(false);
        backButtonsCPUorHuman[2].gameObject.SetActive(true);
        HumanPlayerSelect[2].gameObject.SetActive(false);
        PlayerTypeTexts[2].gameObject.SetActive(true);
        PlayerTypeTexts[2].text = "C P U";
    }

    public void CPUSelectPlayerClickedThree()
    {
        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 3)
            {
                player.playerType = PlayerTypes.DEFAULT_PLAYER;
                //Assign default player as player type for CPU players, because as soon as CPU player type is assigned to a player the CPU immediately begins playing, disrupting character selection
            }
        }

        CPUPlayerSelect[3].gameObject.SetActive(false);
        backButtonsCPUorHuman[3].gameObject.SetActive(true);
        HumanPlayerSelect[3].gameObject.SetActive(false);
        PlayerTypeTexts[3].gameObject.SetActive(true);
        PlayerTypeTexts[3].text = "C P U";
    }

    public void CPUSelectPlayerClickedFour()
    {
        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 4)
            {
                player.playerType = PlayerTypes.DEFAULT_PLAYER;
                //Assign default player as player type for CPU players, because as soon as CPU player type is assigned to a player the CPU immediately begins playing, disrupting character selection
            }
        }

        CPUPlayerSelect[4].gameObject.SetActive(false);
        backButtonsCPUorHuman[4].gameObject.SetActive(true);
        HumanPlayerSelect[4].gameObject.SetActive(false);
        PlayerTypeTexts[4].gameObject.SetActive(true);
        PlayerTypeTexts[4].text = "C P U";
    }

    public void CPUSelectPlayerClickedFive()
    {
        foreach (Entity player in GameManagerScript.playerList)
        {
            if (player.selectScreenPos == 5)
            {
                player.playerType = PlayerTypes.DEFAULT_PLAYER;
                //Assign default player as player type for CPU players, because as soon as CPU player type is assigned to a player the CPU immediately begins playing, disrupting character selection
            }
        }

        CPUPlayerSelect[5].gameObject.SetActive(false);
        backButtonsCPUorHuman[5].gameObject.SetActive(true);
        HumanPlayerSelect[5].gameObject.SetActive(false);
        PlayerTypeTexts[5].gameObject.SetActive(true);
        PlayerTypeTexts[5].text = "C P U";
    }


    public void readyUpVoid()
    {

        for (int i = GameManagerScript.playerList.Count - 1; i >= 0; i--)
        {
            if (!GameManagerScript.playerList[i].isPartOfList)
            {
                GameManagerScript.playerList.RemoveAt(i);
            }
        }
    }

    public void AddPlayerToListFive()
    {

        selectButtonsClicked[5] = true;

      

        if (selectedCharactersCountFive == 1)
        {
            Debug.Log("Added player to List");
            GameObject newPlayerObject = GameObject.Find("stone");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[5].text;
            bool isPlayerActive = true;
            int selectScreenPos = 5;



            GameObject newPlayerChild = newPlayerObject.transform.Find("character").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M15").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bullet").gameObject;

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");




            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectOne);
        }
        else if (selectedCharactersCountFive == 2)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (1)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[5].text;
            bool isPlayerActive = true;
            int selectScreenPos = 5;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterOne").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (1)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (1)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (1)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (1)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (1)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (1)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (1)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletOne").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountFive == 3)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (2)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[5].text;
            bool isPlayerActive = true;
            int selectScreenPos = 5;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterTwo").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (2)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (2)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (2)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (2)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (2)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (2)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (2)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletTwo").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountFive == 4)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (3)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName =  PlayerInputNameFields[5].text;
            bool isPlayerActive = true;
            int selectScreenPos = 5;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterThree").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (3)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (3)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (3)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (3)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (3)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (3)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (3)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletThree").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountFive == 5)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (4)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[5].text;
            bool isPlayerActive = true;
            int selectScreenPos = 5;


            GameObject newPlayerChild = newPlayerObject.transform.Find("characterFour").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (4)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (4)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (4)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (4)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (4)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (4)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (4)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletFour").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountFive == 6)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (5)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[5].text;
            bool isPlayerActive = true;
            int selectScreenPos = 5;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterFive").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (5)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (5)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (5)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (5)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (5)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (5)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (5)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletFive").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }

    

        SelectPlayerButtons[5].gameObject.SetActive(false);
        previousButtons[5].gameObject.SetActive(false);
        nextButtons[5].gameObject.SetActive(false);
        infoButtons[5].gameObject.SetActive(false);

        CPUPlayerSelect[5].gameObject.SetActive(true);
        HumanPlayerSelect[5].gameObject.SetActive(true);
        PlayerTypeTexts[5].gameObject.SetActive(false);

        PlayerInputNameFields[5].interactable = false;
        

    }


    public void AddPlayerToList()
    {

        selectButtonsClicked[0] = true;

        if (selectedCharactersCount == 1)
        {
            Debug.Log("Added player to List");
            GameObject newPlayerObject = GameObject.Find("stone");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[0].text;
            bool isPlayerActive = true;
            int selectScreenPos = 0;



            GameObject newPlayerChild = newPlayerObject.transform.Find("character").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M15").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bullet").gameObject;

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");




            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectOne);
        }
        else if (selectedCharactersCount == 2)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (1)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[0].text;
            bool isPlayerActive = true;
            int selectScreenPos = 0;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterOne").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (1)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (1)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (1)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (1)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (1)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (1)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (1)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletOne").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCount == 3)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (2)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[0].text; ;
            bool isPlayerActive = true;
            int selectScreenPos = 0;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterTwo").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (2)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (2)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (2)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (2)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (2)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (2)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (2)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletTwo").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCount == 4)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (3)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[0].text;
            bool isPlayerActive = true;
            int selectScreenPos = 0;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterThree").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (3)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (3)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (3)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (3)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (3)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (3)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (3)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletThree").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCount == 5)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (4)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[0].text;
            bool isPlayerActive = true;
            int selectScreenPos = 0;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterFour").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (4)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (4)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (4)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (4)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (4)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (4)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (4)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletFour").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCount == 6)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (5)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[0].text;
            bool isPlayerActive = true;
            int selectScreenPos = 0;


            GameObject newPlayerChild = newPlayerObject.transform.Find("characterFive").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (5)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (5)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (5)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (5)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (5)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (5)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (5)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletFive").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        SelectPlayerButtons[0].gameObject.SetActive(false);
        previousButtons[0].gameObject.SetActive(false);
        nextButtons[0].gameObject.SetActive(false);
        infoButtons[0].gameObject.SetActive(false);

        CPUPlayerSelect[0].gameObject.SetActive(true);
        HumanPlayerSelect[0].gameObject.SetActive(true);
        PlayerTypeTexts[0].gameObject.SetActive(false);

        PlayerInputNameFields[0].interactable = false;

    }

    public void AddPlayerToListFour()
    {

        selectButtonsClicked[4] = true;

        if (selectedCharactersCountFour == 1)
        {
            Debug.Log("Added player to List");
            GameObject newPlayerObject = GameObject.Find("stone");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[4].text;
            bool isPlayerActive = true;
            int selectScreenPos = 4;



            GameObject newPlayerChild = newPlayerObject.transform.Find("character").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M15").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bullet").gameObject;

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");




            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectOne);
        }
        else if (selectedCharactersCountFour == 2)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (1)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[4].text;
            bool isPlayerActive = true;
            int selectScreenPos = 4;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterOne").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (1)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (1)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (1)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (1)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (1)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (1)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (1)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletOne").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountFour == 3)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (2)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[4].text;
            bool isPlayerActive = true;
            int selectScreenPos = 4;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterTwo").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (2)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (2)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (2)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (2)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (2)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (2)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (2)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletTwo").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountFour == 4)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (3)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[4].text;
            bool isPlayerActive = true;
            int selectScreenPos = 4;


            GameObject newPlayerChild = newPlayerObject.transform.Find("characterThree").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (3)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (3)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (3)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (3)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (3)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (3)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (3)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletThree").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountFour == 5)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (4)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[4].text;
            bool isPlayerActive = true;
            int selectScreenPos = 4;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterFour").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (4)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (4)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (4)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (4)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (4)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (4)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (4)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletFour").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountFour == 6)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (5)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[4].text;
            bool isPlayerActive = true;
            int selectScreenPos = 4;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterFive").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (5)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (5)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (5)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (5)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (5)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (5)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (5)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletFive").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }

       

        SelectPlayerButtons[4].gameObject.SetActive(false);
        previousButtons[4].gameObject.SetActive(false);
        nextButtons[4].gameObject.SetActive(false);
        infoButtons[4].gameObject.SetActive(false);

        CPUPlayerSelect[4].gameObject.SetActive(true);
        HumanPlayerSelect[4].gameObject.SetActive(true);
        PlayerTypeTexts[4].gameObject.SetActive(false);

        PlayerInputNameFields[4].interactable = false;

    }

    public void AddPlayerToListOne()
    {

        selectButtonsClicked[1] = true;

        if (selectedCharactersCountOne == 1)
        {
            Debug.Log("Added player to List");
            GameObject newPlayerObject = GameObject.Find("stone");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[1].text;
            bool isPlayerActive = true;
            int selectScreenPos = 1;



            GameObject newPlayerChild = newPlayerObject.transform.Find("character").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M15").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bullet").gameObject;

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");




            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectOne);
        }
        else if (selectedCharactersCountOne == 2)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (1)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[1].text;
            bool isPlayerActive = true;
            int selectScreenPos = 1;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterOne").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (1)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (1)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (1)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (1)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (1)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (1)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (1)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletOne").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountOne == 3)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (2)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[1].text;
            bool isPlayerActive = true;
            int selectScreenPos = 1;


            GameObject newPlayerChild = newPlayerObject.transform.Find("characterTwo").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (2)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (2)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (2)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (2)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (2)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (2)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (2)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletTwo").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountOne == 4)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (3)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[1].text;
            bool isPlayerActive = true;
            int selectScreenPos = 1;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterThree").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (3)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (3)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (3)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (3)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (3)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (3)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (3)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletThree").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountOne == 5)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (4)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[1].text;
            bool isPlayerActive = true;
            int selectScreenPos = 1;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterFour").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (4)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (4)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (4)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (4)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (4)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (4)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (4)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletFour").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountOne == 6)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (5)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[1].text;
            bool isPlayerActive = true;
            int selectScreenPos = 1;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterFive").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (5)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (5)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (5)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (5)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (5)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (5)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (5)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletFive").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }

     

        SelectPlayerButtons[1].gameObject.SetActive(false);
        previousButtons[1].gameObject.SetActive(false);
        nextButtons[1].gameObject.SetActive(false);
        infoButtons[1].gameObject.SetActive(false);


        CPUPlayerSelect[1].gameObject.SetActive(true);
        HumanPlayerSelect[1].gameObject.SetActive(true);
        PlayerTypeTexts[1].gameObject.SetActive(false);

        PlayerInputNameFields[1].interactable = false;

    }

    public void AddPlayerToListThree()
    {

        selectButtonsClicked[3] = true;

        if (selectedCharactersCountThree == 1)
        {
            Debug.Log("Added player to List");
            GameObject newPlayerObject = GameObject.Find("stone");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[3].text;
            bool isPlayerActive = true;
            int selectScreenPos = 3;




            GameObject newPlayerChild = newPlayerObject.transform.Find("character").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M15").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bullet").gameObject;

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");




            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectOne);
        }
        else if (selectedCharactersCountThree == 2)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (1)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[3].text;
            bool isPlayerActive = true;
            int selectScreenPos = 3;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterOne").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (1)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (1)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (1)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (1)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (1)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (1)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (1)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletOne").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountThree == 3)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (2)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[3].text;
            bool isPlayerActive = true;
            int selectScreenPos = 3;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterTwo").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (2)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (2)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (2)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (2)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (2)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (2)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (2)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletTwo").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountThree == 4)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (3)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[3].text;
            bool isPlayerActive = true;
            int selectScreenPos = 3;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterThree").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (3)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (3)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (3)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (3)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (3)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (3)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (3)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletThree").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountThree == 5)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (4)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[3].text;
            bool isPlayerActive = true;
            int selectScreenPos = 3;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterFour").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (4)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (4)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (4)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (4)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (4)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (4)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (4)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletFour").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountThree == 6)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (5)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[3].text;
            bool isPlayerActive = true;
            int selectScreenPos = 3;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterFive").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (5)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (5)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (5)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (5)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (5)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (5)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (5)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletFive").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }

      

        SelectPlayerButtons[3].gameObject.SetActive(false);
        previousButtons[3].gameObject.SetActive(false);
        nextButtons[3].gameObject.SetActive(false);
        infoButtons[3].gameObject.SetActive(false);

        CPUPlayerSelect[3].gameObject.SetActive(true);
        HumanPlayerSelect[3].gameObject.SetActive(true);
        PlayerTypeTexts[3].gameObject.SetActive(false);

        PlayerInputNameFields[3].interactable = false;

        //  addPlayerButton.gameObject.SetActive(false);
        //  removePlayerButton.gameObject.SetActive(false);

    }

    public void AddPlayerToListTwo()
    {

        selectButtonsClicked[2] = true;

        if(selectedCharactersCountTwo == 1)
        {
            Debug.Log("Added player to List");
            GameObject newPlayerObject = GameObject.Find("stone");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[2].text;
            bool isPlayerActive = true;
            int selectScreenPos = 2;



            GameObject newPlayerChild = newPlayerObject.transform.Find("character").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M15").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bullet").gameObject;

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");

           


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectOne);
        }
        else if(selectedCharactersCountTwo == 2)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (1)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[2].text;
            bool isPlayerActive = true;
            int selectScreenPos = 2;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterOne").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (1)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (1)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (1)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (1)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (1)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (1)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (1)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletOne").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");

            
            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountTwo == 3)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (2)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[2].text;
            bool isPlayerActive = true;
            int selectScreenPos = 2;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterTwo").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (2)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (2)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (2)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (2)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (2)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (2)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (2)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletTwo").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountTwo == 4)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (3)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[2].text;
            bool isPlayerActive = true;
            int selectScreenPos = 2;




            GameObject newPlayerChild = newPlayerObject.transform.Find("characterThree").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (3)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (3)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (3)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (3)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (3)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (3)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (3)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletThree").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountTwo == 5)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (4)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[2].text;
            bool isPlayerActive = true;
            int selectScreenPos = 2;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterFour").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (4)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (4)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (4)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (4)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (4)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (4)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (4)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletFour").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }
        else if (selectedCharactersCountTwo == 6)
        {
            Debug.Log("Added player to List");

            GameObject newPlayerObject = GameObject.Find("stone (5)");
            GameObject newPlayerShield = GameObject.Find("Shield");
            string playersName = PlayerInputNameFields[2].text;
            bool isPlayerActive = true;
            int selectScreenPos = 2;



            GameObject newPlayerChild = newPlayerObject.transform.Find("characterFive").gameObject;
            GameObject newPlayerSniper = newPlayerChild.transform.Find("Sniper_rifle_KSR-29 (5)").gameObject;
            GameObject newPlayerAK47 = newPlayerChild.transform.Find("AK47 (5)").gameObject;
            GameObject newPlayerPistol = newPlayerChild.transform.Find("Beretta Pistol (5)").gameObject;
            GameObject newPlayerGrenade = newPlayerChild.transform.Find("GrenadeParent (5)").gameObject;
            GameObject newPlayerM15 = newPlayerChild.transform.Find("M4a1 (5)").gameObject;
            GameObject newPlayerShotgun = newPlayerChild.transform.Find("Shotgun (5)").gameObject;
            GameObject newPlayerRPG = newPlayerChild.transform.Find("RocketLauncher (5)").gameObject;
            GameObject newPlayerRPGHead = newPlayerRPG.transform.Find("rpg 7 bulletFive").gameObject;
            Animator newPlayerShieldAnimation = newPlayerShield.GetComponent<Animator>();

            Animator newPlayerAnimation = newPlayerChild.GetComponent<Animator>();
            //  GameObject newPlayerObjectOne = GameObject.Find("stone(1)(Clone)");


            AddPlayerObject(newPlayerObject, newPlayerChild, newPlayerAnimation, newPlayerSniper, newPlayerAK47, newPlayerPistol, newPlayerGrenade, newPlayerM15, newPlayerShotgun, newPlayerRPG, newPlayerRPGHead, newPlayerShieldAnimation, playersName, isPlayerActive, selectScreenPos);//, newPlayerObjectO
        }

        

        SelectPlayerButtons[2].gameObject.SetActive(false);
        previousButtons[2].gameObject.SetActive(false);
        nextButtons[2].gameObject.SetActive(false);
        infoButtons[2].gameObject.SetActive(false);

        CPUPlayerSelect[2].gameObject.SetActive(true);
        HumanPlayerSelect[2].gameObject.SetActive(true);
        PlayerTypeTexts[2].gameObject.SetActive(false);

        PlayerInputNameFields[2].interactable = false;
    }

    private int GetNextAvailableCharacter(GameObject[] characterArray, int currentIndex)
    {
        int startIndex = currentIndex;
        do
        {
            currentIndex = (currentIndex + 1) % characterArray.Length;
        }
        while (characterSelected[currentIndex] && currentIndex != startIndex) ;
        return currentIndex;
    }

    // Helper function to find the previous available character
    private int GetPreviousAvailableCharacter(GameObject[] characterArray, int currentIndex)
    {
        int startIndex = currentIndex;
        do
        {
            currentIndex = (currentIndex - 1 + characterArray.Length) % characterArray.Length;
        }
        while (characterSelected[currentIndex] && currentIndex != startIndex);
        return currentIndex;
    }

    // Mark the character as selected or deselected
    private void SetCharacterSelection(int index, bool isSelected)
    {
        characterSelected[index] = isSelected;
    }

    public void nextButtonClicked()
    {
        SetCharacterSelection(selectedCharactersCount, false);
        selectedCharactersCount = GetNextAvailableCharacter(SelectedCharacters, selectedCharactersCount);
        SetCharacterSelection(selectedCharactersCount, true);


        UpdateCharacterDisplay(SelectedCharacters, selectedCharactersCount);
    }

    public void nextButtonClickedOne()
    {
        SetCharacterSelection(selectedCharactersCountOne, false);
        selectedCharactersCountOne = GetNextAvailableCharacter(SelectedCharactersOne, selectedCharactersCountOne);
        SetCharacterSelection(selectedCharactersCountOne, true);

        UpdateCharacterDisplay(SelectedCharactersOne, selectedCharactersCountOne);
    }

    public void nextButtonClickedTwo()
    {
        SetCharacterSelection(selectedCharactersCountTwo, false);
        selectedCharactersCountTwo = GetNextAvailableCharacter(SelectedCharactersTwo, selectedCharactersCountTwo);
        SetCharacterSelection(selectedCharactersCountTwo, true);

        UpdateCharacterDisplay(SelectedCharactersTwo, selectedCharactersCountTwo);
    }

    public void nextButtonClickedThree()
    {
        SetCharacterSelection(selectedCharactersCountThree, false);
        selectedCharactersCountThree = GetNextAvailableCharacter(SelectedCharactersThree, selectedCharactersCountThree);
        SetCharacterSelection(selectedCharactersCountThree, true);

        UpdateCharacterDisplay(SelectedCharactersThree, selectedCharactersCountThree);
    }

    public void nextButtonClickedFour()
    {
        SetCharacterSelection(selectedCharactersCountFour, false);
        selectedCharactersCountFour = GetNextAvailableCharacter(SelectedCharactersFour, selectedCharactersCountFour);
        SetCharacterSelection(selectedCharactersCountFour, true);

        UpdateCharacterDisplay(SelectedCharactersFour, selectedCharactersCountFour);
    }

    public void nextButtonClickedFive()
    {
        SetCharacterSelection(selectedCharactersCountFive, false);
        selectedCharactersCountFive = GetNextAvailableCharacter(SelectedCharactersFive, selectedCharactersCountFive);
        SetCharacterSelection(selectedCharactersCountFive, true);

        UpdateCharacterDisplay(SelectedCharactersFive, selectedCharactersCountFive);
    }

    public void previousButtonClicked()
    {
        SetCharacterSelection(selectedCharactersCount, false);
        selectedCharactersCount = GetPreviousAvailableCharacter(SelectedCharacters, selectedCharactersCount);
        SetCharacterSelection(selectedCharactersCount, true);

        UpdateCharacterDisplay(SelectedCharacters, selectedCharactersCount);
    }

    public void previousButtonClickedOne()
    {
        SetCharacterSelection(selectedCharactersCountOne, false);
        selectedCharactersCountOne = GetPreviousAvailableCharacter(SelectedCharactersOne, selectedCharactersCountOne);
        SetCharacterSelection(selectedCharactersCountOne, true);

        UpdateCharacterDisplay(SelectedCharactersOne, selectedCharactersCountOne);
    }

    public void previousButtonClickedTwo()
    {
        SetCharacterSelection(selectedCharactersCountTwo, false);
        selectedCharactersCountTwo = GetPreviousAvailableCharacter(SelectedCharactersTwo, selectedCharactersCountTwo);
        SetCharacterSelection(selectedCharactersCountTwo, true);

        UpdateCharacterDisplay(SelectedCharactersTwo, selectedCharactersCountTwo);
    }

    public void previousButtonClickedThree()
    {
        SetCharacterSelection(selectedCharactersCountThree, false);
        selectedCharactersCountThree = GetPreviousAvailableCharacter(SelectedCharactersThree, selectedCharactersCountThree);
        SetCharacterSelection(selectedCharactersCountThree, true);

        UpdateCharacterDisplay(SelectedCharactersThree, selectedCharactersCountThree);
    }

    public void previousButtonClickedFour()
    {
        SetCharacterSelection(selectedCharactersCountFour, false);
        selectedCharactersCountFour = GetPreviousAvailableCharacter(SelectedCharactersFour, selectedCharactersCountFour);
        SetCharacterSelection(selectedCharactersCountFour, true);

        UpdateCharacterDisplay(SelectedCharactersFour, selectedCharactersCountFour);
    }

    public void previousButtonClickedFive()
    {
        SetCharacterSelection(selectedCharactersCountFive, false);
        selectedCharactersCountFive = GetPreviousAvailableCharacter(SelectedCharactersFive, selectedCharactersCountFive);
        SetCharacterSelection(selectedCharactersCountFive, true);

        UpdateCharacterDisplay(SelectedCharactersFive, selectedCharactersCountFive);
    }

    private void UpdateCharacterDisplay(GameObject[] characterArray, int selectedIndex)
    {
        for (int i = 0; i < characterArray.Length; i++)
        {
            characterArray[i].SetActive(i == selectedIndex);
        }

        int[] selectCharNumsArr = { selectedCharactersCount, selectedCharactersCountOne, selectedCharactersCountTwo, selectedCharactersCountThree, selectedCharactersCountFour, selectedCharactersCountFive };
        int countZeros = selectCharNumsArr.Count(n => n == 0);



        if (countZeros >= 1 && characterSelected[0] == true)
        {

            for (int i = 0; i < selectCharNumsArr.Length; i++)
            {
                if (selectCharNumsArr[i] == 0)
                {
                    SelectPlayerButtons[i].gameObject.SetActive(false);
                    infoButtons[i].gameObject.SetActive(false);
                }
              
            }
        }
        else
        {

           
            for (int i = 0; i < selectCharNumsArr.Length; i++)
            {

               

                if (selectButtonsClicked[i] == true)
                {
                    SelectPlayerButtons[i].gameObject.SetActive(false);
                }
                else if (selectCharNumsArr[i] != 0)
                {
                   
                        SelectPlayerButtons[i].gameObject.SetActive(true);
                        infoButtons[i].gameObject.SetActive(true);
                }
               

            }
        }


    }


   
   


    public void AddPlayer()
    {

      

        if (currentPlayerCount < maxPlayers)
        {

            if(currentPlayerCount == 0)
            {
                previousButtons[2].gameObject.SetActive(true);
                nextButtons[2].gameObject.SetActive(true);
                isPlayerActive[0] = true;
                // SelectPlayerButtons[2].gameObject.SetActive(true);

                CPUorHumanAnims[2].SetBool("IsPlayerAdded", true);
                CPUorHumanAnims[2].CrossFade("CPUorHumanAnimPanelOpen", 0.05f);


                for (int i = 0; i < SelectedCharactersTwo.Length; i++)
                {
                    SelectedCharactersTwo[i].gameObject.SetActive(false);
                }

               

                SelectedCharactersTwo[0].gameObject.SetActive(true);

                
                
            }
            else  if (currentPlayerCount == 1)
            {
                previousButtons[3].gameObject.SetActive(true);
                nextButtons[3].gameObject.SetActive(true);
                isPlayerActive[1] = true;

                CPUorHumanAnims[3].SetBool("IsPlayerAdded", true);
                CPUorHumanAnims[3].CrossFade("CPUorHumanAnimPanelOpen", 0.05f);


                for (int i = 0; i < SelectedCharactersThree.Length; i++)
                {
                    SelectedCharactersThree[i].gameObject.SetActive(false);
                }

                SelectedCharactersThree[0].gameObject.SetActive(true);
                

            }
            else if (currentPlayerCount == 2)
            {
                //alternate array position here is 1
                previousButtons[1].gameObject.SetActive(true);
                nextButtons[1].gameObject.SetActive(true);
                isPlayerActive[2] = true;

                CPUorHumanAnims[1].SetBool("IsPlayerAdded", true);
                CPUorHumanAnims[1].CrossFade("CPUorHumanAnimPanelOpen", 0.05f);


                for (int i = 0; i < SelectedCharactersOne.Length; i++)
                {
                    SelectedCharactersOne[i].gameObject.SetActive(false);

                }

                SelectedCharactersOne[0].gameObject.SetActive(true);

                

            }
            else if (currentPlayerCount == 3)
            {
                //alternate array position here is 4
                previousButtons[4].gameObject.SetActive(true);
                nextButtons[4].gameObject.SetActive(true);
                isPlayerActive[3] = true;

                CPUorHumanAnims[4].SetBool("IsPlayerAdded", true);
                CPUorHumanAnims[4].CrossFade("CPUorHumanAnimPanelOpen", 0.05f);


                for (int i = 0; i < SelectedCharactersFour.Length; i++)
                {
                    SelectedCharactersFour[i].gameObject.SetActive(false);
                }

                SelectedCharactersFour[0].gameObject.SetActive(true);
            }
            else if (currentPlayerCount == 4)
            {
                //alternate array position here is 0
                previousButtons[0].gameObject.SetActive(true);
                nextButtons[0].gameObject.SetActive(true);
                isPlayerActive[4] = true;

                CPUorHumanAnims[0].SetBool("IsPlayerAdded", true);
                CPUorHumanAnims[0].CrossFade("CPUorHumanAnimPanelOpen", 0.05f);


                for (int i = 0; i < SelectedCharacters.Length; i++)
                {
                    SelectedCharacters[i].gameObject.SetActive(false);
                }

                SelectedCharacters[0].gameObject.SetActive(true);

            }
            else if (currentPlayerCount == 5)
            {
                //alternate array position here is 5
                previousButtons[5].gameObject.SetActive(true);
                nextButtons[5].gameObject.SetActive(true);
                isPlayerActive[5] = true;

                CPUorHumanAnims[5].SetBool("IsPlayerAdded", true);
                CPUorHumanAnims[5].CrossFade("CPUorHumanAnimPanelOpen", 0.05f);


                for (int i = 0; i < SelectedCharactersFive.Length; i++)
                {
                    SelectedCharactersFive[i].gameObject.SetActive(false);
                }

                SelectedCharactersFive[0].gameObject.SetActive(true);
            }
            currentPlayerCount++;

            // Enable the next player's character selection
            SelectedPlayerStone[currentPlayerCount - 1].SetActive(true);
            newPlayer = true;

           

            Debug.Log("Player added. Current player count: " + currentPlayerCount);
        }
    }

    // Removes the last player by disabling their character selection panel
    public void RemovePlayer()
    {

       

        

        if (currentPlayerCount > 0)
        {
            // Disable the current player's character selection
            SelectedPlayerStone[currentPlayerCount - 1].SetActive(false);
            newPlayer = false;

            currentPlayerCount--;
           

            if (currentPlayerCount == 0)
            {
                characterSelected[selectedCharactersCountTwo] = false;
                selectedCharactersCountTwo = 0;
                previousButtons[2].gameObject.SetActive(false);
                nextButtons[2].gameObject.SetActive(false);
                infoButtons[2].gameObject.SetActive(false);
                SelectPlayerButtons[2].gameObject.SetActive(false);
                selectButtonsClicked[2] = false;

                HumanPlayerSelect[2].gameObject.SetActive(false);
                CPUPlayerSelect[2].gameObject.SetActive(false);
                backButtonsCPUorHuman[2].gameObject.SetActive(false);

                PlayerTypeTexts[2].gameObject.SetActive(true);
                PlayerInputNameFields[2].text = "";

                PlayerTypeTexts[2].text = "PLAYER TYPE";

                PlayerInputNameFields[2].interactable = true;

                CPUorHumanAnims[2].SetBool("IsPlayerAdded", false);
                CPUorHumanAnims[2].SetBool("IsPlayerRemoved", true);
                CPUorHumanAnims[2].CrossFade("CPUorHumanAnimPanelClose", 0.05f);

               
               GameManagerScript.playerList.RemoveAll(entity => entity.selectScreenPos == 2);
            }
            else if(currentPlayerCount == 1)
            {
                characterSelected[selectedCharactersCountThree] = false;
                selectedCharactersCountThree = 0;
                previousButtons[3].gameObject.SetActive(false);
                nextButtons[3].gameObject.SetActive(false);
                infoButtons[3].gameObject.SetActive(false);
                SelectPlayerButtons[3].gameObject.SetActive(false);
                selectButtonsClicked[3] = false;

                PlayerTypeTexts[3].gameObject.SetActive(true);
                PlayerTypeTexts[3].text = "PLAYER TYPE";

                PlayerInputNameFields[3].interactable = true;
                PlayerInputNameFields[3].text = "";

                HumanPlayerSelect[3].gameObject.SetActive(false);
                CPUPlayerSelect[3].gameObject.SetActive(false);
                backButtonsCPUorHuman[3].gameObject.SetActive(false);

                CPUorHumanAnims[3].SetBool("IsPlayerAdded", false);
                CPUorHumanAnims[3].SetBool("IsPlayerRemoved", true);
                CPUorHumanAnims[3].CrossFade("CPUorHumanAnimPanelClose", 0.05f);

                GameManagerScript.playerList.RemoveAll(entity => entity.selectScreenPos == 3);
            }
            else if (currentPlayerCount == 2)
            {
                characterSelected[selectedCharactersCountOne] = false;
                selectedCharactersCountOne = 0;
                previousButtons[1].gameObject.SetActive(false);
                nextButtons[1].gameObject.SetActive(false);
                infoButtons[1].gameObject.SetActive(false);
                SelectPlayerButtons[1].gameObject.SetActive(false);
                selectButtonsClicked[1] = false;

                PlayerTypeTexts[1].gameObject.SetActive(true);
                PlayerTypeTexts[1].text = "PLAYER TYPE";

                PlayerInputNameFields[1].interactable = true;
                PlayerInputNameFields[1].text = "";

                HumanPlayerSelect[1].gameObject.SetActive(false);
                CPUPlayerSelect[1].gameObject.SetActive(false);
                backButtonsCPUorHuman[1].gameObject.SetActive(false);

                CPUorHumanAnims[1].SetBool("IsPlayerAdded", false);
                CPUorHumanAnims[1].SetBool("IsPlayerRemoved", true);
                CPUorHumanAnims[1].CrossFade("CPUorHumanAnimPanelClose", 0.05f);

                GameManagerScript.playerList.RemoveAll(entity => entity.selectScreenPos == 1);

            }
            else if (currentPlayerCount == 3)
            {
                characterSelected[selectedCharactersCountFour] = false;
                selectedCharactersCountFour = 0;
                previousButtons[4].gameObject.SetActive(false);
                nextButtons[4].gameObject.SetActive(false);
                infoButtons[4].gameObject.SetActive(false);
                SelectPlayerButtons[4].gameObject.SetActive(false);
                selectButtonsClicked[4] = false;

                PlayerTypeTexts[4].gameObject.SetActive(true);
                PlayerTypeTexts[4].text = "PLAYER TYPE";

                PlayerInputNameFields[4].interactable = true;
                PlayerInputNameFields[4].text = "";

                HumanPlayerSelect[4].gameObject.SetActive(false);
                CPUPlayerSelect[4].gameObject.SetActive(false);
                backButtonsCPUorHuman[4].gameObject.SetActive(false);

                CPUorHumanAnims[4].SetBool("IsPlayerAdded", false);
                CPUorHumanAnims[4].SetBool("IsPlayerRemoved", true);
                CPUorHumanAnims[4].CrossFade("CPUorHumanAnimPanelClose", 0.05f);

                GameManagerScript.playerList.RemoveAll(entity => entity.selectScreenPos == 4);
            }
            else if (currentPlayerCount == 4)
            {
                characterSelected[selectedCharactersCount] = false;
                 selectedCharactersCount = 0;
                previousButtons[0].gameObject.SetActive(false);
                nextButtons[0].gameObject.SetActive(false);
                infoButtons[0].gameObject.SetActive(false);
                SelectPlayerButtons[0].gameObject.SetActive(false);
                selectButtonsClicked[0] = false;

                PlayerTypeTexts[0].gameObject.SetActive(true);
                PlayerTypeTexts[0].text = "PLAYER TYPE";

                PlayerInputNameFields[0].interactable = true;
                PlayerInputNameFields[0].text = "";

                HumanPlayerSelect[0].gameObject.SetActive(false);
                CPUPlayerSelect[0].gameObject.SetActive(false);
                backButtonsCPUorHuman[0].gameObject.SetActive(false);

                CPUorHumanAnims[0].SetBool("IsPlayerAdded", false);
                CPUorHumanAnims[0].SetBool("IsPlayerRemoved", true);
                CPUorHumanAnims[0].CrossFade("CPUorHumanAnimPanelClose", 0.05f);

                GameManagerScript.playerList.RemoveAll(entity => entity.selectScreenPos == 0);

            }
            else if (currentPlayerCount == 5)
            {
                characterSelected[selectedCharactersCountFive] = false;
                selectedCharactersCountFive = 0;
                previousButtons[5].gameObject.SetActive(false);
                nextButtons[5].gameObject.SetActive(false);
                infoButtons[5].gameObject.SetActive(false);
                SelectPlayerButtons[5].gameObject.SetActive(false);
                selectButtonsClicked[5] = false;

                PlayerTypeTexts[5].gameObject.SetActive(true);
                PlayerTypeTexts[5].text = "PLAYER TYPE";

                PlayerInputNameFields[5].interactable = true;
                PlayerInputNameFields[5].text = "";
                

                HumanPlayerSelect[5].gameObject.SetActive(false);
                CPUPlayerSelect[5].gameObject.SetActive(false);
                backButtonsCPUorHuman[5].gameObject.SetActive(false);

                CPUorHumanAnims[5].SetBool("IsPlayerAdded", false);
                CPUorHumanAnims[5].SetBool("IsPlayerRemoved", true);
                CPUorHumanAnims[5].CrossFade("CPUorHumanAnimPanelClose", 0.05f);

                GameManagerScript.playerList.RemoveAll(entity => entity.selectScreenPos == 5);
            }


            Debug.Log("Player removed. Current player count: " + currentPlayerCount);

        }

       
    }


    public void AddPlayerObject(GameObject playerObject, GameObject playerObjectChild, Animator playerObjectAnimator, GameObject playerObjectSniper, GameObject playerObjectAk47, GameObject playerObjectPistol, GameObject playerObjectGrenade, GameObject playerObjectM15, GameObject playerObjectShotgun, GameObject playerObjectRPG, GameObject playerObjectRPGHead, Animator ShieldAnimator, string PlayerName, bool playerThere, int selectIntNum)// GameObject playerObjectOne)
    {

        Entity newPlayer = new Entity
        {
            playerObject = playerObject,
            playerAnimator = playerObjectAnimator,
            characterObject = playerObjectChild,
            SniperRifle = playerObjectSniper,
            Ak47 = playerObjectAk47,
            Pistol = playerObjectPistol,
            Grenade = playerObjectGrenade,
            M15 = playerObjectM15,
            Shotgun = playerObjectShotgun,
            RocketLauncher = playerObjectRPG,
            RocketLauncherHead = playerObjectRPGHead,
            ShieldAnimator = ShieldAnimator,
            playerName = PlayerName,
            isPartOfList = playerThere,
            selectScreenPos = selectIntNum,
        };

        // Add the new player to the existing list
        GameManagerScript.playerList.Add(newPlayer);

        for (int i = GameManagerScript.playerList.Count - 1; i >= 0; i--)
        {
            if (!GameManagerScript.playerList[i].isPartOfList)
            {
                GameManagerScript.playerList.RemoveAt(i);
            }
        }



    }

  
   

}
