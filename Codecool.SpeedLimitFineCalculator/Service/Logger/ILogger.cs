﻿namespace Codecool.SpeedLimitFineCalculator.Service.Logger;

   public interface ILogger
    {
        public void LogInfo(string message);
        public void LogError(string message);
    }