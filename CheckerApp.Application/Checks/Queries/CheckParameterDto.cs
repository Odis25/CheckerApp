using System;

namespace CheckerApp.Application.Checks.Queries
{
    public class CheckParameterDto
    {
        public string Description { get; set; } = string.Empty;
        public string Method { get; set; } = "На оборудовании";
        public bool Result { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
