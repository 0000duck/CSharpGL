﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    abstract class WellPipelineBuilder
    {
        public List<CSharpGL.Tuple<WellRenderer, LabelRenderer>> Convert(WellSpecsCollection wellSpecsList, WellCompatCollection wellCompatList)
        {
            var result = new List<CSharpGL.Tuple<WellRenderer, LabelRenderer>>();
            if (wellSpecsList != null)
            {
                foreach (WellSpecs wellspec in wellSpecsList)
                {
                    CSharpGL.Tuple<WellRenderer, LabelRenderer> wellPipelineRenderer = this.Convert(wellspec, wellCompatList);
                    if (wellPipelineRenderer != null)
                    {
                        result.Add(wellPipelineRenderer);
                    }
                }
            }

            return result;
        }

        protected abstract CSharpGL.Tuple<WellRenderer, LabelRenderer> Convert(WellSpecs wellspec, WellCompatCollection wellCompatList);

    }
}
