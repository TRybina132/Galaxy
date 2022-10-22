using Domain.Entities;

namespace Domain.Communication.Planets.Results
{
    public class GetPlanetsResult
    {
        public bool IsSuccessed { get; init; }
        public string? Error { get; init; }
        public IEnumerable<Planet> Planets { get; init; }
    }
}
