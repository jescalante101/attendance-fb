
using Entities.DTO.Area;
using Entities.DTO.CostCenter;

namespace Entities.DTO.SedeAreasDTO
{
    public class SedeConAreasDto
    {
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public List<AreaDto> Areas { get; set; } = new();

        public List<CostCenterDto> CostCenters { get; set; } = new();
    }
}
