using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrucoGameManager : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;

    public GameObject CardP1_1;
    public GameObject CardP1_2;
    public GameObject CardP1_3;
    public GameObject CardP2_1;
    public GameObject CardP2_2;
    public GameObject CardP2_3;
    public GameObject CardP3_1;
    public GameObject CardP3_2;
    public GameObject CardP3_3;
    public GameObject CardP4_1;
    public GameObject CardP4_2;
    public GameObject CardP4_3;
    public GameObject CardP5_1;
    public GameObject CardP5_2;
    public GameObject CardP5_3;
    public GameObject CardP6_1;
    public GameObject CardP6_2;
    public GameObject CardP6_3;

    public GameObject TrucoButton;
    public GameObject EnvidoButton;
    public GameObject PlayButton;

    // Start is called before the first frame update
    void Start()
    {
        Card1.SetActive(false);
        Card2.SetActive(false);
        Card3.SetActive(false);

        CardP1_1.SetActive(false);
        CardP1_2.SetActive(false);
        CardP1_3.SetActive(false);
        CardP2_1.SetActive(false);
        CardP2_2.SetActive(false);
        CardP2_3.SetActive(false);
        CardP3_1.SetActive(false);
        CardP3_2.SetActive(false);
        CardP3_3.SetActive(false);
        CardP4_1.SetActive(false);
        CardP4_2.SetActive(false);
        CardP4_3.SetActive(false);
        CardP5_1.SetActive(false);
        CardP5_2.SetActive(false);
        CardP5_3.SetActive(false);
        CardP6_1.SetActive(false);
        CardP6_2.SetActive(false);
        CardP6_3.SetActive(false);

        TrucoButton.SetActive(false);
        EnvidoButton.SetActive(false);
        PlayButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
