﻿namespace CheckerApp.Shared.Models.Contract
{
    public class ContractDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        public bool HasProtocol { get; set; }
    }
}