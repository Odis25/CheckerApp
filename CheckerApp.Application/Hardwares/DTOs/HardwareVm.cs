﻿using CheckerApp.Domain.Enums;

namespace CheckerApp.Application.Hardwares.DTOs
{
    public abstract class HardwareVm
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public HardwareType HardwareType { get; set; }
        public string SerialNumber { get; set; }
    }
}