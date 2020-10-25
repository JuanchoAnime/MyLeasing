namespace MyLeasing.Common.Rest
{
    public class PropertyImageRest
    {
        public string ImageUrl { get; set; }

        public string ImagePath 
        {
            get {
                if (string.IsNullOrEmpty(ImageUrl)) return string.Empty;
                return $"https://localhost:44357{ImageUrl.Substring(1)}";
            }
        }
    }
}
