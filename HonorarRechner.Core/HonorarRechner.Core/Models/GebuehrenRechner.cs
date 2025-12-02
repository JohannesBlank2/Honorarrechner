using HonorarRechner.Core.Models;
using System;
using System.Collections.Generic;

namespace HonorarRechner.Core.Services
{
    /// <summary>
    /// Kümmert sich um die mathematische Berechnung der Gebühren (Interpolation).
    /// </summary>
    public class GebuehrenRechner
    {
        public double BerechneVolleGebuehrAbschluss(double wert)
        {
            // Logik: Tabelle C (Abschluss)
            return Calculate(wert, GebuehrenTabellen.AbschlussTabelle,
                             maxTableLimit: 50000000,
                             maxFee: 6923,
                             addFee: 273,
                             step: 5000000);
        }

        public double BerechneVolleGebuehrBeratung(double wert)
        {
            // Logik: Tabelle A (Beratung)
            return Calculate(wert, GebuehrenTabellen.BeratungsTabelle,
                             maxTableLimit: 600000,
                             maxFee: 3404,
                             addFee: 149,
                             step: 50000);
        }

        public double BerechneVolleGebuehrBuchfuehrung(double wert)
        {
            // Logik: Tabelle (Buchführung)
            return Calculate(wert, GebuehrenTabellen.BuchfuehrungsTabelle,
                             maxTableLimit: 500000,
                             maxFee: 512,
                             addFee: 36,
                             step: 50000);
        }

        private double Calculate(double wert, List<GebuehrEintrag> table, double maxTableLimit, double maxFee, double addFee, double step)
        {
            // 1. In der Tabelle suchen
            foreach (var e in table)
            {
                if (wert <= e.GegenstandswertBis) return e.VolleGebuehr;
            }

            // 2. Wenn Wert größer als Tabelle -> Formel anwenden
            if (wert > maxTableLimit)
            {
                double mehr = wert - maxTableLimit;
                // Math.Ceiling sorgt für "pro angefangene X Euro"
                int steps = (int)Math.Ceiling(mehr / step);
                return maxFee + (steps * addFee);
            }

            return maxFee;
        }
    }
}