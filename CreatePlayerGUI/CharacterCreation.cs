using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterCreation : MonoBehaviour
{

    int classSelection;
    string playerName = "Enter ya name";
    string playerBio = "What are you like!?";
    int genderSelection;
    string[] genders = new string[2] { "Female", "HeMale" };
    BaseCharacterClass tempClass;


    //Stat allocation tings
    string[] statNames = new string[3] { "Hp", "Strength", "Intellect" };
    string[] statDescriptions = new string[3] { "Healths", "Henchness", "Magics" };
    bool[] statSelections = new bool[3];
    public int[] pointsToAllocate = new int[3]; //starting stat val for chosen class. use to modify
    int[] baseStatPoints = new int[3]; //starting stat val for chosen class
    int avaliablePoints = 1;
    public bool didRunOnce = false;


    //UI tings
    public TextMeshProUGUI hpVal;
    public TextMeshProUGUI strengthVal;
    public TextMeshProUGUI intellectVal;
    public TextMeshProUGUI avaliablePointsVal;
    public TMP_InputField nameField;
    public TMP_InputField bioField;


    public void ChooseMage()
    {
        classSelection = 0;
        tempClass = new BaseMageClass();
        ChooseClass(classSelection);
        AddAbilities(classSelection);
    }
    public void ChooseWarrior()
    {
        classSelection = 1;
        tempClass = new BaseWarriorClass();
        ChooseClass(classSelection);
        AddAbilities(classSelection);
    }
    public void PlusHP()
    {
       if (avaliablePoints > 0)
       {   
           pointsToAllocate[0] += 1;
          --avaliablePoints;
            GameInfo.PlayerMaxHp = pointsToAllocate[0];
            hpVal.text = GameInfo.PlayerMaxHp.ToString();
            avaliablePointsVal.text = avaliablePoints.ToString();
        }
    }
    public void PlusStrength()
    {
        if (avaliablePoints > 0)
        {
            pointsToAllocate[1] += 1;
            --avaliablePoints;
            GameInfo.PlayerStrength = pointsToAllocate[1];
            strengthVal.text = GameInfo.PlayerStrength.ToString();
            avaliablePointsVal.text = avaliablePoints.ToString();
        }
    }
    public void PlusIntellect()
    {
        if (avaliablePoints > 0)
        {
            pointsToAllocate[2] += 1;
            --avaliablePoints;
            GameInfo.PlayerIntellect = pointsToAllocate[2];
            intellectVal.text = GameInfo.PlayerIntellect.ToString();
            avaliablePointsVal.text = avaliablePoints.ToString();
        }
    }
    public void MinusHP()
    {
        if (pointsToAllocate[0] > (baseStatPoints[0] - 1))
        {
             pointsToAllocate[0] -= 1;
             ++avaliablePoints;
            GameInfo.PlayerMaxHp = pointsToAllocate[0];
            hpVal.text = GameInfo.PlayerMaxHp.ToString();
            avaliablePointsVal.text = avaliablePoints.ToString();
        }
    }
    public void MinusStrength()
    {
        if (pointsToAllocate[1] > (baseStatPoints[1] - 1))
        {
            pointsToAllocate[1] -= 1;
            ++avaliablePoints;
            GameInfo.PlayerStrength = pointsToAllocate[1];
            strengthVal.text = GameInfo.PlayerStrength.ToString();
            avaliablePointsVal.text = avaliablePoints.ToString();
        }
    }
    public void MinusIntellect()
    {
        if (pointsToAllocate[2] > (baseStatPoints[2] - 1))
        {
            pointsToAllocate[2] -= 1;
            ++avaliablePoints;
            GameInfo.PlayerIntellect = pointsToAllocate[2];
            intellectVal.text = GameInfo.PlayerIntellect.ToString();
            avaliablePointsVal.text = avaliablePoints.ToString();
        }
    }
    public void Next()
    {
        GameInfo.PlayerMaxHp = pointsToAllocate[0];
        GameInfo.PlayerStrength = pointsToAllocate[1];
        GameInfo.PlayerIntellect = pointsToAllocate[2];
    }
    public void Female()
    {
        genderSelection = 0;
    }
    public void Hemale()
    {
        genderSelection = 1;
    }
    public void Done()
    {
        playerName = nameField.text;
        playerName += " the berk";
        GameInfo.PlayerName = playerName;
        GameInfo.PlayerBio = bioField.text;
        GameInfo.isMale = genderSelection;
        GameInfo.PlayerCurrentHp = GameInfo.PlayerMaxHp;
        GameInfo.PlayerInventory = new InventoryObject();
        SaveInfo.SaveAllInfo();
        SceneManager.LoadScene("SampleScene");
    }

    public void DisplayStatAllocationModule()
    {
        if (!didRunOnce)
        {
            RetrieveBaseStatPoints();
            didRunOnce = true;
        }
    }
    string FindClassDescription(int classSelection)
    {
        if (classSelection == 0)
        {
            tempClass = new BaseMageClass();
            return tempClass.CharacterClassDescription;
        }
        else if (classSelection == 1)
        {
            tempClass = new BaseWarriorClass();
            return tempClass.CharacterClassDescription;
        }
        return null;
    }
    string FindClassStatValues(int classSelection)
    {
        if (classSelection == 0)
        {
            BaseCharacterClass tempClass = new BaseMageClass();
            string tempState = "Stamina " + tempClass.Hp + "\n" + "Strength " + tempClass.Strength + "\n" + "Intellect " + tempClass.Intellect;
            return tempState;
        }
        if (classSelection == 1)
        {
            BaseCharacterClass tempClass = new BaseWarriorClass();
            string tempState = "Stamina " + tempClass.Hp + "\n" + "Strength " + tempClass.Strength + "\n" + "Intellect " + tempClass.Intellect;
            return tempState;
        }

        return null;
    }
    void ChooseClass(int classSelection)
    {
        if (classSelection == 0)
        {
            GameInfo.PlayerClass = new BaseMageClass();
        }
        else if (classSelection == 1)
        {
            GameInfo.PlayerClass = new BaseWarriorClass();
        }
        hpVal.text = GameInfo.PlayerClass.Hp.ToString();
        strengthVal.text = GameInfo.PlayerClass.Strength.ToString();
        intellectVal.text = GameInfo.PlayerClass.Intellect.ToString();
        RetrieveBaseStatPoints();
    }
    void AddAbilities(int classSelection)
    {
        if (classSelection == 0)
        {
            Debug.Log("Aint done mage yet");
        }
        else if (classSelection == 1)
        {
            GameInfo.PlayerAbilities = tempClass.PlayerAbilities;
        }
    }
    void RetrieveBaseStatPoints()
    {
        BaseCharacterClass ccClass = GameInfo.PlayerClass;
        pointsToAllocate[0] = ccClass.Hp;
        baseStatPoints[0] = ccClass.Hp;
        pointsToAllocate[1] = ccClass.Strength;
        baseStatPoints[1] = ccClass.Strength;
        pointsToAllocate[2] = ccClass.Intellect;
        baseStatPoints[2] = ccClass.Intellect;
    }
}
