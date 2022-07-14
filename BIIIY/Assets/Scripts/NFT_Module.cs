using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Numerics;
using UnityEngine.Networking;

public class NFT_Module : MonoBehaviour
{
    private class NFT
    {
        public string contract { get; set; }
        public string tokenId { get; set; }
        public string uri { get; set; }
        public string balance { get; set; }
    }
    NFT[] Tokens;
    List<NFT> MyTokens;
    PlayerInventory inventory;
    string chain = "ethereum";
    string network = "rinkeby";
    [SerializeField] string contract = "0x2ebecabbbe8a8c629b99ab23ed154d74cd5d4342";
    string account;
    int first = 500;
    int skip = 0;
    async void Start()
    {
        account = PlayerPrefs.GetString("Account");
        inventory = GameObject.Find("").GetComponent<PlayerInventory>();
        Refresh();
    }

    async public void Refresh(){
        string response = await EVM.AllErc1155(chain, network, account, contract, first, skip);
        NFT[] tokens = JsonConvert.DeserializeObject<NFT[]>(response);

        foreach(NFT token in tokens){
            if(System.Convert.ToInt32(token.balance)>0){ 
                CreateItem(token);
                MyTokens.Add(token);
            }
        }

        /*for(int i=0;i<tokens.Length; i++){
            if(System.Convert.ToInt32(tokens[i].balance)>System.Convert.ToInt32(Tokens[i].balance)){
                CreateItem(tokens[i]);
                //MyTokens.Add(tokens[i]);
                continue;
            }
            if(System.Convert.ToInt32(tokens[i].balance)<System.Convert.ToInt32(Tokens[i].balance)){
                DeleteItem(tokens[i]);
                //MyTokens.Remove(tokens[i]);
                continue;
            }
        }*/
    }

    async void CreateItem(NFT token){
        Metadata metadata;
        Texture texture;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(token.uri)){
            await webRequest.SendWebRequest();
            metadata = JsonConvert.DeserializeObject<Metadata>(webRequest.downloadHandler.text);
        }
        using (UnityWebRequest webRequest = UnityWebRequest.Get(metadata.image)){
            await webRequest.SendWebRequest();
            texture = DownloadHandlerTexture.GetContent(webRequest);
        }
        
        inventory.AddCard(token.tokenId, texture, metadata.name, metadata.description, metadata.attributes[0].value, System.Convert.ToInt32(token.balance));
    }

    void DeleteItem(NFT token){
        inventory.DeleteItem(token.tokenId);
    }
}

public class Attribute{
    public string name;
    public string value;
}
public class Metadata{
    public List<Attribute> attributes {get;set;}
    public string description{get;set;}
    public string url{get;set;}
    public string image{get;set;}
    public string name{get;set;}
}