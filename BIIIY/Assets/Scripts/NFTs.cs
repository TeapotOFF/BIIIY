using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using System.IO;



public class NFTs : MonoBehaviour
{
    [System.Serializable]
    public struct Token
    {
        public string description { get; set; }
        public string id { get; set; }
        public string image_url { get; set; }
        public string name { get; set; }
        [System.NonSerialized] public Texture image;
    }
    List<Token> MyTokens = new List<Token>();
    string chain = "ethereum";
    string network = "rinkeby";
    [SerializeField] string contract = "0x3C99b2C705f77dd8e3b26D03001fE44AedAb72b1";
    string account = "0xd30B24F8E74b5E040c125Cc16902Ad681Aa77E9d";
    int limit = 500;
    int skip = 0;

    PlayerInventory inventory;

    async void Start()
    {
        //account = PlayerPrefs.GetString("Account");
        inventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        Refresh();
    }

    async void Refresh(){
        string response = await API.GetTokens(account);
        
        var arr = JObject.Parse(response).GetValue("assets");
        
        var tokens =
            arr.Select(item =>
                    new Token() { name = (string)item["name"], image_url = (string)item["image_url"], id = (string)item["id"], description = (string)item["description"] })
            .ToList();
        
        var deleteList = MyTokens.Except(tokens);
        var addList = tokens.Except(MyTokens);
        foreach (var del in deleteList){
            DeleteItem(del);
            MyTokens.Remove(del);
        }
        foreach (var i in addList){
            CreateCard(i); 
        }

    }

    async void CreateCard(Token token){
        token.image = await API.GetImage(token.image_url);
        AddItem(token);
    }
    void AddItem(Token token){
        inventory.AddCard(token.id, token.image, token.name, token.description, "2");
    }

    void DeleteItem(Token token){
        inventory.DeleteItem(token.id);
    }
}

