using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text : MonoBehaviour
{
    public GameObject Name;
    public GameObject Character;
    public GameObject Intellect;
    public GameObject Agility;
    public GameObject Strength;
    public GameObject Stamina;
    public GameObject points;
    public GameObject characterClass;
    public GameObject stats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Intellect.GetComponent<TextMeshProUGUI>().text = (stats.GetComponent<CreateCharacter>().Intellect).ToString();
        Agility.GetComponent<TextMeshProUGUI>().text = (stats.GetComponent<CreateCharacter>().Agility).ToString();
        Strength.GetComponent<TextMeshProUGUI>().text = (stats.GetComponent<CreateCharacter>().Strength).ToString();
        Stamina.GetComponent<TextMeshProUGUI>().text = (stats.GetComponent<CreateCharacter>().Stamina).ToString();
        points.GetComponent<TextMeshProUGUI>().text = (stats.GetComponent<CreateCharacter>().freePoints).ToString();
        characterClass.GetComponent<TextMeshProUGUI>().text = stats.GetComponent<CreateCharacter>().PlayerClass;
        stats.GetComponent<CreateCharacter>().Name = Name.GetComponent<TextMeshProUGUI>().text;
        Character.GetComponent<TextMeshProUGUI>().text = (stats.GetComponent<CreateCharacter>().characterIMG).ToString();
        
    }
}
