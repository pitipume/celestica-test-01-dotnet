namespace Celestica.Models
{
    public class ShabuMemberPromotion
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime RedeemedOn { get; set; }
    }
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<ShabuMemberPromotion> ShabuMemberPromotion { get; set; }
    }
    public class Promotion
    {
        public int PromotionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ShabuMemberPromotion> ShabuMemberPromotion { get; set; }
    }
}