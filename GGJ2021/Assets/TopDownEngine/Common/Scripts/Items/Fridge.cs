using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

public class Fridge : MonoBehaviour{

    public GameObject MeatMenu;
    public int meatPageIdx = 0;
    public List<GameObject> meatPages = new List<GameObject>();
    public List<FoodItem> items = new List<FoodItem>();
    public Inventory inventory;
    public GameObject player;
    public AudioClip sfx_open;
    public AudioClip sfx_close;

    public void enableMenu(){
        MeatMenu.SetActive(true);
        meatPages[0].SetActive(true);
        GameObject temporaryAudioHost = new GameObject("TempAudio");
        temporaryAudioHost.transform.position = gameObject.transform.position;
        AudioSource audioSource = temporaryAudioHost.AddComponent<AudioSource>() as AudioSource;
        audioSource.clip = sfx_open;
        audioSource.volume = 1f;
        audioSource.Play();
        Destroy(temporaryAudioHost, sfx_open.length);
    }

    public void chooseFood(int i){
        Debug.Log(MeatMenu);
        MeatMenu.SetActive(false);
        meatPages[i].SetActive(false);

        inventory.Content[0] = items[i];
        player.transform.GetChild(0)
                .gameObject.GetComponent<SpriteRenderer>()
                .sprite = items[i].Icon;
        GameObject temporaryAudioHost = new GameObject("TempAudio");
        temporaryAudioHost.transform.position = gameObject.transform.position;
        AudioSource audioSource = temporaryAudioHost.AddComponent<AudioSource>() as AudioSource;
        audioSource.clip = sfx_close;
        audioSource.volume = 1f;
        audioSource.Play();
        Destroy(temporaryAudioHost, sfx_close.length);
    }
}
