using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine;

public class API
{
    [SerializeField] static string  contract = "0x3C99b2C705f77dd8e3b26D03001fE44AedAb72b1";
    public static async Task<string> GetTokens(string account, bool test=true, string limit="10")
    {
        string testnets=test?"testnets-":"";
        string url = "https://"+testnets+"api.opensea.io/api/v1/assets?owner="+account+"&asset_contract_address="+contract+"&order_direction=desc&offset=0&limit="+limit+"&include_orders=false";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            await webRequest.SendWebRequest();
            string response = webRequest.downloadHandler.text;
            return response;
        }
    }

    public static async Task<Texture> GetImage(string url){
        Texture texture;
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url)){
            await webRequest.SendWebRequest();
            if (webRequest.result != UnityWebRequest.Result.Success) {
                Debug.Log(webRequest.error);
            }
            texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture as Texture;
            
        }
        return texture;
    }
}
