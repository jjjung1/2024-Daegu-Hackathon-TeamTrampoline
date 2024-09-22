using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    public TutorialScript TS;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = TS.message;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = TS.message;
    }
}
