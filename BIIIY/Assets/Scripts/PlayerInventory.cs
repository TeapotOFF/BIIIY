using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] UIGame uIGame;
    List<StateObject> cards = new List<StateObject>();
    //public Dictionary<int, int> dictionaryItems = new Dictionary<int, int>();
    
    public void AddCard(string id, Texture image, string name, string description, string power){
        StateObject card = new StateObject(){
            id=id,
            Name=name,
            Icon=Sprite.Create((Texture2D)image, new Rect(0,0, image.width,image.height), Vector2.zero),
            Power=power
        };
        cards.Add(card);
        uIGame.AddCardInInventory(card);
    }
    public void DeleteItem(string id){
        foreach ( StateObject card in cards){
            if (card.id==id) {
                uIGame.DeleteCardFromInventory(card);
                cards.Remove(card);
                break;
            }
        }
    }


}
