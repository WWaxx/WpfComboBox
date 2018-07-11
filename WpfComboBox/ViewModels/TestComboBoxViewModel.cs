using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace WpfComboBox.ViewModels
{
    class TestComboBoxViewModel
    {
        class MyTestEntity
        {
            public string Name { get; set; }

            public MyTestEntity(string name)
            {
                Name = name;
            }
        }

        List<string> _ComboBoxList;

        List<MyTestEntity> _ComboBoxList2;

        public CollectionView MyCollectionView { get; }

        public CollectionView MyCollectionView2 { get; }

        public ICommand ComboBoxUpdating
        {
            get
            {
                return new DelegateCommand((f) =>
                {
                    _ComboBoxList[0] = "fdh";
                    _ComboBoxList2[0].Name = "fdh2";

                    MyCollectionView.Refresh();
                    MyCollectionView2.Refresh();
                });
            }
        }

        public TestComboBoxViewModel()
        {
            _ComboBoxList = new List<string> { "qwer", "asdf", "zxcv" };
            _ComboBoxList2 = new List<MyTestEntity>
            {
                new MyTestEntity("qwer2"),
                new MyTestEntity("asdf2"),
                new MyTestEntity("zxcv2")
            };

            MyCollectionView = new CollectionView(_ComboBoxList);
            MyCollectionView2 = new CollectionView(_ComboBoxList2);
        }
    }
}
