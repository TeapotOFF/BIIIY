using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PlayerInventory : MonoBehaviour
{
    List<Item> cards;
    //public Dictionary<int, int> dictionaryItems = new Dictionary<int, int>();
    
    public void AddCard(string id, Texture image, string name, string description, string power, int count){
        for(int i=0;i<count;i++){
            Item card = new Item(){
                IDItem=System.Convert.ToInt32(id),
                Name=name,
                Icon=Sprite.Create((Texture2D)image, new Rect(0,0, image.width,image.height), Vector2.zero),
                Power=power
            };
            cards.Add(card);
            Draw();
        }
    }
    public void DeleteItem(string id){
        foreach ( Item card in cards){
            if (card.IDItem==System.Convert.ToInt32(id)) {
                cards.Remove(card);
                break;
            }
        }
        Draw();
    }
    private void Draw(){
        //отрисовка
    }

}
