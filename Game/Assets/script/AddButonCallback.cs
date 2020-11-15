using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButonCallback : MonoBehaviour
{
    [SerializeField]
    private bool physical;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>AddCallback());
    }

    private void AddCallback(){
        GameObject playerParty =GameObject.Find("PlayerParty");
        playerParty.GetComponent<selectUnit>().SelectAttack(physical);
    }
}
