using Core.Entities;

namespace Entities.Dtos.OperationClaim
{
    public class OperationClaimDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
