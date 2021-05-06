using Core.Entities;

namespace Entities.Dtos
{
    public class OperationClaimListDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
