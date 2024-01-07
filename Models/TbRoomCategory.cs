using System.ComponentModel.DataAnnotations.Schema;

namespace DOANQL.Models
{
    [Table("RoomCategory")]
    public partial class TbRooomCategory
    {
        public int CategoryRoomId { get; set; }

        public string? Title { get; set; }

        public string? Alias { get; set; }

        public string? Description { get; set; }

        public string? Icon { get; set; }

        public int? Position { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<TbRoom> TbRooms { get; set; } = new List<TbRoom>();
    }
}


    
    