namespace Core.Entities.Concrete
{
    class UserOperationClaim:IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int OperationClaimId { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
