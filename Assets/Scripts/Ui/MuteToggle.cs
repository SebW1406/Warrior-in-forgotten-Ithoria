using UnityEngine;
using UnityEngine.UI;
public class MuteToggle : MonoBehaviour
{

    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private bool isOn = true;

    public AudioSource audioSource;

    Image SoundimageChild;

    void Awake()
    {
    }

    
void Start()
    {
        SoundimageChild = transform.GetChild(2).GetComponent<Image>(); /// Give me the third child, and give me its Image componente
        soundOnImage = SoundimageChild;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        if (isOn)
        { 
            button.image.sprite = soundOffImage;
            isOn = false;
            audioSource.mute = true;
        }

        else 
        {
            button.image.sprite = soundOnImage;
            isOn = true;
            audioSource.mute = false;
        }
    }



}

