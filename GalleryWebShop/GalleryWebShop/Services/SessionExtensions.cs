using GalleryWebShop.Services.Cart;
using Newtonsoft.Json;

namespace GalleryWebShop.Services
{
    public static class SessionExtensions
    {
        // Serialize
        public static void SetCartObjectAsJson(
            this ISession session,
            string key,
            object value   
            )
        {
            session.SetString(
                key,
                JsonConvert.SerializeObject(value)
                );
        }

        // Deserialize
        public static List<CartItem>GetCartObjectFromJson(
            this ISession session,
            string key
            )
        {
            var value = session.GetString(key);
                        
            return value == null ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(value);
        }


    }
}
