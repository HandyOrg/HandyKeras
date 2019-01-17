namespace HandyKeras.Data
{
    /// <summary>
    ///     核心网络层
    /// </summary>
    internal enum CoreLayersType
    {
        Dense,
        Activation,
        Dropout,
        Flatten,
        Input,
        Reshape,
        Permute,
        RepeatVector,
        Lambda,
        ActivityRegularization,
        Masking,
        SpatialDropout1D,
        SpatialDropout2D,
        SpatialDropout3D
    }

    /// <summary>
    ///     卷积层
    /// </summary>
    internal enum ConvolutionalLayersType
    {
        Conv1D,
        Conv2D,
        SeparableConv1D,
        SeparableConv2D,
        DepthwiseConv2D,
        Conv2DTranspose,
        Conv3D,
        Conv3DTranspose,
        Cropping1D,
        Cropping2D,
        Cropping3D,
        UpSampling1D,
        UpSampling2D,
        UpSampling3D,
        ZeroPadding1D,
        ZeroPadding2D,
        ZeroPadding3D
    }

    /// <summary>
    ///     池化层
    /// </summary>
    internal enum PoolingLayersType
    {
        MaxPooling1D,
        MaxPooling2D,
        MaxPooling3D,
        AveragePooling1D,
        AveragePooling2D,
        AveragePooling3D,
        GlobalMaxPooling1D,
        GlobalAveragePooling1D,
        GlobalMaxPooling2D,
        GlobalAveragePooling2D,
        GlobalMaxPooling3D,
        GlobalAveragePooling3D
    }

    /// <summary>
    ///     局部连接层
    /// </summary>
    internal enum LocallyConnectedLayersType
    {
        LocallyConnected1D,
        LocallyConnected2D
    }

    /// <summary>
    ///     循环层
    /// </summary>
    internal enum RecurrentLayersType
    {
        RNN,
        SimpleRNN,
        GRU,
        LSTM,
        ConvLSTM2D,
        SimpleRNNCell,
        GRUCell,
        LSTMCell,
        CuDNNGRU,
        CuDNNLSTM
    }

    /// <summary>
    ///     嵌入层
    /// </summary>
    internal enum EmbeddingLayersType
    {
        Embedding
    }

    /// <summary>
    ///     融合层
    /// </summary>
    internal enum MergeLayersType
    {
        Add,
        Subtract,
        Multiply,
        Average,
        Maximum,
        Concatenate,
        Dot,
        add,
        subtract,
        multiply,
        average,
        maximum,
        concatenate,
        dot
    }

    /// <summary>
    ///     高级激活层
    /// </summary>
    internal enum AdvancedActivationsLayersType
    {
        LeakyReLU,
        PReLU,
        ELU,
        ThresholdedReLU,
        Softmax,
        ReLU
    }

    /// <summary>
    ///     标准化层
    /// </summary>
    internal enum NormalizationLayersType
    {
        BatchNormalization
    }

    /// <summary>
    ///     噪声层
    /// </summary>
    internal enum NoiseLayersType
    {
        GaussianNoise,
        GaussianDropout,
        AlphaDropout
    }
}