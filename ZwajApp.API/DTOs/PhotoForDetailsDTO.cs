namespace ZwajApp.API.DTOs
{
    public class PhotoForDetailsDTO
    {
        public int Id { get; set; }
        public string   Url { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
    }
}