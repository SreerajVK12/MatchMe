using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDataSource", menuName = "ScriptableObjects/DataSource")]
public class DataSource : ScriptableObject
{
    public List<AudioClip> AudioClips;
    public List<LevelObject> LevelObjects;
    public List<CardObject> CardObjects;

    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    private Dictionary<int, CardObject> _cardObjects = new Dictionary<int, CardObject>();

    public void LoadAllCardData()
    {
        foreach (CardObject card in CardObjects)
        {
            if (card != null)
            {
                if (!_cardObjects.ContainsKey(card.Id))
                {
                    _cardObjects.Add(card.Id, card);
                }
            }
        }
    }

    public CardObject GetCardById(int Id)
    {
        if (_cardObjects.ContainsKey(Id))
        {
            return _cardObjects[Id];
        }

        return null;
    }

    public void LoadAllSounds()
    {
        foreach (AudioClip audioClip in AudioClips)
        {
            if (audioClip != null)
            {
                if (!_audioClips.ContainsKey(audioClip.name))
                {
                    _audioClips.Add(audioClip.name, audioClip);
                }
            }
        }
    }

    public AudioClip GetAudioByName(string name)
    {
        if (_audioClips.ContainsKey(name))
        {
            return _audioClips[name];
        }

        return null;
    }
}
