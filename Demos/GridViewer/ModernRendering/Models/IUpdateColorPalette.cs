﻿namespace GridViewer
{
    public interface IUpdateColorPalette
    {
        float MinColorCode { get; set; }
        float MaxColorCode { get; set; }

        void UpdateColor(TracyEnergy.Simba.Data.Keywords.impl.GridBlockProperty property);
    }
}