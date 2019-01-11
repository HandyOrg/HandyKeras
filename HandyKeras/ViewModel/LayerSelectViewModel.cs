using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using HandyKeras.Data;
using HandyKeras.Data.Model;

namespace HandyKeras.ViewModel
{
    internal class LayerSelectViewModel : ViewModelBase
    {
        public ObservableCollection<LayerModel> LayerList { get; set; } =
            new ObservableCollection<LayerModel>();

        public LayerSelectViewModel()
        {
            //下面这部分可以考虑放到配置文件中（但是要注意本地化）
            LayerList.Add(new LayerModel
            {
                Name = "Dense",
                Detail = "就是你常用的的全连接层。"
            });
            LayerList.Add(new LayerModel
            {
                Name = "Activation",
                Detail = "将激活函数应用于输出。"
            });
            LayerList.Add(new LayerModel
            {
                Name = "Dropout",
                Detail = "Dropout 包括在训练中每次更新时， 将输入单元的按比率随机设置为 0， 这有助于防止过拟合。"
            });
            LayerList.Add(new LayerModel
            {
                Name = "Flatten",
                Detail = "将输入展平。不影响批量大小。"
            });
            LayerList.Add(new LayerModel
            {
                Name = "Input",
                Detail = "用于实例化 Keras 张量。"
            });
            LayerList.Add(new LayerModel
            {
                Name = "Reshape",
                Detail = "将输入重新调整为特定的尺寸。"
            });
            LayerList.Add(new LayerModel
            {
                Name = "Permute",
                Detail = "根据给定的模式置换输入的维度。"
            });
            LayerList.Add(new LayerModel
            {
                Name = "RepeatVector",
                Detail = "将输入重复 n 次。"
            });
            LayerList.Add(new LayerModel
            {
                Name = "Lambda",
                Detail = "将任意表达式封装为 Layer 对象。"
            });
            LayerList.Add(new LayerModel
            {
                Name = "ActivityRegularization",
                Detail = "网络层，对基于代价函数的输入活动应用一个更新。"
            });
            LayerList.Add(new LayerModel
            {
                Name = "Masking",
                Detail = "使用覆盖值覆盖序列，以跳过时间步。"
            });
            LayerList.Add(new LayerModel
            {
                Name = "SpatialDropout1D",
                Detail = "Dropout 的 Spatial 1D 版本"
            });
            LayerList.Add(new LayerModel
            {
                Name = "SpatialDropout2D",
                Detail = "Dropout 的 Spatial 2D 版本"
            });
            LayerList.Add(new LayerModel
            {
                Name = "SpatialDropout3D",
                Detail = "Dropout 的 Spatial 3D 版本"
            });
        }

        public RelayCommand<LayerModel> SelectLayerCmd => new Lazy<RelayCommand<LayerModel>>(() =>
            new RelayCommand<LayerModel>(SelectLayer)).Value;

        private void SelectLayer(LayerModel layer)
        {
            if (layer == null) return;
            Messenger.Default.Send(layer, MessageToken.AddMapItem);
        }
    }
}