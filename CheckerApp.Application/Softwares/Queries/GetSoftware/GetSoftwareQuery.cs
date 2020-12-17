using MediatR;

namespace CheckerApp.Application.Softwares.Queries.GetSoftware
{
    public class GetSoftwareQuery : IRequest<SoftwareDto>
    {
        public int Id { get; set; }
    }
}
