namespace GalleryWebShop.Common
{
    public static class Helper
    {
        public static string SessionCartKey => "_cart";
        
        public static void TrimStringProperties(object obj)
        {
            var stringProperties = obj.GetType().GetProperties()
                          .Where(p => p.PropertyType == typeof(string));

            foreach (var stringProperty in stringProperties)
            {
                string currentValue = (string)stringProperty.GetValue(obj, null);
                if (!string.IsNullOrEmpty(currentValue))
                {
                    stringProperty.SetValue(obj, currentValue.Trim(), null);
                }
            }
        }
    }

}
