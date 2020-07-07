using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color objectColor;
    [Space]
    [Tooltip("Set random color on awake")]
    [SerializeField] private bool setToRandom = false;

    private void Awake()
    {
        if (!setToRandom) { GetComponent<MeshRenderer>().material.color = objectColor; }
        else
        {
            var randomColor = SetRandomColor();
            GetComponent<MeshRenderer>().material.color = randomColor;
        }
    }

    //Returns randomly generated color.
    private Color SetRandomColor()
    {
        return new Color32((byte)Random.Range(0, 255),     // R
                            (byte)Random.Range(0, 255),    // G
                            (byte)Random.Range(0, 255),    // B
                            255);                          // A
    }

}
