﻿namespace CheckerApp.Application.Checks.Queries.GetCheckResultFile
{
    public class CheckResultFileDto
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
