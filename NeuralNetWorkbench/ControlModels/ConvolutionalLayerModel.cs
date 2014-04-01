using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Layers;

namespace NeuralNetWorkbench.ControlModels
{
    public class ConvolutionalLayerModel : LayerWithActivationFunction
    {
        #region Properties

        private int m_NumFeatureMaps;
        //private int m_FeatureMapWidth;
        private int m_KernelWidth;
        private int m_StepSize;
        private bool m_UseRandomConnections;
        private double m_RandomConnectionDensity;

        public int NumFeatureMaps
        {
            get { return m_NumFeatureMaps; }
            set
            {
                if (m_NumFeatureMaps != value)
                {
                    m_NumFeatureMaps = value;
                    RaisePropertyChanged(() => NumFeatureMaps);
                }
            }
        }

        public int StepSize
        {
            get { return m_StepSize; }
            set
            {
                if (m_StepSize != value)
                {
                    m_StepSize = value;
                    RaisePropertyChanged(() => StepSize);
                }
            }
        }

        //public int FeatureMapWidth
        //{
        //    get { return m_FeatureMapWidth; }
        //    set
        //    {
        //        if (m_FeatureMapWidth != value)
        //        {
        //            m_FeatureMapWidth = value;
        //            RaisePropertyChanged(() => FeatureMapWidth);
        //        }
        //    }
        //}

        public int KernelWidth
        {
            get { return m_KernelWidth; }
            set
            {
                if (m_KernelWidth != value)
                {
                    m_KernelWidth = value;
                    RaisePropertyChanged(() => KernelWidth);
                }
            }
        }

        public bool UseRandomConnections
        {
            get { return m_UseRandomConnections; }
            set
            {
                if (m_UseRandomConnections != value)
                {
                    m_UseRandomConnections = value;
                    RaisePropertyChanged(() => UseRandomConnections);
                }
            }
        }

        public double RandomConnectionDensity
        {
            get { return m_RandomConnectionDensity; }
            set
            {
                if (m_RandomConnectionDensity != value)
                {
                    m_RandomConnectionDensity = value;
                    RaisePropertyChanged(() => RandomConnectionDensity);
                }
            }
        }

        #endregion

        public ConvolutionalLayer GetLayer()
        {
            return new ConvolutionalLayer(ActivationFunctionType.Type, KernelWidth, NumFeatureMaps, StepSize, UseRandomConnections, RandomConnectionDensity);
        }

        public void SetLayer(ConvolutionalLayer layer)
        {
            ActivationFunctionType = ActivationFunctionTypes.First(t => t.Type == layer.ActivationFuncType);
            KernelWidth = layer.KernelWidth;
            NumFeatureMaps = layer.NumFeatureMaps;
            //FeatureMapWidth = layer.FeatureMapWidth;
            UseRandomConnections = layer.UseRandomConnectionsToPrev;
            RandomConnectionDensity = layer.RandomConnectionDensity;
            StepSize = layer.StepSize;
        }
    }
}
