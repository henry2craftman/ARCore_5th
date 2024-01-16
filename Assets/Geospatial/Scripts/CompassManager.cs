using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// XROrigin이 북쪽으로 부터 얼마나 회전 했는지 확인
/// </summary>
public class CompassManager : MonoBehaviour
{
    [SerializeField] Transform arrowRoot;
    [SerializeField] TMP_Text angleTxt;
    float angle;
    public float Angle { get { return angle; } }
    bool isDataReceived;
    public bool IsDataReceived { get { return isDataReceived; } }
    GPSManager gPSManager;

    // Start is called before the first frame update
    void Start()
    {
        gPSManager = FindAnyObjectByType<GPSManager>();

        angleTxt.text = string.Empty;

        StartCoroutine(TurnOnCompass());
    }

    IEnumerator TurnOnCompass()
    {
        Input.compass.enabled = true;

        yield return new WaitForSeconds(1);

        isDataReceived = true;
        gPSManager.logTxt.text += "Compass Data Received\n";

        while (Input.compass.enabled)
        {
            arrowRoot.transform.rotation = Quaternion.Euler(0, 0, Input.compass.trueHeading);
            angle = Mathf.RoundToInt(Input.compass.trueHeading);
            angleTxt.text = $"{angle}˚";

            isDataReceived = true;

            yield return new WaitForSeconds(0.01f);
        }
    }
}
