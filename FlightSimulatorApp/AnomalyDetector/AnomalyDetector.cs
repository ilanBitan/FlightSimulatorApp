﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.AnomalyDetector;

namespace FlightSimulatorApp.AnomalyDetector
{

    public class AnomalyReport
    {
        public string description;
        long timeStep;
        public AnomalyReport(string description, long timeStep)
        {
            this.description = description;
            this.timeStep = timeStep;
        }
    }

    public interface TimeSeriesAnomalyDetector
    {
        void learnNormal(Timeseries ts);
        List<AnomalyReport> detect(Timeseries ts);
    };
}
