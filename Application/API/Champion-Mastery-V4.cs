using Library.Models.RiotDevPortal.API;


namespace Application.API
{
    public class Champion_Mastery_V4
    {
        public static async Task<Response> ByEncryptedSummonerId(string region, string encryptedSummonerId, string apiKey)
        {
            string url = $"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}?api_key={apiKey}";
            return await Response.Get(url);
        }
    }
}
