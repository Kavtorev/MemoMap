using MemoMap.Domain.SeedWork;


namespace MemoMap.Domain.Models
{
    public class Note : Entity
    {
        /*
         note_id int
         title string 
         description string
         image byte
         location_id FK
        */
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        
        public int LocationId { get; set; }
        // one note can belong to one location (point) 
        public Location Location { get; set; }
    }
}
