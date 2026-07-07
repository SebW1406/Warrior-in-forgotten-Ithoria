using UnityEngine;
using UnityEngine.UI;
public class MuteToggle : MonoBehaviour
{

    private Sprite soundOnImage;
    [SerializeField] public Sprite soundOffImage;
    [SerializeField] private Button button;
    [SerializeField] private AudioSource audioSource;

    private bool isOn = true;


    Image SoundimageChild;


    void Start()
    {
        if (transform.childCount > 2)
        {
            SoundimageChild = transform.GetChild(2).GetComponent<Image>();
            if (SoundimageChild != null)
            {
                soundOnImage = SoundimageChild.sprite;
            }
            else
            {
                Debug.LogError("Das dritte Kind hat kein Image-Komponente!");
            }
        }
        else
        {
            Debug.LogError("Das GameObject hat weniger als 3 Kinder!");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {

        Debug.Log($"SoundimageChild: {SoundimageChild != null}");
        Debug.Log($"soundOnImage: {soundOnImage != null}");
        Debug.Log($"soundOffImage: {soundOffImage != null}");



        if (isOn)
        {
            SoundimageChild.sprite = soundOffImage;
            isOn = false;
            audioSource.mute = true;
        }

        else 
        {
            SoundimageChild.sprite = soundOnImage;
            isOn = true;
            audioSource.mute = false;
        }
   
    
    }



}

